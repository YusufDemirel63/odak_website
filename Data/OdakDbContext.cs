using Microsoft.EntityFrameworkCore;
using OdakMVC.Models.Entities;

namespace OdakMVC.Data
{
    public class OdakDbContext : DbContext
    {
        public OdakDbContext(DbContextOptions<OdakDbContext> options) : base(options) { }

        public DbSet<Etkinlik> Etkinlikler { get; set; }
        public DbSet<Egitim> Egitimler { get; set; }
        public DbSet<EkipUyesi> EkipUyeleri { get; set; }
        public DbSet<Yayin> Yayinlar { get; set; }
        public DbSet<SliderGorseli> SliderGorselleri { get; set; }
        public DbSet<IletisimMesaji> IletisimMesajlari { get; set; }
        public DbSet<GaleriGorseli> GaleriGorselleri { get; set; }
        public DbSet<Kulup> Kulupler { get; set; }
        public DbSet<IcerikSayfasi> IcerikSayfalari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DB Seed Data...
            modelBuilder.Entity<SliderGorseli>().HasData(
                new SliderGorseli { Id = 1, GorselYolu = "/gorseller/sliders/1.png", Siralama = 1, Aktif = true },
                new SliderGorseli { Id = 2, GorselYolu = "/gorseller/sliders/2.png", Siralama = 2, Aktif = true },
                new SliderGorseli { Id = 3, GorselYolu = "/gorseller/sliders/3.png", Siralama = 3, Aktif = true },
                new SliderGorseli { Id = 4, GorselYolu = "/gorseller/sliders/4.png", Siralama = 4, Aktif = true }
            );

            // Icerik Sayfalari Seed
            modelBuilder.Entity<IcerikSayfasi>().HasData(
                new IcerikSayfasi {
                    Id = 1,
                    Anahtar = "Hakkimizda",
                    Baslik = "Biz Kimiz?",
                    Icerik = "Odak Düsünce Kulübü, 2024 yilinda bir grup idealist genç tarafindan kurulmus bir sivil toplum inisiyatifidir. Amacimiz, bilgi kirliliginin arttigi günümüzde, gençlerin dogru bilgiye ulasmasini saglamak ve onlari toplumsal meselelerde söz sahibi yapmaktir.\n\nOdak; yalnizca bilgi üretmeyi degil, anlam üretimini esas alir. Insanin kendini, çevresini ve dogayi tanima serüvenine eslik eden bu topluluk, ögrenmeyi bireysel bir süreçten çikarip kolektif bir anlam arayisina dönüstürmeyi hedefler.",
                    GorselYolu = "/gorseller/about.jpg"
                },
                new IcerikSayfasi { Id=2, Anahtar="Vizyon", Baslik="Vizyonumuz", Icerik="Okuyan, düsünen, arastiran ve kesfeden; zihinsel bagimsizligini kazanmis, toplumsal farkindaliga sahip bireylerden olusan güçlü bir sivil toplum inisiyatifi olmak." },
                new IcerikSayfasi { Id=3, Anahtar="Misyon", Baslik="Misyonumuz", Icerik="Gençlere dogru bilgiye ulasma, elestirel düsünme ve toplumsal meselelerde söz sahibi olma imkani sunmak; okuma, arastirma ve etkinliklerle kisisel ve toplumsal gelisime katkida bulunmak." },
                new IcerikSayfasi { Id=4, Anahtar="NedenOdak", Baslik="Neden ODAK?", Icerik="Çünkü her yolculuk bir arayisla baslar; biz de kendimizi, çevremizi ve çagimizi yeniden anlamak arzusuyla yola çiktik. Odak, kendini tanima ve içsel yolculuga çikma ihtiyacinin ortak bulusma noktasidir.\n\nDikkatimizi dagitan, bizi kendimizden uzaklastiran çeldiricilerin ortasinda, yeniden odaklanma çabamizin ifadesiyiz." }
            );

            // Kulupler Seed
            modelBuilder.Entity<Kulup>().HasData(
                new Kulup { Id = 1, Ad = "Oku", Icon = "fas fa-book-open", KisaAciklama="Dünyayi ve insanligi anlamak için nitelikli kaynaklarla zihnimizi besliyoruz.", UzunAciklama="Oku kulübümüz, bilgiye ulasmanin degil, anlami kavramanin pesindedir. Her ay belirlenen kitaplarla zihinlerimizi besliyoruz.", Sira = 1, Aktif = true },
                new Kulup { Id = 2, Ad = "Düsün", Icon = "fas fa-brain", KisaAciklama="Ezberleri bozuyor, elestirel düsünce ile olaylara farkli açilardan bakiyoruz.", UzunAciklama="Sorgulamadan kabul etme devrini kapatmak için bir araya geliyoruz. Felsefe, teoloji ve ideolojiler üzerine derin atölyeler yapiyoruz.", Sira = 2, Aktif = true },
                new Kulup { Id = 3, Ad = "Arastir", Icon = "fas fa-microscope", KisaAciklama="Bilginin kaynagina iniyor, veriye dayali analizler yapiyoruz.", UzunAciklama="Bilimsel metodolojiler isiginda, toplumsal ve global olaylari inceliyor, raporluyoruz.", Sira = 3, Aktif = true },
                new Kulup { Id = 4, Ad = "Kesfet", Icon = "fas fa-compass", KisaAciklama="Ögrendiklerimizi hayata geçiriyor, yeni yetenekler ve dünyalar kesfediyoruz.", UzunAciklama="Sadece teoride kalmiyor. Sahada, müzelerde, köylerde geziyoruz. Yepyeni hobilerle becerilerimizi gelistiriyoruz.", Sira = 4, Aktif = true }
            );

            // Daha önceki veriler (kisa tutuldu seed limitinden)
            modelBuilder.Entity<Etkinlik>().HasData(
                new Etkinlik { Id = 1, Baslik = "Insan ve Insan Otesi Programi", Aciklama = "Odak Dusunce Kulubu olarak duzenledigimiz programda insan...", Saat = "19:30 - 21:30", Konum = "Beyaz Bilgi Kitap Kahve", AfisGorseli = "/gorseller/insan-programi/1.png", Aktif = true, OlusturulmaTarihi = new DateTime(2026, 1, 1) }
            );

            modelBuilder.Entity<EkipUyesi>().HasData(
                new EkipUyesi { Id = 1, AdSoyad = "Enes SELCUK", Gorev = "Kulup Baskani", Birim = "Yonetim", Sira = 1, Aktif = true },
                new EkipUyesi { Id = 2, AdSoyad = "Mustafa TUTAR", Gorev = "Baskan Yardimcisi", Birim = "Yonetim", Sira = 2, Aktif = true },
                new EkipUyesi { Id = 3, AdSoyad = "Yusuf EKINCI", Gorev = "Genel Sekreter", Birim = "Yonetim", Sira = 3, Aktif = true },
                new EkipUyesi { Id = 4, AdSoyad = "Yusuf DEMIREL", Gorev = "Yonetim Kurulu Uyesi", Birim = "Medya", Sira = 4, Aktif = true }
            );
        }
    }
}
