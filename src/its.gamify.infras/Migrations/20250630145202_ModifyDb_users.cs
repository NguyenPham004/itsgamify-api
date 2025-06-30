using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDb_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "FullName");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Course",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6993), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6993) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6980), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6418), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6421) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(7001), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6996), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6996) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "User",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(6143), new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(6132), new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(6132) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(5583), new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(5586) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(6147), new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(6147) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(6145), new DateTime(2025, 6, 28, 7, 21, 29, 896, DateTimeKind.Utc).AddTicks(6145) });
        }
    }
}
