using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_Update_Question : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Question",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5884), new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5884) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5873), new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5148), new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5889), new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5887), new DateTime(2025, 8, 16, 19, 39, 16, 952, DateTimeKind.Utc).AddTicks(5887) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Question");

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
    }
}
