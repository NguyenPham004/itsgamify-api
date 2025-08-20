using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V3_Update_Challeng_History : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChallengeHistory_User_OpponentId",
                table: "UserChallengeHistory");

            migrationBuilder.RenameColumn(
                name: "OpponentId",
                table: "UserChallengeHistory",
                newName: "WinnerId");

            migrationBuilder.RenameColumn(
                name: "OppScore",
                table: "UserChallengeHistory",
                newName: "WinnerScore");

            migrationBuilder.RenameIndex(
                name: "IX_UserChallengeHistory_OpponentId",
                table: "UserChallengeHistory",
                newName: "IX_UserChallengeHistory_WinnerId");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "UserChallengeHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "UserChallengeHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserChallengeHistory_User_WinnerId",
                table: "UserChallengeHistory",
                column: "WinnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChallengeHistory_User_WinnerId",
                table: "UserChallengeHistory");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "UserChallengeHistory");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "UserChallengeHistory");

            migrationBuilder.RenameColumn(
                name: "WinnerScore",
                table: "UserChallengeHistory",
                newName: "OppScore");

            migrationBuilder.RenameColumn(
                name: "WinnerId",
                table: "UserChallengeHistory",
                newName: "OpponentId");

            migrationBuilder.RenameIndex(
                name: "IX_UserChallengeHistory_WinnerId",
                table: "UserChallengeHistory",
                newName: "IX_UserChallengeHistory_OpponentId");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1038), new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1038) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(960), new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 264, DateTimeKind.Utc).AddTicks(6791), new DateTime(2025, 8, 19, 10, 41, 24, 264, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1055), new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1047), new DateTime(2025, 8, 19, 10, 41, 24, 265, DateTimeKind.Utc).AddTicks(1048) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserChallengeHistory_User_OpponentId",
                table: "UserChallengeHistory",
                column: "OpponentId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
