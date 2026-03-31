using Microsoft.AspNetCore.Mvc;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KurumsalIcerikController : AdminBaseController
    {
        private readonly OdakDbContext _context;

        public KurumsalIcerikController(OdakDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sayfalar = _context.IcerikSayfalari.OrderBy(i => i.Id).ToList();
            return View(sayfalar);
        }

        public IActionResult Duzenle(int id)
        {
            var sayfa = _context.IcerikSayfalari.Find(id);
            if (sayfa == null) return NotFound();
            return View(sayfa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(IcerikSayfasi model, IFormFile? gorselFile)
        {
            if (ModelState.IsValid)
            {
                var p = _context.IcerikSayfalari.Find(model.Id);
                if (p == null) return NotFound();

                if (gorselFile != null && gorselFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/gorseller/icerik");
                    Directory.CreateDirectory(uploadsFolder);
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + gorselFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        gorselFile.CopyTo(stream);
                    }
                    p.GorselYolu = "/gorseller/icerik/" + uniqueFileName;
                }

                p.Baslik = model.Baslik;
                p.Icerik = model.Icerik;

                _context.SaveChanges();
                TempData["Mesaj"] = "Icerik basariyla guncellendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}

