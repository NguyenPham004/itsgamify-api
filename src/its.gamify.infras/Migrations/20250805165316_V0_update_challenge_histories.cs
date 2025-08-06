using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_update_challenge_histories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "UserChallengeHistory");

            migrationBuilder.DropColumn(
                name: "OpponentScore",
                table: "UserChallengeHistory");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "UserChallengeHistory",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "OppScore",
                table: "UserChallengeHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YourScore",
                table: "UserChallengeHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(6136), new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(6136) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(6123), new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(6123) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(5255), new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(5258) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(6142), new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(6142) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(6139), new DateTime(2025, 8, 5, 16, 53, 15, 106, DateTimeKind.Utc).AddTicks(6140) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OppScore",
                table: "UserChallengeHistory");

            migrationBuilder.DropColumn(
                name: "YourScore",
                table: "UserChallengeHistory");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "UserChallengeHistory",
                newName: "Score");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "UserChallengeHistory",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpponentScore",
                table: "UserChallengeHistory",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2190), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2149), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(287), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(292) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2205), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2199), new DateTime(2025, 8, 5, 9, 21, 47, 922, DateTimeKind.Utc).AddTicks(2199) });
        }
    }
}
