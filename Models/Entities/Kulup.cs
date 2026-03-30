using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class Kulup
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Kulüp Adı")]
        public string Ad { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        [Display(Name = "Ana İkon (FontAwesome)")]
        public string Icon { get; set; } = "fas fa-users"; // fas fa-book-open vs.

        [MaxLength(200)]
        [Display(Name = "Kısa Açıklama (Ana Sayfa)")]
        public string? KisaAciklama { get; set; }

        [Display(Name = "Ara Sayfa Detaylı İçerik")]
        public string? UzunAciklama { get; set; }

        [MaxLength(500)]
        [Display(Name = "Arka Plan Görseli")]
        public string? GorselYolu { get; set; }

        [Display(Name = "Sıra")]
        public int Sira { get; set; } = 0;

        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
    }
}
