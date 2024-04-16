using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Courses.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeedForRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("797530de-5d5e-4089-a98c-f0387482c1d4"), "Creator", 0 },
                    { new Guid("bd880af8-25aa-4570-b264-bdf260a45799"), "User", 0 },
                    { new Guid("ff904d8a-f1f3-4415-836d-dac0376296d4"), "Admin", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("797530de-5d5e-4089-a98c-f0387482c1d4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bd880af8-25aa-4570-b264-bdf260a45799"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ff904d8a-f1f3-4415-836d-dac0376296d4"));
        }
    }
}
