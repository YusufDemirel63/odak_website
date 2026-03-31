using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class GaleriController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        private readonly IWebHostEnvironment _env;
        public GaleriController(OdakDbContext context, IWebHostEnvironment env)
        { _context = context; _env = env; }

        public async Task<IActionResult> Index()
            => View(await _context.GaleriGorselleri.OrderByDescending(g => g.Tarih).ToListAsync());

        public IActionResult Ekle() => View(new GaleriGorseli());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(GaleriGorseli model, List<IFormFile> gorselFiles)
        {
            if (!ModelState.IsValid) return View(model);
            foreach (var file in gorselFiles.Where(f => f.Length > 0))
            {
                var dir = Path.Combine(_env.WebRootPath, "gorseller", "galeri");
                Directory.CreateDirectory(dir);
                var dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var yol = Path.Combine(dir, dosyaAdi);
                using var stream = new FileStream(yol, FileMode.Create);
                await file.CopyToAsync(stream);
                var gorsel = new GaleriGorseli
                {
                    GorselYolu = $"/gorseller/galeri/{dosyaAdi}",
                    Baslik = model.Baslik,
                    EtkinlikAdi = model.EtkinlikAdi,
                    Tarih = model.Tarih,
                    Aktif = true
                };
                _context.GaleriGorselleri.Add(gorsel);
            }
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Gorseller yuklendi.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            var g = await _context.GaleriGorselleri.FindAsync(id);
            if (g != null) { _context.GaleriGorselleri.Remove(g); await _context.SaveChangesAsync(); }
            TempData["Mesaj"] = "Gorsel silindi.";
            return RedirectToAction("Index");
        }
    }
}

