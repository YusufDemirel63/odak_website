using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class EtkinlikController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        private readonly IWebHostEnvironment _env;
        public EtkinlikController(OdakDbContext context, IWebHostEnvironment env)
        { _context = context; _env = env; }

        public async Task<IActionResult> Index()
            => View(await _context.Etkinlikler.OrderByDescending(e => e.OlusturulmaTarihi).ToListAsync());

        public IActionResult Ekle() => View(new Etkinlik());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(Etkinlik model, IFormFile? afisFile)
        {
            if (!ModelState.IsValid) return View(model);
            if (afisFile != null && afisFile.Length > 0)
                model.AfisGorseli = await GorselKaydet(afisFile, "etkinlikler");

            model.OlusturulmaTarihi = DateTime.Now;
            _context.Etkinlikler.Add(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Etkinlik basariyla eklendi.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Duzenle(int id)
        {
            var etkinlik = await _context.Etkinlikler.FindAsync(id);
            if (etkinlik == null) return NotFound();
            return View(etkinlik);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(Etkinlik model, IFormFile? afisFile)
        {
            if (!ModelState.IsValid) return View(model);
            if (afisFile != null && afisFile.Length > 0)
                model.AfisGorseli = await GorselKaydet(afisFile, "etkinlikler");

            _context.Etkinlikler.Update(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Etkinlik basariyla guncellendi.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            var etkinlik = await _context.Etkinlikler.FindAsync(id);
            if (etkinlik != null) { _context.Etkinlikler.Remove(etkinlik); await _context.SaveChangesAsync(); }
            TempData["Mesaj"] = "Etkinlik silindi.";
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

