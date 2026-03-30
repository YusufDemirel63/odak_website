using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class YayinController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        private readonly IWebHostEnvironment _env;
        public YayinController(OdakDbContext context, IWebHostEnvironment env)
        { _context = context; _env = env; }

        public async Task<IActionResult> Index()
            => View(await _context.Yayinlar.OrderByDescending(y => y.YayinTarihi).ToListAsync());

        public IActionResult Ekle() => View(new Yayin());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(Yayin model, IFormFile? gorselFile, IFormFile? dosyaFile)
        {
            if (gorselFile != null && gorselFile.Length > 0)
                model.GorselYolu = await DosyaKaydet(gorselFile, "yayinlar/gorseller");
            if (dosyaFile != null && dosyaFile.Length > 0)
                model.DosyaYolu = await DosyaKaydet(dosyaFile, "yayinlar/dosyalar");

            model.OlusturulmaTarihi = DateTime.Now;
            _context.Yayinlar.Add(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Yayin eklendi.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Duzenle(int id)
        {
            var yayin = await _context.Yayinlar.FindAsync(id);
            if (yayin == null) return NotFound();
            return View(yayin);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(Yayin model, IFormFile? gorselFile, IFormFile? dosyaFile)
        {
            if (gorselFile != null && gorselFile.Length > 0)
                model.GorselYolu = await DosyaKaydet(gorselFile, "yayinlar/gorseller");
            if (dosyaFile != null && dosyaFile.Length > 0)
                model.DosyaYolu = await DosyaKaydet(dosyaFile, "yayinlar/dosyalar");

            _context.Yayinlar.Update(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Yayin guncellendi.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            var y = await _context.Yayinlar.FindAsync(id);
            if (y != null) { _context.Yayinlar.Remove(y); await _context.SaveChangesAsync(); }
            TempData["Mesaj"] = "Yayin silindi.";
            return RedirectToAction("Index");
        }

        private async Task<string> DosyaKaydet(IFormFile file, string klasor)
        {
            var dir = Path.Combine(_env.WebRootPath, "gorseller", klasor);
            Directory.CreateDirectory(dir);
            var dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var yol = Path.Combine(dir, dosyaAdi);
            using var stream = new FileStream(yol, FileMode.Create);
            await file.CopyToAsync(stream);
            return $"/gorseller/{klasor}/{dosyaAdi}";
        }
    }
}
