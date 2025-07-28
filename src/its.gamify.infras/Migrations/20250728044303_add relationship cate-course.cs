using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class addrelationshipcatecourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(4312), new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(4296), new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(4297) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(3147), new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(4453), new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(4454) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(4315), new DateTime(2025, 7, 28, 4, 43, 2, 765, DateTimeKind.Utc).AddTicks(4315) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4181), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4182) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4161), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(2410), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(2421) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4189), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4185), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4186) });
        }
    }
}
