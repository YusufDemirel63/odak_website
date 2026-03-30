using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.ViewModels;

namespace OdakMVC.Controllers
{
    public class EtkinlikController : Controller
    {
        private readonly OdakDbContext _context;
        public EtkinlikController(OdakDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var etkinlikler = await _context.Etkinlikler.Where(e => e.Aktif).OrderByDescending(e => e.Tarih).ToListAsync();
            return View(etkinlikler);
        }

        public async Task<IActionResult> Detay(int id)
        {
            var etkinlik = await _context.Etkinlikler.FindAsync(id);
            if (etkinlik == null) return NotFound();
            var vm = new EtkinlikDetayViewModel
            {
                Etkinlik = etkinlik,
                DigerEtkinlikler = await _context.Etkinlikler.Where(e => e.Aktif && e.Id != id).Take(4).ToListAsync()
            };
            return View(vm);
        }

        public async Task<IActionResult> Kareler()
        {
            var gorseller = await _context.GaleriGorselleri.Where(g => g.Aktif).OrderByDescending(g => g.Tarih).ToListAsync();
            return View(gorseller);
        }
    }
}
