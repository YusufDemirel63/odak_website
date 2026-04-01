using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdakMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels_Fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "EkipUyeleri");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "EkipUyeleri");

            migrationBuilder.AddColumn<string>(
                name: "Hakkinda",
                table: "EkipUyeleri",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detay",
                table: "Egitimler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 4,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 5,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 6,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 7,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 8,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 9,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 10,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 11,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 12,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 13,
                column: "Hakkinda",
                value: null);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 14,
                column: "Hakkinda",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hakkinda",
                table: "EkipUyeleri");

            migrationBuilder.DropColumn(
                name: "Detay",
                table: "Egitimler");

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "EkipUyeleri",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "EkipUyeleri",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EkipUyeleri",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "LinkedInUrl", "TwitterUrl" },
                values: new object[] { null, null });
        }
    }
}
