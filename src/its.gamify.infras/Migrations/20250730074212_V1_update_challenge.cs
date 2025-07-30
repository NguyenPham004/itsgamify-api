using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V1_update_challenge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_Course_CourseId",
                table: "Challenge");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Challenge",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ThumbnailImageId",
                table: "Challenge",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));


            migrationBuilder.CreateIndex(
                name: "IX_Challenge_CategoryId",
                table: "Challenge",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_Category_CategoryId",
                table: "Challenge",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_Course_CourseId",
                table: "Challenge",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_Category_CategoryId",
                table: "Challenge");

            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_Course_CourseId",
                table: "Challenge");

            migrationBuilder.DropIndex(
                name: "IX_Challenge_CategoryId",
                table: "Challenge");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Challenge");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageId",
                table: "Challenge");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_Course_CourseId",
                table: "Challenge",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
