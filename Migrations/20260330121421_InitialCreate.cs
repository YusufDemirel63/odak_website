using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OdakMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Egitimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Egitmen = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Seviye = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GorselYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Sira = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitimler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EkipUyeleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gorev = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Birim = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FotografYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sira = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkipUyeleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Saat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Konum = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AfisGorseli = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaleriGorselleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorselYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EtkinlikAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sira = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriGorselleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IletisimMesajlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GonderimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Okundu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimMesajlari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SliderGorselleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorselYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Siralama = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderGorselleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yayinlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YayinTuru = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GorselYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DosyaYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DisLink = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    YayinTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yayinlar", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EkipUyeleri",
                columns: new[] { "Id", "AdSoyad", "Aktif", "Birim", "Email", "FotografYolu", "Gorev", "LinkedInUrl", "Sira", "TwitterUrl" },
                values: new object[,]
                {
                    { 1, "Enes SELCUK", true, "Yonetim", null, null, "Kulup Baskani", null, 1, null },
                    { 2, "Mustafa TUTAR", true, "Yonetim", null, null, "Baskan Yardimcisi", null, 2, null },
                    { 3, "Yusuf EKINCI", true, "Yonetim", null, null, "Genel Sekreter", null, 3, null },
                    { 4, "Abdulkadir ELTER", true, "Etkinlik Organizasyon", null, null, "Yonetim Kurulu Uyesi", null, 4, null },
                    { 5, "Yusuf DEMIREL", true, "Medya ve Iletisim", null, null, "Yonetim Kurulu Uyesi", null, 5, null },
                    { 6, "Ali ERDINE", true, "Etkinlik Organizasyon", null, null, "Yonetim Kurulu Uyesi", null, 6, null },
                    { 7, "Ali EKBER", true, "Egitim ve Yayin", null, null, "Yonetim Kurulu Uyesi", null, 7, null },
                    { 8, "Muhammet Ali KOKYILDIRIM", true, "Insan Kaynaklari", null, null, "Yonetim Kurulu Uyesi", null, 8, null },
                    { 9, "Ishak ARIKAN", true, "Medya ve Iletisim", null, null, "Yonetim Kurulu Uyesi", null, 9, null },
                    { 10, "Ali KARA", true, "Medya ve Iletisim", null, null, "Yonetim Kurulu Uyesi", null, 10, null },
                    { 11, "Fatih Kaan KURT", true, "Yonetim", null, null, "Yonetim Kurulu Uyesi", null, 11, null }
                });

            migrationBuilder.InsertData(
                table: "Etkinlikler",
                columns: new[] { "Id", "Aciklama", "AfisGorseli", "Aktif", "Baslik", "Konum", "OlusturulmaTarihi", "Saat", "Tarih" },
                values: new object[] { 1, "Odak Dusunce Kulubu olarak duzenledigimiz bu programda insan ve insan otesi kavramlari ele alinacak.", "/gorseller/insan-programi/1.png", true, "Insan ve Insan Otesi Programi", "Beyaz Bilgi Kitap Kahve", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "19:30 - 21:30", null });

            migrationBuilder.InsertData(
                table: "SliderGorselleri",
                columns: new[] { "Id", "Aktif", "Baslik", "GorselYolu", "Siralama" },
                values: new object[,]
                {
                    { 1, true, null, "/gorseller/sliders/1.png", 1 },
                    { 2, true, null, "/gorseller/sliders/2.png", 2 },
                    { 3, true, null, "/gorseller/sliders/3.png", 3 },
                    { 4, true, null, "/gorseller/sliders/4.png", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Egitimler");

            migrationBuilder.DropTable(
                name: "EkipUyeleri");

            migrationBuilder.DropTable(
                name: "Etkinlikler");

            migrationBuilder.DropTable(
                name: "GaleriGorselleri");

            migrationBuilder.DropTable(
                name: "IletisimMesajlari");

            migrationBuilder.DropTable(
                name: "SliderGorselleri");

            migrationBuilder.DropTable(
                name: "Yayinlar");
        }
    }
}
