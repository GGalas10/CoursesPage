using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Courses.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingAccesses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BuyedAt",
                table: "UserCoursesAccesses");

            migrationBuilder.CreateTable(
                name: "PurchasedCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("0151523a-0757-4521-8394-3d85fdab068f"), "Admin", 0 },
                    { new Guid("5cdfdb26-e9d1-46ed-8907-e6db0689f45c"), "Creator", 0 },
                    { new Guid("9cb22635-563b-4c59-b3c6-fff31dab05ed"), "User", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedCourses_CourseId",
                table: "PurchasedCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedCourses_UserId",
                table: "PurchasedCourses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedCourses");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "BuyedAt",
                table: "UserCoursesAccesses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
