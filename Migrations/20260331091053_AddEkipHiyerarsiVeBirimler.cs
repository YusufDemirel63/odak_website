using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OdakMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddEkipHiyerarsiVeBirimler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birim",
                table: "EkipUyeleri");

            migrationBuilder.AddColumn<int>(
                name: "EkipBirimiId",
                table: "EkipUyeleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HiyerarsiKademesi",
                table: "EkipUyeleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EkipBirimleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sira = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkipBirimleri", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EkipBirimleri",
                columns: new[] { "Id", "Aciklama", "Ad", "Aktif", "Icon", "Sira" },
                values: new object[,]
                {
                    { 1, "Sosyal Medya, Tasarım", "Medya ve İletişim", true, "fas fa-bullhorn", 1 },
                    { 2, "Program Yönetimi, Organizasyon", "Etkinlik Organizasyon", true, "fas fa-calendar-check", 2 },
                    { 3, "Ar-Ge, İçerik Üretimi", "Eğitim ve Yayın", true, "fas fa-book-reader", 3 },
                    { 4, "Üye Kabul, İlişkiler", "İnsan Kaynakları", true, "fas fa-users-cog", 4 }
                });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdSoyad", "EkipBirimiId", "Gorev", "HiyerarsiKademesi" },
                values: new object[] { "Enes SELÇUK", null, "Kulüp Başkanı", 1 });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EkipBirimiId", "Gorev", "HiyerarsiKademesi", "Sira" },
                values: new object[] { null, "Başkan Yardımcısı", 2, 1 });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AdSoyad", "EkipBirimiId", "HiyerarsiKademesi", "Sira" },
                values: new object[] { "Yusuf EKİNCİ", null, 2, 2 });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AdSoyad", "EkipBirimiId", "Gorev", "HiyerarsiKademesi", "Sira" },
                values: new object[] { "Abdulkadir ELTER", null, "Yönetim Kurulu Üyesi", 3, 1 });

            migrationBuilder.InsertData(
                table: "EkipUyeleri",
                columns: new[] { "Id", "AdSoyad", "Aktif", "EkipBirimiId", "Email", "FotografYolu", "Gorev", "HiyerarsiKademesi", "LinkedInUrl", "Sira", "TwitterUrl" },
                values: new object[,]
                {
                    { 5, "Yusuf DEMİREL", true, null, null, null, "Yönetim Kurulu Üyesi", 3, null, 2, null },
                    { 6, "Ali ERDİNE", true, null, null, null, "Yönetim Kurulu Üyesi", 3, null, 3, null },
                    { 7, "Ali EKBER", true, null, null, null, "Yönetim Kurulu Üyesi", 3, null, 4, null },
                    { 8, "Muhammet Ali KÖKYILDIRIM", true, null, null, null, "Yönetim Kurulu Üyesi", 3, null, 5, null },
                    { 9, "İshak ARIKAN", true, null, null, null, "Yönetim Kurulu Üyesi", 3, null, 6, null },
                    { 10, "Ali KARA", true, null, null, null, "Yönetim Kurulu Üyesi", 3, null, 7, null },
                    { 11, "Yusuf DEMİREL", true, 1, null, null, "Medya Sorumlusu", 4, null, 1, null },
                    { 12, "Yusuf EKİNCİ", true, 2, null, null, "Program Koordinatörü", 4, null, 1, null },
                    { 13, "Mustafa TUTAR", true, 3, null, null, "Ar-Ge", 4, null, 1, null },
                    { 14, "Muhammet Ali KÖKYILDIRIM", true, 4, null, null, "İK Uzmanı", 4, null, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EkipUyeleri_EkipBirimiId",
                table: "EkipUyeleri",
                column: "EkipBirimiId");

            migrationBuilder.AddForeignKey(
                name: "FK_EkipUyeleri_EkipBirimleri_EkipBirimiId",
                table: "EkipUyeleri",
                column: "EkipBirimiId",
                principalTable: "EkipBirimleri",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EkipUyeleri_EkipBirimleri_EkipBirimiId",
                table: "EkipUyeleri");

            migrationBuilder.DropTable(
                name: "EkipBirimleri");

            migrationBuilder.DropIndex(
                name: "IX_EkipUyeleri_EkipBirimiId",
                table: "EkipUyeleri");

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

            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DropColumn(
                name: "EkipBirimiId",
                table: "EkipUyeleri");

            migrationBuilder.DropColumn(
                name: "HiyerarsiKademesi",
                table: "EkipUyeleri");

            migrationBuilder.AddColumn<string>(
                name: "Birim",
                table: "EkipUyeleri",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdSoyad", "Birim", "Gorev" },
                values: new object[] { "Enes SELCUK", "Yonetim", "Kulup Baskani" });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birim", "Gorev", "Sira" },
                values: new object[] { "Yonetim", "Baskan Yardimcisi", 2 });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AdSoyad", "Birim", "Sira" },
                values: new object[] { "Yusuf EKINCI", "Yonetim", 3 });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AdSoyad", "Birim", "Gorev", "Sira" },
                values: new object[] { "Yusuf DEMIREL", "Medya", "Yonetim Kurulu Uyesi", 4 });
        }
    }
}
