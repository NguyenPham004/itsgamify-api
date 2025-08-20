using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_Update_Course_Collections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CourseCollection");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(3792), new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(3792) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(3777), new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(3777) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(2807), new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(3809), new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(3809) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(3806), new DateTime(2025, 8, 20, 11, 23, 54, 849, DateTimeKind.Utc).AddTicks(3806) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CourseCollection",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(6345), new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(6346) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(6330), new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(6331) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(5525), new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(6351), new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(6352) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(6348), new DateTime(2025, 8, 19, 18, 25, 42, 141, DateTimeKind.Utc).AddTicks(6349) });
        }
    }
}
