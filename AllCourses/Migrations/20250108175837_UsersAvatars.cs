using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllCourses.Migrations
{
    /// <inheritdoc />
    public partial class UsersAvatars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersAvatars",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    ImageData = table.Column<byte[]>(type: "bytea", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAvatars", x => x.ImageId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4", null, "student", "STUDENT" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersAvatars");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "user", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c0eff69-b00a-49ba-b093-2e9e974828f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d5096ab-441c-4578-93a5-fab2b6d94bda", "AQAAAAIAAYagAAAAEDpvwCWY6nwKPuAkBr35TIrqxVysdpu1V+3cL4zY4kPlXO4G4Lay6UXovBS9CADARQ==", "4f4a3437-cd5d-48c8-b052-42de5de2cad2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef26d68c-2299-407b-a953-a8a63dda5f5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29cc7a80-3dff-4d79-b538-8a9b17b031fb", "AQAAAAIAAYagAAAAEFooek+ztt5J4L+Aumn4SH+YYRZ5o+4koY2UIXMwlch4KcntVrbVhDyBro5L/l15BA==", "309408bb-3bbe-4fb1-ac14-46f4c0476494" });
        }
    }
}
