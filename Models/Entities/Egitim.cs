using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class Egitim
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        [Display(Name = "Baslik")]
        public string Baslik { get; set; } = string.Empty;
        [Display(Name = "Aciklama")]
        public string? Aciklama { get; set; }
        [MaxLength(150)]
        [Display(Name = "Egitmen")]
        public string? Egitmen { get; set; }
        [MaxLength(50)]
        [Display(Name = "Seviye")]
        public string? Seviye { get; set; }
        [MaxLength(500)]
        [Display(Name = "Gorsel Yolu")]
        public string? GorselYolu { get; set; }
        [Display(Name = "Sira")]
        public int Sira { get; set; } = 0;
        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
        [Display(Name = "Olusturulma Tarihi")]
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
    }
}
