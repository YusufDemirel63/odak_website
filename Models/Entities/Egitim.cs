using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class Egitim
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; } = string.Empty;
        [Display(Name = "Kısa Açıklama")]
        public string? Aciklama { get; set; }
        [Display(Name = "Detaylı Açıklama")]
        public string? Detay { get; set; }
        [MaxLength(150)]
        [Display(Name = "Eğitmen")]
        public string? Egitmen { get; set; }
        [MaxLength(50)]
        [Display(Name = "Seviye")]
        public string? Seviye { get; set; }
        [MaxLength(500)]
        [Display(Name = "Görsel Yolu")]
        public string? GorselYolu { get; set; }
        [Display(Name = "Sıra")]
        public int Sira { get; set; } = 0;
        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
    }
}
