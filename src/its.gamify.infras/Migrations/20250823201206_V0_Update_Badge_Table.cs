using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_Update_Badge_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimedDate",
                table: "Badge");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Badge",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Badge",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(5622), new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(5622) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(5582), new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(5584) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(2818), new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(2827) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(5645), new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(5646) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(5627), new DateTime(2025, 8, 23, 20, 12, 3, 109, DateTimeKind.Utc).AddTicks(5627) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Badge");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Badge",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClaimedDate",
                table: "Badge",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(6991), new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(6992) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(6972), new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(6973) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(6028), new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(6032) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(7000), new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(6995), new DateTime(2025, 8, 22, 19, 19, 9, 78, DateTimeKind.Utc).AddTicks(6996) });
        }
    }
}
