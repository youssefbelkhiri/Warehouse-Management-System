using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "463607b8-0fad-4d2e-9ce3-2bb3a801a8f1", null, "Admin", "ADMIN" },
                    { "6a107be2-5648-4c37-b66e-dac0ec699d98", null, "visiter", "VISITER" },
                    { "8c9e6bea-dbb6-4136-ad0a-70cb0f1c3ad1", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "463607b8-0fad-4d2e-9ce3-2bb3a801a8f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a107be2-5648-4c37-b66e-dac0ec699d98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c9e6bea-dbb6-4136-ad0a-70cb0f1c3ad1");
        }
    }
}
