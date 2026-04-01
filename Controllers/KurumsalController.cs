using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.NedenOdak = _context.IcerikSayfalari.FirstOrDefault(i => i.Anahtar == "NedenOdak");
            return View(icerik);
        }

        public IActionResult VizyonMisyon()
        {
            ViewBag.Misyon = _context.IcerikSayfalari.FirstOrDefault(i => i.Anahtar == "Misyon");
            ViewBag.Vizyon = _context.IcerikSayfalari.FirstOrDefault(i => i.Anahtar == "Vizyon");
            return View();
        }

        public IActionResult Ekibimiz()
        {
            var ekip = _context.EkipUyeleri
                .Include(e => e.EkipBirimi)
                .Where(e => e.Aktif)
                .OrderBy(e => e.HiyerarsiKademesi)
                .ThenBy(e => e.Sira)
                .ToList();
            ViewBag.Birimler = _context.EkipBirimleri.Where(b => b.Aktif).OrderBy(b => b.Sira).ToList();
            return View(ekip);
        }

        public IActionResult EkipDetay(int id)
        {
            var uye = _context.EkipUyeleri
                .Include(e => e.EkipBirimi)
                .FirstOrDefault(e => e.Id == id && e.Aktif);
            if (uye == null) return NotFound();
            return View(uye);
        }
    }
}
