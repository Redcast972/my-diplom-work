using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllCourses.Migrations
{
    /// <inheritdoc />
    public partial class Added_Access_To_Teaching : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "ApplicationsForTeaching",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationsForTeaching", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseCategoryTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseCategoryType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursePriceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CoursePriceType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePriceTypes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c0eff69-b00a-49ba-b093-2e9e974828f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41eda725-69bd-462d-a2fa-68119caa282f", "AQAAAAIAAYagAAAAEJP/QR/BDGWl6CCySASpVso+tppGD9kXlxv+qyxFfJfyuvr0DaMcHkccodJGI+ayLg==", "a531aa80-bfe8-4aae-8f0f-6efe5536d119" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef26d68c-2299-407b-a953-a8a63dda5f5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "075d4c6e-d753-4a80-8ce2-2d372ab4fc21", "AQAAAAIAAYagAAAAEKiIlmyI+dnqHb8VwSKqDuRk0qiM3dxVZXp+JvzlikGataEOizpTF2c1bxAfEx1ohQ==", "ed3f102b-5b03-4f38-916b-3aebb4148eaf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationsForTeaching");

            migrationBuilder.DropTable(
                name: "CourseCategoryTypes");

            migrationBuilder.DropTable(
                name: "CoursePriceTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c0eff69-b00a-49ba-b093-2e9e974828f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4f043a4-5efd-4a2d-91e6-a5f7303b97b1", "AQAAAAIAAYagAAAAEGILhgclfCbEBwH+bLqmmVVuLE1DKOGU09rHdS+TwX7vGbaIuAt4CMEJuUX5NV9Bvg==", "8227f1a5-2457-48e5-961d-e51151a6cc87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef26d68c-2299-407b-a953-a8a63dda5f5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f463c497-27ba-4f96-b983-fb964f9ba8f1", "AQAAAAIAAYagAAAAEP9Qb+yBq7haOBpNFxLT8UyAdmi+oQrMqp9TR4A5duD/4M6qhhDsKIyliX5mlf1J2Q==", "49f95099-1d40-4062-99ee-6ab6ea2cbaa9" });
        }
    }
}
