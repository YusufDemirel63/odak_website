using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class EkipController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        private readonly IWebHostEnvironment _env;
        public EkipController(OdakDbContext context, IWebHostEnvironment env)
        { _context = context; _env = env; }

        public async Task<IActionResult> Index()
            => View(await _context.EkipUyeleri.OrderBy(e => e.Sira).ToListAsync());

        public IActionResult Ekle() => View(new EkipUyesi());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(EkipUyesi model, IFormFile? fotografFile)
        {
            if (!ModelState.IsValid) return View(model);
            if (fotografFile != null && fotografFile.Length > 0)
                model.FotografYolu = await GorselKaydet(fotografFile, "ekip");

            _context.EkipUyeleri.Add(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Ekip uyesi eklendi.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Duzenle(int id)
        {
            var uye = await _context.EkipUyeleri.FindAsync(id);
            if (uye == null) return NotFound();
            return View(uye);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(EkipUyesi model, IFormFile? fotografFile)
        {
            if (!ModelState.IsValid) return View(model);
            if (fotografFile != null && fotografFile.Length > 0)
                model.FotografYolu = await GorselKaydet(fotografFile, "ekip");

            _context.EkipUyeleri.Update(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Ekip uyesi guncellendi.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            var u = await _context.EkipUyeleri.FindAsync(id);
            if (u != null) { _context.EkipUyeleri.Remove(u); await _context.SaveChangesAsync(); }
            TempData["Mesaj"] = "Ekip uyesi silindi.";
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

