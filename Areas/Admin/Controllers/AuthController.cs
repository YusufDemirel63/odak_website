using Microsoft.AspNetCore.Mvc;
using OdakMVC.Data;

namespace OdakMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly OdakDbContext _context;
        public AuthController(OdakDbContext context) { _context = context; }

        [HttpGet]
        public IActionResult Giris()
        {
            if (HttpContext.Session.GetString("AdminGiris") == "true")
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Giris(string kullaniciAdi, string sifre)
        {
            var adminUser = _context.AdminKullanicilari.FirstOrDefault(a => a.KullaniciAdi == kullaniciAdi && a.Sifre == sifre && a.Aktif);

            if (adminUser != null)
            {
                HttpContext.Session.SetString("AdminGiris", "true");
                HttpContext.Session.SetString("AdminAdi", adminUser.KullaniciAdi);
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış veya hesap pasif.");
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Giris");
        }
    }
}
