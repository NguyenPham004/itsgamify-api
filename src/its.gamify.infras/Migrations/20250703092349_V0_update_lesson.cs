using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_update_lesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Lesson");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6237), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6237) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6223), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6224) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(5440), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(5443) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6243), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6243) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6240), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6240) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Lesson",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(4405), new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(4406) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(4394), new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(3850), new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(3853) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(4413), new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(4413) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(4409), new DateTime(2025, 7, 2, 20, 33, 58, 773, DateTimeKind.Utc).AddTicks(4410) });
        }
    }
}
