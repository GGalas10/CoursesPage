using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.API.Migrations
{
    /// <inheritdoc />
    public partial class ReorganizingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coursesCarts_Carts_CartId",
                table: "coursesCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_coursesCarts_Carts_CartId1",
                table: "coursesCarts");

            migrationBuilder.DropIndex(
                name: "IX_coursesCarts_CartId1",
                table: "coursesCarts");

            migrationBuilder.DropColumn(
                name: "CartId1",
                table: "coursesCarts");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "coursesCarts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CartIdForCourses",
                table: "coursesCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_coursesCarts_CartIdForCourses",
                table: "coursesCarts",
                column: "CartIdForCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_coursesCarts_Carts_CartId",
                table: "coursesCarts",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_coursesCarts_Carts_CartIdForCourses",
                table: "coursesCarts",
                column: "CartIdForCourses",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coursesCarts_Carts_CartId",
                table: "coursesCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_coursesCarts_Carts_CartIdForCourses",
                table: "coursesCarts");

            migrationBuilder.DropIndex(
                name: "IX_coursesCarts_CartIdForCourses",
                table: "coursesCarts");

            migrationBuilder.DropColumn(
                name: "CartIdForCourses",
                table: "coursesCarts");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "coursesCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CartId1",
                table: "coursesCarts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_coursesCarts_CartId1",
                table: "coursesCarts",
                column: "CartId1");

            migrationBuilder.AddForeignKey(
                name: "FK_coursesCarts_Carts_CartId",
                table: "coursesCarts",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_coursesCarts_Carts_CartId1",
                table: "coursesCarts",
                column: "CartId1",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
