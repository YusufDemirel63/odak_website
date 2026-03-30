using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.ViewModels
{
    public class IletisimFormViewModel
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Gecerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Telefon")]
        public string? Telefon { get; set; }

        [Required(ErrorMessage = "Mesaj zorunludur.")]
        [MinLength(10, ErrorMessage = "Mesaj en az 10 karakter olmalidir.")]
        [Display(Name = "Mesaj")]
        public string Mesaj { get; set; } = string.Empty;
    }
}
