using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class EgitimController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        private readonly IWebHostEnvironment _env;
        public EgitimController(OdakDbContext context, IWebHostEnvironment env)
        { _context = context; _env = env; }

        public async Task<IActionResult> Index()
            => View(await _context.Egitimler.OrderBy(e => e.Sira).ToListAsync());

        public IActionResult Ekle() => View(new Egitim());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(Egitim model, IFormFile? gorselFile)
        {
            if (gorselFile != null && gorselFile.Length > 0)
                model.GorselYolu = await GorselKaydet(gorselFile, "egitimler");

            model.OlusturulmaTarihi = DateTime.Now;
            _context.Egitimler.Add(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Egitim basariyla eklendi.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Duzenle(int id)
        {
            var egitim = await _context.Egitimler.FindAsync(id);
            if (egitim == null) return NotFound();
            return View(egitim);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(Egitim model, IFormFile? gorselFile)
        {
            if (gorselFile != null && gorselFile.Length > 0)
                model.GorselYolu = await GorselKaydet(gorselFile, "egitimler");

            _context.Egitimler.Update(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Egitim guncellendi.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            var e = await _context.Egitimler.FindAsync(id);
            if (e != null) { _context.Egitimler.Remove(e); await _context.SaveChangesAsync(); }
            TempData["Mesaj"] = "Egitim silindi.";
            return RedirectToAction("Index");
        }

        private async Task<string> GorselKaydet(IFormFile file, string klasor)
        {
            var uploads = Path.Combine(_env.WebRootPath, "gorseller", klasor);
            Directory.CreateDirectory(uploads);
            var dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var yol = Path.Combine(uploads, dosyaAdi);
            using var stream = new FileStream(yol, FileMode.Create);
            await file.CopyToAsync(stream);
            return $"/gorseller/{klasor}/{dosyaAdi}";
        }
    }
}
