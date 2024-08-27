using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Courses.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableVideo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0151523a-0757-4521-8394-3d85fdab068f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5cdfdb26-e9d1-46ed-8907-e6db0689f45c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9cb22635-563b-4c59-b3c6-fff31dab05ed"));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Video",
                table: "lessons",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("75aef5bf-0f07-4eec-a293-630b53e61311"), "Creator", 0 },
                    { new Guid("b593438c-3cd5-4ae1-ab8e-fb220c712809"), "Admin", 0 },
                    { new Guid("cf052e01-66f4-432e-a336-7fae10d14781"), "User", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75aef5bf-0f07-4eec-a293-630b53e61311"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b593438c-3cd5-4ae1-ab8e-fb220c712809"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cf052e01-66f4-432e-a336-7fae10d14781"));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Video",
                table: "lessons",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("0151523a-0757-4521-8394-3d85fdab068f"), "Admin", 0 },
                    { new Guid("5cdfdb26-e9d1-46ed-8907-e6db0689f45c"), "Creator", 0 },
                    { new Guid("9cb22635-563b-4c59-b3c6-fff31dab05ed"), "User", 0 }
                });
        }
    }
}
