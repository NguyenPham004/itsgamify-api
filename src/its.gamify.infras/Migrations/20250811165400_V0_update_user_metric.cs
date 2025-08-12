using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_update_user_metric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChallengeLoseNum",
                table: "UserMetrics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChallengeWinNum",
                table: "UserMetrics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChallengeWinStreak",
                table: "UserMetrics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(9497), new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(9498) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(9464), new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(9465) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(8341), new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(8344) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(9505), new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(9505) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(9502), new DateTime(2025, 8, 11, 16, 53, 58, 325, DateTimeKind.Utc).AddTicks(9502) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChallengeLoseNum",
                table: "UserMetrics");

            migrationBuilder.DropColumn(
                name: "ChallengeWinNum",
                table: "UserMetrics");

            migrationBuilder.DropColumn(
                name: "ChallengeWinStreak",
                table: "UserMetrics");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(6312), new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(6313) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(6292), new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(6293) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(5434), new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(6318), new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(6319) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(6315), new DateTime(2025, 8, 6, 12, 29, 13, 432, DateTimeKind.Utc).AddTicks(6316) });
        }
    }
}
