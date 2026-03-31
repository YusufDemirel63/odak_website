using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class IletisimController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        public IletisimController(OdakDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
            => View(await _context.IletisimMesajlari.OrderByDescending(m => m.GonderimTarihi).ToListAsync());

        public async Task<IActionResult> Detay(int id)
        {
            var mesaj = await _context.IletisimMesajlari.FindAsync(id);
            if (mesaj == null) return NotFound();
            mesaj.Okundu = true;
            await _context.SaveChangesAsync();
            return View(mesaj);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            var m = await _context.IletisimMesajlari.FindAsync(id);
            if (m != null) { _context.IletisimMesajlari.Remove(m); await _context.SaveChangesAsync(); }
            TempData["Mesaj"] = "Mesaj silindi.";
            return RedirectToAction("Index");
        }
    }
}

