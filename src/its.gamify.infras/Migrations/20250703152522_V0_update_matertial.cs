using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_update_matertial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "LearningMaterial",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "LearningMaterial",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(3455), new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(3455) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(3431), new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(3433) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(1854), new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(1857) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(3473), new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(3473) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(3470), new DateTime(2025, 7, 3, 15, 25, 19, 599, DateTimeKind.Utc).AddTicks(3470) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "LearningMaterial",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LearningMaterial",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6237), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6237) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6223), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6224) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(5440), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(5443) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6243), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6243) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6240), new DateTime(2025, 7, 3, 9, 23, 47, 425, DateTimeKind.Utc).AddTicks(6240) });
        }
    }
}
