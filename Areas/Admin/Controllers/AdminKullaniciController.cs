using Microsoft.AspNetCore.Mvc;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class AdminKullaniciController : AdminBaseController
    {
        private readonly OdakDbContext _context;

        public AdminKullaniciController(OdakDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var adminler = _context.AdminKullanicilari.ToList();
            return View(adminler);
        }

        public IActionResult Ekle()
        {
            return View(new AdminKullanici());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(AdminKullanici model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_context.AdminKullanicilari.Any(a => a.KullaniciAdi == model.KullaniciAdi))
            {
                ModelState.AddModelError("KullaniciAdi", "Bu kullanıcı adı zaten kullanılıyor.");
                return View(model);
            }

            _context.AdminKullanicilari.Add(model);
            _context.SaveChanges();
            TempData["Mesaj"] = "Admin kullanıcısı başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Duzenle(int id)
        {
            var admin = _context.AdminKullanicilari.Find(id);
            if (admin == null) return NotFound();
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(AdminKullanici model)
        {
            if (!ModelState.IsValid) return View(model);

            var mevcutAdmin = _context.AdminKullanicilari.Find(model.Id);
            if (mevcutAdmin == null) return NotFound();

            if (_context.AdminKullanicilari.Any(a => a.KullaniciAdi == model.KullaniciAdi && a.Id != model.Id))
            {
                ModelState.AddModelError("KullaniciAdi", "Bu kullanıcı adı başka bir hesaba ait.");
                return View(model);
            }

            mevcutAdmin.KullaniciAdi = model.KullaniciAdi;
            if (!string.IsNullOrWhiteSpace(model.Sifre))
            {
                mevcutAdmin.Sifre = model.Sifre;
            }
            mevcutAdmin.Aktif = model.Aktif;

            _context.SaveChanges();
            TempData["Mesaj"] = "Admin ayarları güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sil(int id)
        {
            var admin = _context.AdminKullanicilari.Find(id);
            if (admin != null)
            {
                if (_context.AdminKullanicilari.Count() == 1)
                {
                    TempData["Mesaj"] = "Sistemdeki son admini silemezsiniz!";
                    return RedirectToAction(nameof(Index));
                }
                _context.AdminKullanicilari.Remove(admin);
                _context.SaveChanges();
                TempData["Mesaj"] = "Admin hesabı silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
