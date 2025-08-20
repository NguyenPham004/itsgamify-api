using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V3_Update_RoomUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1038), new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1038) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(960), new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 264, DateTimeKind.Utc).AddTicks(6791), new DateTime(2025, 8, 19, 10, 41, 24, 264, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1055), new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1047), new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1048) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8536), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8536) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8523), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(7773), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(7776) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8543), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8543) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8539), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8540) });
        }
    }
}
