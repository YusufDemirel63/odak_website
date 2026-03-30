using Microsoft.AspNetCore.Mvc;
using OdakMVC.Data;
using OdakMVC.Models.Entities;
using OdakMVC.Models.ViewModels;

namespace OdakMVC.Controllers
{
    public class IletisimController : Controller
    {
        private readonly OdakDbContext _context;
        public IletisimController(OdakDbContext context) { _context = context; }

        [HttpGet]
        public IActionResult Index() => View(new IletisimFormViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IletisimFormViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var mesaj = new IletisimMesaji
            {
                AdSoyad = model.AdSoyad,
                Email = model.Email,
                Telefon = model.Telefon,
                Mesaj = model.Mesaj,
                GonderimTarihi = DateTime.Now,
                Okundu = false
            };

            _context.IletisimMesajlari.Add(mesaj);
            await _context.SaveChangesAsync();

            TempData["Basarili"] = "Mesajiniz basariyla iletildi. En kisa surede size donecegiz.";
            return RedirectToAction("Index");
        }
    }
}
