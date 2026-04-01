using System.ComponentModel.DataAnnotations;
namespace OdakMVC.Models.Entities
{
    public class EkipUyesi
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; } = string.Empty;
        [MaxLength(150)]
        [Display(Name = "Görev")]
        public string? Gorev { get; set; }
        [Display(Name = "Hiyerarşi Kademesi (1:Başkan, 2:Başkan Yrd/Sekreter, 3:Yönetim, 4:Birim Personeli)")]
        public int HiyerarsiKademesi { get; set; } = 4;

        [Display(Name = "Bağlı Olduğu Birim")]
        public int? EkipBirimiId { get; set; }
        public virtual EkipBirimi? EkipBirimi { get; set; }
        [MaxLength(500)]
        [Display(Name = "Fotoğraf Yolu")]
        public string? FotografYolu { get; set; }
        [MaxLength(200)]
        [Display(Name = "E-posta")]
        public string? Email { get; set; }
        [Display(Name = "Hakkında")]
        [MaxLength(3000)]
        public string? Hakkinda { get; set; }
        [Display(Name = "Sıra")]
        public int Sira { get; set; } = 0;
        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
    }
}
