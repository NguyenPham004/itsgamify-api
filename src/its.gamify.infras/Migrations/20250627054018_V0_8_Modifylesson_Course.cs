using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_8_Modifylesson_Course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Medias",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Lesson",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Lesson",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IntroVideoId",
                table: "Course",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Course",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ThumbnailImageId",
                table: "Course",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "IntroVideoId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageId",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Lesson",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Medias",
                table: "Course",
                type: "text[]",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7602), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7602) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7589), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7590) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7077), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7079) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7621), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7622) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7619), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7619) });
        }
    }
}
