using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class IletisimMesaji
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; } = string.Empty;
        [Required, MaxLength(200), EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;
        [MaxLength(50)]
        [Display(Name = "Telefon")]
        public string? Telefon { get; set; }
        [Required]
        [Display(Name = "Mesaj")]
        public string Mesaj { get; set; } = string.Empty;
        [Display(Name = "Gonderim Tarihi")]
        public DateTime GonderimTarihi { get; set; } = DateTime.Now;
        [Display(Name = "Okundu")]
        public bool Okundu { get; set; } = false;
    }
}
