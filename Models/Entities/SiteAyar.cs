using System.ComponentModel.DataAnnotations;

namespace OdakMVC.Models.Entities
{
    public class SiteAyar
    {
        public int Id { get; set; }

        [MaxLength(200)]
        [Display(Name = "Site Başlığı")]
        public string? SiteBaslik { get; set; }

        [MaxLength(500)]
        [Display(Name = "Site Açıklaması (Description)")]
        public string? SiteAciklama { get; set; }

        [MaxLength(500)]
        [Display(Name = "Ana Logo Yolu")]
        public string? LogoYolu { get; set; }

        [MaxLength(500)]
        [Display(Name = "Favicon Yolu")]
        public string? FaviconYolu { get; set; }

        [MaxLength(200)]
        [Display(Name = "E-posta Adresi")]
        public string? Email { get; set; }

        [MaxLength(50)]
        [Display(Name = "Telefon Numarası")]
        public string? Telefon { get; set; }

        [MaxLength(50)]
        [Display(Name = "WhatsApp Numarası (Sadece rakam)")]
        public string? WhatsAppNo { get; set; }

        [MaxLength(300)]
        [Display(Name = "Açık Adres")]
        public string? Adres { get; set; }

        [MaxLength(300)]
        [Display(Name = "Instagram URL")]
        public string? Instagram { get; set; }

        [MaxLength(300)]
        [Display(Name = "Twitter (X) URL")]
        public string? Twitter { get; set; }

        [MaxLength(300)]
        [Display(Name = "YouTube URL")]
        public string? Youtube { get; set; }

        [MaxLength(300)]
        [Display(Name = "Facebook URL")]
        public string? Facebook { get; set; }

        [MaxLength(300)]
        [Display(Name = "NSosyal URL")]
        public string? NSosyal { get; set; }

        [MaxLength(500)]
        [Display(Name = "Footer Kısa Açıklaması")]
        public string? FooterAciklama { get; set; }
    }
}
