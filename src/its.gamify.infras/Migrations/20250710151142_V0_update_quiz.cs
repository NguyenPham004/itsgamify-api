using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_update_quiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalMarks",
                table: "Quiz",
                newName: "TotalMark");

            migrationBuilder.RenameColumn(
                name: "PassedMarks",
                table: "Quiz",
                newName: "PassedMark");

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "Quiz",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7473), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7449), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(6376), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(6381) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7479), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7479) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7476), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7476) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Quiz");

            migrationBuilder.RenameColumn(
                name: "TotalMark",
                table: "Quiz",
                newName: "TotalMarks");

            migrationBuilder.RenameColumn(
                name: "PassedMark",
                table: "Quiz",
                newName: "PassedMarks");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6910), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6911) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6872), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6875) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(4020), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(4026) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6921), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6917), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6918) });
        }
    }
}
