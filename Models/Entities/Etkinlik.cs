using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class Etkinlik
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        [Display(Name = "Baslik")]
        public string Baslik { get; set; } = string.Empty;
        [Display(Name = "Aciklama")]
        public string? Aciklama { get; set; }
        [Display(Name = "Tarih")]
        public DateTime? Tarih { get; set; }
        [MaxLength(100)]
        [Display(Name = "Saat")]
        public string? Saat { get; set; }
        [MaxLength(300)]
        [Display(Name = "Konum")]
        public string? Konum { get; set; }
        [MaxLength(500)]
        [Display(Name = "Afis Gorseli")]
        public string? AfisGorseli { get; set; }
        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
        [Display(Name = "Olusturulma Tarihi")]
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
    }
}
