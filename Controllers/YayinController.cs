using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;

namespace OdakMVC.Controllers
{
    public class YayinController : Controller
    {
        private readonly OdakDbContext _context;
        public YayinController(OdakDbContext context) { _context = context; }

        public async Task<IActionResult> Kitaplar()
        {
            var yayin = await _context.Yayinlar.Where(y => y.Aktif && y.YayinTuru == "Kitap").OrderByDescending(y => y.YayinTarihi).ToListAsync();
            return View(yayin);
        }

        public async Task<IActionResult> Raporlar()
        {
            var yayin = await _context.Yayinlar.Where(y => y.Aktif && y.YayinTuru == "Rapor").OrderByDescending(y => y.YayinTarihi).ToListAsync();
            return View(yayin);
        }

        public async Task<IActionResult> Makaleler()
        {
            var yayin = await _context.Yayinlar.Where(y => y.Aktif && y.YayinTuru == "Makale").OrderByDescending(y => y.YayinTarihi).ToListAsync();
            return View(yayin);
        }

        public async Task<IActionResult> Bultenler()
        {
            var yayin = await _context.Yayinlar.Where(y => y.Aktif && y.YayinTuru == "Bulten").OrderByDescending(y => y.YayinTarihi).ToListAsync();
            return View(yayin);
        }
    }
}
