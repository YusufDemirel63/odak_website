using Microsoft.AspNetCore.Mvc;
using OdakMVC.Data;

namespace OdakMVC.Controllers
{
    public class KuluplerController : Controller
    {
        private readonly OdakDbContext _context;

        public KuluplerController(OdakDbContext context)
        {
            _context = context;
        }

        public IActionResult Detay(int id)
        {
            var kulup = _context.Kulupler.FirstOrDefault(k => k.Id == id && k.Aktif);
            if (kulup == null) return NotFound();
            return View("Detay", kulup);
        }
    }
}
