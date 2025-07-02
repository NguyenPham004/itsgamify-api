using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDb_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "LearningMaterial",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "File",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "File",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "File",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6296), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6297) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6285), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6285) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(5742), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(5745) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6302), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6302) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6299), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterial_FileId",
                table: "LearningMaterial",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningMaterial_File_FileId",
                table: "LearningMaterial",
                column: "FileId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningMaterial_File_FileId",
                table: "LearningMaterial");

            migrationBuilder.DropIndex(
                name: "IX_LearningMaterial_FileId",
                table: "LearningMaterial");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "LearningMaterial");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "File");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "File");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "File");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8187), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8187) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8172), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8173) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(7358), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8193), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8193) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8190), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8190) });
        }
    }
}
