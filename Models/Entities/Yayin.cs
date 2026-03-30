using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class Yayin
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        [Display(Name = "Baslik")]
        public string Baslik { get; set; } = string.Empty;
        [Display(Name = "Aciklama")]
        public string? Aciklama { get; set; }
        [Required, MaxLength(50)]
        [Display(Name = "Yayin Turu")]
        public string YayinTuru { get; set; } = string.Empty;
        [MaxLength(500)]
        [Display(Name = "Gorsel Yolu")]
        public string? GorselYolu { get; set; }
        [MaxLength(500)]
        [Display(Name = "Dosya Yolu")]
        public string? DosyaYolu { get; set; }
        [MaxLength(500)]
        [Display(Name = "Dis Link")]
        public string? DisLink { get; set; }
        [Display(Name = "Yayin Tarihi")]
        public DateTime? YayinTarihi { get; set; }
        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
        [Display(Name = "Olusturulma Tarihi")]
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
    }
}
