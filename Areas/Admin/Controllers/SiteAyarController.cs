using Microsoft.AspNetCore.Mvc;
using OdakMVC.Data;
using OdakMVC.Models.Entities;

namespace OdakMVC.Areas.Admin.Controllers
{
    public class SiteAyarController : AdminBaseController
    {
        private readonly OdakDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SiteAyarController(OdakDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var ayar = _context.SiteAyarlari.FirstOrDefault();
            if (ayar == null)
            {
                ayar = new SiteAyar();
                _context.SiteAyarlari.Add(ayar);
                _context.SaveChanges();
            }
            return View(ayar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SiteAyar model, IFormFile? logoFile, IFormFile? faviconFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var mevcutAyar = _context.SiteAyarlari.FirstOrDefault();
            if (mevcutAyar == null)
            {
                mevcutAyar = new SiteAyar();
                _context.SiteAyarlari.Add(mevcutAyar);
            }

            if (logoFile != null && logoFile.Length > 0)
            {
                mevcutAyar.LogoYolu = await GorselKaydet(logoFile, "logo_" + Guid.NewGuid().ToString());
            }

            if (faviconFile != null && faviconFile.Length > 0)
            {
                mevcutAyar.FaviconYolu = await GorselKaydet(faviconFile, "favicon_" + Guid.NewGuid().ToString());
            }

            mevcutAyar.SiteBaslik = model.SiteBaslik;
            mevcutAyar.SiteAciklama = model.SiteAciklama;
            mevcutAyar.Email = model.Email;
            mevcutAyar.Telefon = model.Telefon;
            mevcutAyar.WhatsAppNo = model.WhatsAppNo;
            mevcutAyar.Adres = model.Adres;
            mevcutAyar.Instagram = model.Instagram;
            mevcutAyar.Twitter = model.Twitter;
            mevcutAyar.Youtube = model.Youtube;
            mevcutAyar.Facebook = model.Facebook;
            mevcutAyar.NSosyal = model.NSosyal;
            mevcutAyar.FooterAciklama = model.FooterAciklama;

            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Site ayarları başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        private async Task<string> GorselKaydet(IFormFile file, string dosyaAdi)
        {
            var uploads = Path.Combine(_env.WebRootPath, "gorseller", "site");
            Directory.CreateDirectory(uploads);
            
            var uzanti = Path.GetExtension(file.FileName);
            var tamDosyaAdi = dosyaAdi + uzanti;
            var yol = Path.Combine(uploads, tamDosyaAdi);
            
            using var stream = new FileStream(yol, FileMode.Create);
            await file.CopyToAsync(stream);
            
            return $"/gorseller/site/{tamDosyaAdi}";
        }
    }
}
