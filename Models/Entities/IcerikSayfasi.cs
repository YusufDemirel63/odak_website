using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class IcerikSayfasi
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "Anahtar Kod")]
        public string Anahtar { get; set; } = string.Empty; // Hakkimizda, VizyonMisyon vs.

        [Required, MaxLength(200)]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; } = string.Empty;

        [Required]
        [Display(Name = "İçerik Metni")]
        public string Icerik { get; set; } = string.Empty;

        [MaxLength(500)]
        [Display(Name = "Görsel Yolu")]
        public string? GorselYolu { get; set; }
    }
}
