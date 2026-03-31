using System.ComponentModel.DataAnnotations;

namespace OdakMVC.Models.Entities
{
    public class EkipBirimi
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Birim adı zorunludur.")]
        [MaxLength(150)]
        [Display(Name = "Birim Adı")]
        public string Ad { get; set; } = string.Empty;

        [MaxLength(250)]
        [Display(Name = "Kısa Açıklama")]
        public string? Aciklama { get; set; }

        [MaxLength(50)]
        [Display(Name = "FontAwesome İkonu (Örn: fas fa-bullhorn)")]
        public string? Icon { get; set; }

        [Display(Name = "Sıra")]
        public int Sira { get; set; } = 0;

        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;

        public virtual ICollection<EkipUyesi> Uyeler { get; set; } = new List<EkipUyesi>();
    }
}
