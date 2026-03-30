using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class SliderGorseli
    {
        public int Id { get; set; }
        [Required, MaxLength(500)]
        [Display(Name = "Gorsel Yolu")]
        public string GorselYolu { get; set; } = string.Empty;
        [MaxLength(200)]
        [Display(Name = "Baslik")]
        public string? Baslik { get; set; }
        [Display(Name = "Siralama")]
        public int Siralama { get; set; } = 0;
        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
    }
}
