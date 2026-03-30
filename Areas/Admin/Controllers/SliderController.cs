using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class SliderController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(OdakDbContext context, IWebHostEnvironment env)
        { _context = context; _env = env; }

        public async Task<IActionResult> Index()
            => View(await _context.SliderGorselleri.OrderBy(s => s.Siralama).ToListAsync());

        public IActionResult Ekle() => View(new SliderGorseli());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(SliderGorseli model, IFormFile? gorselFile)
        {
            if (gorselFile != null && gorselFile.Length > 0)
            {
                var dir = Path.Combine(_env.WebRootPath, "gorseller", "sliders");
                Directory.CreateDirectory(dir);
                var dosyaAdi = Guid.NewGuid() + Path.GetExtension(gorselFile.FileName);
                var yol = Path.Combine(dir, dosyaAdi);
                using var stream = new FileStream(yol, FileMode.Create);
                await gorselFile.CopyToAsync(stream);
                model.GorselYolu = $"/gorseller/sliders/{dosyaAdi}";
            }
            _context.SliderGorselleri.Add(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Slider eklendi.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            var s = await _context.SliderGorselleri.FindAsync(id);
            if (s != null) { _context.SliderGorselleri.Remove(s); await _context.SaveChangesAsync(); }
            TempData["Mesaj"] = "Slider silindi.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AktifDegistir(int id)
        {
            var s = await _context.SliderGorselleri.FindAsync(id);
            if (s != null) { s.Aktif = !s.Aktif; await _context.SaveChangesAsync(); }
            return RedirectToAction("Index");
        }
    }
}
