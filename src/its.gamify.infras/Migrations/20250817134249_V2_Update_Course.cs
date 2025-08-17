using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V2_Update_Course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4733), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4734) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4716), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4717) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(3841), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4739), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4737), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4737) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2878), new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2878) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2863), new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2863) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2127), new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2130) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2884), new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2884) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2882), new DateTime(2025, 8, 17, 12, 2, 7, 997, DateTimeKind.Utc).AddTicks(2882) });
        }
    }
}
