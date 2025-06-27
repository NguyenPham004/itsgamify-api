using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_9_Modifylesson_Course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_File_IntroVideoId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_File_ThumbnailImageId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_IntroVideoId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_ThumbnailImageId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "ThumbnailImageId",
                table: "Course",
                newName: "ThumbnailId");

            migrationBuilder.AddColumn<string>(
                name: "IntroVideo",
                table: "Course",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailImage",
                table: "Course",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6674), new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6664), new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6665) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6085), new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6682), new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6682) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6678), new DateTime(2025, 6, 27, 5, 58, 2, 421, DateTimeKind.Utc).AddTicks(6678) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntroVideo",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ThumbnailImage",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "ThumbnailId",
                table: "Course",
                newName: "ThumbnailImageId");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(6048), new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(6048) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(6035), new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(6035) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(5476), new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(5478) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(6054), new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(6055) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(6051), new DateTime(2025, 6, 27, 5, 40, 17, 882, DateTimeKind.Utc).AddTicks(6052) });

            migrationBuilder.CreateIndex(
                name: "IX_Course_IntroVideoId",
                table: "Course",
                column: "IntroVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ThumbnailImageId",
                table: "Course",
                column: "ThumbnailImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_File_IntroVideoId",
                table: "Course",
                column: "IntroVideoId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_File_ThumbnailImageId",
                table: "Course",
                column: "ThumbnailImageId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
