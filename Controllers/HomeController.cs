using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.ViewModels;

namespace OdakMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly OdakDbContext _context;

        public HomeController(OdakDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                SonEtkinlikler = _context.Etkinlikler.Where(e => e.Aktif).OrderByDescending(e => e.Tarih).Take(4).ToList(),
                Sliderlar = _context.SliderGorselleri.Where(s => s.Aktif).OrderBy(s => s.Siralama).ToList(),
                Kulupler = _context.Kulupler.Where(k => k.Aktif).OrderBy(k => k.Sira).ToList(),
                HakkimizdaOzeti = _context.IcerikSayfalari.FirstOrDefault(i => i.Anahtar == "Hakkimizda")
            };

            return View(vm);
        }
    }
}
