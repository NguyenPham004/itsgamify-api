using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V2_Update_Room_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentQuestionId",
                table: "Room",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8536), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8536) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8523), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(7773), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(7776) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8543), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8543) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8539), new DateTime(2025, 8, 19, 4, 21, 58, 89, DateTimeKind.Utc).AddTicks(8540) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentQuestionId",
                table: "Room",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(937), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(938) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(924), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(37), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(41) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(943), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(940), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(941) });
        }
    }
}
