using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_Update_Room_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Room",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6263), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6263) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6251), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6251) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(5505), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6269), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6269) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6266), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6267) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Room");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(7447), new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(7447) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(7432), new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(6599), new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(6602) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(7453), new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(7453) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(7450), new DateTime(2025, 8, 24, 8, 42, 13, 547, DateTimeKind.Utc).AddTicks(7450) });
        }
    }
}
