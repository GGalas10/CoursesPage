using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.API.Migrations
{
    /// <inheritdoc />
    public partial class AddId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "coursesCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "coursesCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_coursesCategories",
                table: "coursesCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_coursesCarts",
                table: "coursesCarts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_coursesCategories",
                table: "coursesCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_coursesCarts",
                table: "coursesCarts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "coursesCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "coursesCarts");
        }
    }
}
