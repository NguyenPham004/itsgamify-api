using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V3_update_lesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFiles",
                table: "Lesson",
                type: "json",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(2499), new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(2499) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(2471), new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(2472) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(694), new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(771) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(2507), new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(2507) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(2503), new DateTime(2025, 7, 11, 18, 52, 24, 145, DateTimeKind.Utc).AddTicks(2503) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFiles",
                table: "Lesson");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3876), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3877) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3864), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3864) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3111), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3114) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3882), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3882) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3880), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3880) });
        }
    }
}
