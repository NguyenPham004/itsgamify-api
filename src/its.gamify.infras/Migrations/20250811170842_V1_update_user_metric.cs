using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V1_update_user_metric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChallengeWinStreak",
                table: "UserMetrics",
                newName: "WinStreak");

            migrationBuilder.RenameColumn(
                name: "ChallengeWinNum",
                table: "UserMetrics",
                newName: "WinNum");

            migrationBuilder.RenameColumn(
                name: "ChallengeLoseNum",
                table: "UserMetrics",
                newName: "LoseNum");

            migrationBuilder.AddColumn<int>(
                name: "HighestWinStreak",
                table: "UserMetrics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestWinStreak",
                table: "UserMetrics");

            migrationBuilder.RenameColumn(
                name: "WinStreak",
                table: "UserMetrics",
                newName: "ChallengeWinStreak");

            migrationBuilder.RenameColumn(
                name: "WinNum",
                table: "UserMetrics",
                newName: "ChallengeWinNum");

            migrationBuilder.RenameColumn(
                name: "LoseNum",
                table: "UserMetrics",
                newName: "ChallengeLoseNum");

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
    }
}
