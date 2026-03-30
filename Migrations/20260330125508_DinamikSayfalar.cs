using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OdakMVC.Migrations
{
    /// <inheritdoc />
    public partial class DinamikSayfalar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.CreateTable(
                name: "IcerikSayfalari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anahtar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GorselYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcerikSayfalari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kulupler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KisaAciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UzunAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GorselYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Sira = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kulupler", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AdSoyad", "Birim" },
                values: new object[] { "Yusuf DEMIREL", "Medya" });

            migrationBuilder.UpdateData(
                table: "Etkinlikler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Aciklama",
                value: "Odak Dusunce Kulubu olarak duzenledigimiz programda insan...");

            migrationBuilder.InsertData(
                table: "IcerikSayfalari",
                columns: new[] { "Id", "Anahtar", "Baslik", "GorselYolu", "Icerik" },
                values: new object[,]
                {
                    { 1, "Hakkimizda", "Biz Kimiz?", "/gorseller/about.jpg", "Odak Düsünce Kulübü, 2024 yilinda bir grup idealist genç tarafindan kurulmus bir sivil toplum inisiyatifidir. Amacimiz, bilgi kirliliginin arttigi günümüzde, gençlerin dogru bilgiye ulasmasini saglamak ve onlari toplumsal meselelerde söz sahibi yapmaktir.\n\nOdak; yalnizca bilgi üretmeyi degil, anlam üretimini esas alir. Insanin kendini, çevresini ve dogayi tanima serüvenine eslik eden bu topluluk, ögrenmeyi bireysel bir süreçten çikarip kolektif bir anlam arayisina dönüstürmeyi hedefler." },
                    { 2, "Vizyon", "Vizyonumuz", null, "Okuyan, düsünen, arastiran ve kesfeden; zihinsel bagimsizligini kazanmis, toplumsal farkindaliga sahip bireylerden olusan güçlü bir sivil toplum inisiyatifi olmak." },
                    { 3, "Misyon", "Misyonumuz", null, "Gençlere dogru bilgiye ulasma, elestirel düsünme ve toplumsal meselelerde söz sahibi olma imkani sunmak; okuma, arastirma ve etkinliklerle kisisel ve toplumsal gelisime katkida bulunmak." },
                    { 4, "NedenOdak", "Neden ODAK?", null, "Çünkü her yolculuk bir arayisla baslar; biz de kendimizi, çevremizi ve çagimizi yeniden anlamak arzusuyla yola çiktik. Odak, kendini tanima ve içsel yolculuga çikma ihtiyacinin ortak bulusma noktasidir.\n\nDikkatimizi dagitan, bizi kendimizden uzaklastiran çeldiricilerin ortasinda, yeniden odaklanma çabamizin ifadesiyiz." }
                });

            migrationBuilder.InsertData(
                table: "Kulupler",
                columns: new[] { "Id", "Ad", "Aktif", "GorselYolu", "Icon", "KisaAciklama", "Sira", "UzunAciklama" },
                values: new object[,]
                {
                    { 1, "Oku", true, null, "fas fa-book-open", "Dünyayi ve insanligi anlamak için nitelikli kaynaklarla zihnimizi besliyoruz.", 1, "Oku kulübümüz, bilgiye ulasmanin degil, anlami kavramanin pesindedir. Her ay belirlenen kitaplarla zihinlerimizi besliyoruz." },
                    { 2, "Düsün", true, null, "fas fa-brain", "Ezberleri bozuyor, elestirel düsünce ile olaylara farkli açilardan bakiyoruz.", 2, "Sorgulamadan kabul etme devrini kapatmak için bir araya geliyoruz. Felsefe, teoloji ve ideolojiler üzerine derin atölyeler yapiyoruz." },
                    { 3, "Arastir", true, null, "fas fa-microscope", "Bilginin kaynagina iniyor, veriye dayali analizler yapiyoruz.", 3, "Bilimsel metodolojiler isiginda, toplumsal ve global olaylari inceliyor, raporluyoruz." },
                    { 4, "Kesfet", true, null, "fas fa-compass", "Ögrendiklerimizi hayata geçiriyor, yeni yetenekler ve dünyalar kesfediyoruz.", 4, "Sadece teoride kalmiyor. Sahada, müzelerde, köylerde geziyoruz. Yepyeni hobilerle becerilerimizi gelistiriyoruz." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcerikSayfalari");

            migrationBuilder.DropTable(
                name: "Kulupler");

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AdSoyad", "Birim" },
                values: new object[] { "Abdulkadir ELTER", "Etkinlik Organizasyon" });

            migrationBuilder.InsertData(
                table: "EkipUyeleri",
                columns: new[] { "Id", "AdSoyad", "Aktif", "Birim", "Email", "FotografYolu", "Gorev", "LinkedInUrl", "Sira", "TwitterUrl" },
                values: new object[,]
                {
                    { 5, "Yusuf DEMIREL", true, "Medya ve Iletisim", null, null, "Yonetim Kurulu Uyesi", null, 5, null },
                    { 6, "Ali ERDINE", true, "Etkinlik Organizasyon", null, null, "Yonetim Kurulu Uyesi", null, 6, null },
                    { 7, "Ali EKBER", true, "Egitim ve Yayin", null, null, "Yonetim Kurulu Uyesi", null, 7, null },
                    { 8, "Muhammet Ali KOKYILDIRIM", true, "Insan Kaynaklari", null, null, "Yonetim Kurulu Uyesi", null, 8, null },
                    { 9, "Ishak ARIKAN", true, "Medya ve Iletisim", null, null, "Yonetim Kurulu Uyesi", null, 9, null },
                    { 10, "Ali KARA", true, "Medya ve Iletisim", null, null, "Yonetim Kurulu Uyesi", null, 10, null },
                    { 11, "Fatih Kaan KURT", true, "Yonetim", null, null, "Yonetim Kurulu Uyesi", null, 11, null }
                });

            migrationBuilder.UpdateData(
                table: "Etkinlikler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Aciklama",
                value: "Odak Dusunce Kulubu olarak duzenledigimiz bu programda insan ve insan otesi kavramlari ele alinacak.");
        }
    }
}
