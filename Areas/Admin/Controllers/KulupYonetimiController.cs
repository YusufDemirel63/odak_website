using Microsoft.AspNetCore.Mvc;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KulupYonetimiController : AdminBaseController
    {
        private readonly OdakDbContext _context;

        public KulupYonetimiController(OdakDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kulupler = _context.Kulupler.OrderBy(k => k.Sira).ToList();
            return View(kulupler);
        }

        public IActionResult Ekle()
        {
            return View(new Kulup());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Kulup model, IFormFile? gorselFile)
        {
            if (ModelState.IsValid)
            {
                if (gorselFile != null && gorselFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/gorseller/kulupler");
                    Directory.CreateDirectory(uploadsFolder);
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + gorselFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        gorselFile.CopyTo(stream);
                    }
                    model.GorselYolu = "/gorseller/kulupler/" + uniqueFileName;
                }

                _context.Kulupler.Add(model);
                _context.SaveChanges();
                TempData["Mesaj"] = "Kulup basariyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Duzenle(int id)
        {
            var kulup = _context.Kulupler.Find(id);
            if (kulup == null) return NotFound();
            return View(kulup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(Kulup model, IFormFile? gorselFile)
        {
            if (ModelState.IsValid)
            {
                var p = _context.Kulupler.Find(model.Id);
                if (p == null) return NotFound();

                if (gorselFile != null && gorselFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/gorseller/kulupler");
                    Directory.CreateDirectory(uploadsFolder);
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + gorselFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        gorselFile.CopyTo(stream);
                    }
                    p.GorselYolu = "/gorseller/kulupler/" + uniqueFileName;
                }

                p.Ad = model.Ad;
                p.Icon = model.Icon;
                p.KisaAciklama = model.KisaAciklama;
                p.UzunAciklama = model.UzunAciklama;
                p.Sira = model.Sira;
                p.Aktif = model.Aktif;

                _context.SaveChanges();
                TempData["Mesaj"] = "Kulup basariyla guncellendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sil(int id)
        {
            var p = _context.Kulupler.Find(id);
            if (p != null)
            {
                _context.Kulupler.Remove(p);
                _context.SaveChanges();
                TempData["Mesaj"] = "Kulup silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
