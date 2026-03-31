using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdakMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddSiteAyarVeAdminTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminKullanicilari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminKullanicilari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteAyarlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteBaslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SiteAciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LogoYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FaviconYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WhatsAppNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NSosyal = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FooterAciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteAyarlari", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdminKullanicilari",
                columns: new[] { "Id", "Aktif", "KullaniciAdi", "Sifre" },
                values: new object[] { 1, true, "admin", "Odak@2024!" });

            migrationBuilder.InsertData(
                table: "SiteAyarlari",
                columns: new[] { "Id", "Adres", "Email", "Facebook", "FaviconYolu", "FooterAciklama", "Instagram", "LogoYolu", "NSosyal", "SiteAciklama", "SiteBaslik", "Telefon", "Twitter", "WhatsAppNo", "Youtube" },
                values: new object[] { 1, "Adana, Türkiye", "odakdusuncekulubu@gmail.com", "https://www.facebook.com/people/Odak-Kul%C3%BCb%C3%BC/pfbid0tw6mVHQTte16a38mhcEKpLSfLPZxk76HoAaC59HfS7mTmc8tefmSuUEAmfyNDbVwl/", "/gorseller/OdakLogo.svg", "Zihinsel gelişim ve toplumsal farkındalık için doğru odak noktasındasınız. Bizi takip etmeye devam edin.", "https://www.instagram.com/odakdusuncekulubu/", "/gorseller/OdakLogo.svg", "https://nsosyal.com/odakdusuncekulubu", "Odak Düşünce Kulübü; gençlerin zihinsel gelişimine katkıda bulunan okuma, düşünme, araştırma ve keşfetme odaklı bir sivil toplum inisiyatifidir.", "Odak Düşünce Kulübü | Oku, Düşün, Araştır, Keşfet", "+90 552 272 25 63", "https://x.com/odakdusunceklb", "905522722563", "https://www.youtube.com/@odakdusuncekulubu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminKullanicilari");

            migrationBuilder.DropTable(
                name: "SiteAyarlari");
        }
    }
}
