using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.ViewModels;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        public DashboardController(OdakDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var vm = new AdminDashboardViewModel
            {
                ToplamEtkinlik = await _context.Etkinlikler.CountAsync(),
                ToplamEgitim = await _context.Egitimler.CountAsync(),
                ToplamEkipUyesi = await _context.EkipUyeleri.CountAsync(),
                ToplamYayin = await _context.Yayinlar.CountAsync(),
                OkunmamisMesaj = await _context.IletisimMesajlari.CountAsync(m => !m.Okundu),
                ToplamGaleri = await _context.GaleriGorselleri.CountAsync()
            };
            return View(vm);
        }
    }
}
