using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;

namespace OdakMVC.Controllers
{
    public class EgitimController : Controller
    {
        private readonly OdakDbContext _context;
        public EgitimController(OdakDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var egitimler = await _context.Egitimler.Where(e => e.Aktif).OrderBy(e => e.Sira).ToListAsync();
            return View(egitimler);
        }
    }
}
