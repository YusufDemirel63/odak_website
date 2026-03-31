using System.ComponentModel.DataAnnotations;

namespace OdakMVC.Models.Entities
{
    public class AdminKullanici
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı zorunludur.")]
        [MaxLength(50)]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MaxLength(250)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; } = string.Empty;

        [Display(Name = "Durum (Aktif/Pasif)")]
        public bool Aktif { get; set; } = true;
    }
}
