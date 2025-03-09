using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAtrributesToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07070567-ed86-4a90-ab8c-0afe28d43f34", null, "SuperAdmin", "SUPERADMIN" },
                    { "659e2675-5865-4c9d-be71-76e3e82d9e64", null, "visiter", "VISITER" },
                    { "70ffe268-3a62-4096-be34-0988c2d183ba", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07070567-ed86-4a90-ab8c-0afe28d43f34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "659e2675-5865-4c9d-be71-76e3e82d9e64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70ffe268-3a62-4096-be34-0988c2d183ba");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
