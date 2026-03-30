using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class GaleriGorseli
    {
        public int Id { get; set; }
        [Required, MaxLength(500)]
        [Display(Name = "Gorsel Yolu")]
        public string GorselYolu { get; set; } = string.Empty;
        [MaxLength(200)]
        [Display(Name = "Baslik")]
        public string? Baslik { get; set; }
        [MaxLength(200)]
        [Display(Name = "Etkinlik Adi")]
        public string? EtkinlikAdi { get; set; }
        [Display(Name = "Tarih")]
        public DateTime? Tarih { get; set; }
        [Display(Name = "Sira")]
        public int Sira { get; set; } = 0;
        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
    }
}
