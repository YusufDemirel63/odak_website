using Microsoft.AspNetCore.Mvc;
using OdakMVC.Data;

namespace OdakMVC.Controllers
{
    public class KurumsalController : Controller
    {
        private readonly OdakDbContext _context;

        public KurumsalController(OdakDbContext context)
        {
            _context = context;
        }

        public IActionResult Hakkimizda()
        {
            var icerik = _context.IcerikSayfalari.FirstOrDefault(i => i.Anahtar == "Hakkimizda");
            return View(icerik);
        }

        public IActionResult VizyonMisyon()
        {
            var icerik = _context.IcerikSayfalari.FirstOrDefault(i => i.Anahtar == "Vizyon") 
                         ?? _context.IcerikSayfalari.FirstOrDefault(i => i.Anahtar == "Misyon");
            
            // View tarafinda birden cok model donmek yerin ViewBag kullanalim
            ViewBag.Misyon = _context.IcerikSayfalari.FirstOrDefault(i => i.Anahtar == "Misyon");
            ViewBag.Vizyon = _context.IcerikSayfalari.FirstOrDefault(i => i.Anahtar == "Vizyon");

            return View(icerik);
        }

        public IActionResult Ekibimiz()
        {
            var ekip = _context.EkipUyeleri.Where(e => e.Aktif).OrderBy(e => e.Sira).ToList();
            ViewBag.Birimler = _context.EkipBirimleri.Where(b => b.Aktif).OrderBy(b => b.Sira).ToList();
            return View(ekip);
        }
    }
}
