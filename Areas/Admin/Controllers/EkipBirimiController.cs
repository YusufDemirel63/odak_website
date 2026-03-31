using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class EkipBirimiController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        public EkipBirimiController(OdakDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
            => View(await _context.EkipBirimleri.OrderBy(b => b.Sira).ToListAsync());

        public IActionResult Ekle() => View(new EkipBirimi());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(EkipBirimi model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.EkipBirimleri.Add(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Birim başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Duzenle(int id)
        {
            var birim = await _context.EkipBirimleri.FindAsync(id);
            if (birim == null) return NotFound();
            return View(birim);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, EkipBirimi model)
        {
            if (id != model.Id) return NotFound();
            if (!ModelState.IsValid) return View(model);
            
            _context.EkipBirimleri.Update(model);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Birim başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            var b = await _context.EkipBirimleri.FindAsync(id);
            if (b != null) {
                // Check if any ekip uyesi is bound to this unit
                var hasMembers = await _context.EkipUyeleri.AnyAsync(e => e.EkipBirimiId == id);
                if (hasMembers) {
                    TempData["Hata"] = "Bu birime bağlı personel bulunduğu için silinemez. Önce personelleri başka birime aktarın.";
                    return RedirectToAction("Index");
                }
                _context.EkipBirimleri.Remove(b); 
                await _context.SaveChangesAsync(); 
                TempData["Mesaj"] = "Birim başarıyla silindi.";
            }
            return RedirectToAction("Index");
        }
    }
}
