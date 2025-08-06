using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V4_update_room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAbandoned",
                table: "Room",
                newName: "IsOpponentAnswer");

            migrationBuilder.AddColumn<bool>(
                name: "IsHostAnswer",
                table: "Room",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2190), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2149), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(287), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(292) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2205), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2199), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2199) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHostAnswer",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "IsOpponentAnswer",
                table: "Room",
                newName: "IsAbandoned");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1876), new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1876) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1851), new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1852) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1091), new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1094) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1883), new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1883) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1879), new DateTime(2025, 8, 5, 4, 26, 11, 447, DateTimeKind.Utc).AddTicks(1880) });
        }
    }
}
