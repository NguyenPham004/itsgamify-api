using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V2_update_histories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageCorrect",
                table: "UserChallengeHistory",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6832), new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6821), new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6076), new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6838), new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6835), new DateTime(2025, 8, 12, 7, 53, 52, 439, DateTimeKind.Utc).AddTicks(6836) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageCorrect",
                table: "UserChallengeHistory");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(6454), new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(6454) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(6442), new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(6443) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(5733), new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(5736) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(6471), new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(6471) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(6457), new DateTime(2025, 8, 11, 17, 8, 41, 716, DateTimeKind.Utc).AddTicks(6457) });
        }
    }
}
