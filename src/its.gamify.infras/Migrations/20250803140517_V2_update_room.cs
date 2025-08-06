using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V2_update_room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HostScore",
                table: "Room",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpponentScore",
                table: "Room",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 3, 14, 5, 16, 333, DateTimeKind.Utc).AddTicks(34), new DateTime(2025, 8, 3, 14, 5, 16, 333, DateTimeKind.Utc).AddTicks(35) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 3, 14, 5, 16, 333, DateTimeKind.Utc).AddTicks(17), new DateTime(2025, 8, 3, 14, 5, 16, 333, DateTimeKind.Utc).AddTicks(18) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 3, 14, 5, 16, 332, DateTimeKind.Utc).AddTicks(9147), new DateTime(2025, 8, 3, 14, 5, 16, 332, DateTimeKind.Utc).AddTicks(9170) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 3, 14, 5, 16, 333, DateTimeKind.Utc).AddTicks(42), new DateTime(2025, 8, 3, 14, 5, 16, 333, DateTimeKind.Utc).AddTicks(42) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 3, 14, 5, 16, 333, DateTimeKind.Utc).AddTicks(38), new DateTime(2025, 8, 3, 14, 5, 16, 333, DateTimeKind.Utc).AddTicks(39) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostScore",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "OpponentScore",
                table: "Room");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 1, 14, 38, 40, 345, DateTimeKind.Utc).AddTicks(490), new DateTime(2025, 8, 1, 14, 38, 40, 345, DateTimeKind.Utc).AddTicks(490) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 1, 14, 38, 40, 345, DateTimeKind.Utc).AddTicks(464), new DateTime(2025, 8, 1, 14, 38, 40, 345, DateTimeKind.Utc).AddTicks(465) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 1, 14, 38, 40, 344, DateTimeKind.Utc).AddTicks(9055), new DateTime(2025, 8, 1, 14, 38, 40, 344, DateTimeKind.Utc).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 1, 14, 38, 40, 345, DateTimeKind.Utc).AddTicks(500), new DateTime(2025, 8, 1, 14, 38, 40, 345, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 1, 14, 38, 40, 345, DateTimeKind.Utc).AddTicks(495), new DateTime(2025, 8, 1, 14, 38, 40, 345, DateTimeKind.Utc).AddTicks(496) });
        }
    }
}
