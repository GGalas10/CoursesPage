using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.API.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_topics_TopicId",
                table: "lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_topics_Courses_CourseId",
                table: "topics");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "topics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedPassword_Value",
                table: "Password",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "TopicId",
                table: "lessons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryCourse",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCourse", x => new { x.CategoriesId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CategoryCourse_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCourse_CourseId",
                table: "CategoryCourse",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_topics_TopicId",
                table: "lessons",
                column: "TopicId",
                principalTable: "topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_topics_Courses_CourseId",
                table: "topics",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_topics_TopicId",
                table: "lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_topics_Courses_CourseId",
                table: "topics");

            migrationBuilder.DropTable(
                name: "CategoryCourse");

            migrationBuilder.DropColumn(
                name: "NormalizedPassword_Value",
                table: "Password");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "topics",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TopicId",
                table: "lessons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_topics_TopicId",
                table: "lessons",
                column: "TopicId",
                principalTable: "topics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_topics_Courses_CourseId",
                table: "topics",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
