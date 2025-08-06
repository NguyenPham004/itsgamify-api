using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V1_update_histories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OpponentId",
                table: "UserChallengeHistory",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_UserChallengeHistory_OpponentId",
                table: "UserChallengeHistory",
                column: "OpponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChallengeHistory_User_OpponentId",
                table: "UserChallengeHistory",
                column: "OpponentId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChallengeHistory_User_OpponentId",
                table: "UserChallengeHistory");

            migrationBuilder.DropIndex(
                name: "IX_UserChallengeHistory_OpponentId",
                table: "UserChallengeHistory");

            migrationBuilder.DropColumn(
                name: "OpponentId",
                table: "UserChallengeHistory");

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
    }
}
