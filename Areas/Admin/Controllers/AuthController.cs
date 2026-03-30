using Microsoft.AspNetCore.Mvc;

namespace OdakMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config) { _config = config; }

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
            var adminUser = _config["AdminSettings:Username"];
            var adminPass = _config["AdminSettings:Password"];

            if (kullaniciAdi == adminUser && sifre == adminPass)
            {
                HttpContext.Session.SetString("AdminGiris", "true");
                HttpContext.Session.SetString("AdminAdi", kullaniciAdi);
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            ModelState.AddModelError("", "Kullanici adi veya sifre yanlis.");
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Giris");
        }
    }
}
