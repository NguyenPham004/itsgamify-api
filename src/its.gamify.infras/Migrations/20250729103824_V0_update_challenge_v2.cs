using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_update_challenge_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(6101), new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(6101) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(6086), new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(5131), new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(5134) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(6151), new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(6152) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(6105), new DateTime(2025, 7, 29, 10, 38, 22, 961, DateTimeKind.Utc).AddTicks(6105) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(3504), new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(3504) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(3479), new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(2477), new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(3512), new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(3512) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(3509), new DateTime(2025, 7, 29, 10, 33, 50, 754, DateTimeKind.Utc).AddTicks(3509) });
        }
    }
}
