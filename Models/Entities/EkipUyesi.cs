using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class EkipUyesi
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; } = string.Empty;
        [MaxLength(150)]
        [Display(Name = "Gorev")]
        public string? Gorev { get; set; }
        [MaxLength(150)]
        [Display(Name = "Birim")]
        public string? Birim { get; set; }
        [MaxLength(500)]
        [Display(Name = "Fotograf Yolu")]
        public string? FotografYolu { get; set; }
        [MaxLength(500)]
        [Display(Name = "LinkedIn URL")]
        public string? LinkedInUrl { get; set; }
        [MaxLength(500)]
        [Display(Name = "Twitter URL")]
        public string? TwitterUrl { get; set; }
        [MaxLength(200)]
        [Display(Name = "E-posta")]
        public string? Email { get; set; }
        [Display(Name = "Sira")]
        public int Sira { get; set; } = 0;
        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
    }
}
