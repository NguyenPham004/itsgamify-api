using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class userchallenge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleDes",
                table: "Challenge",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserChallengeHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<string>(type: "text", nullable: false),
                    OpponentScore = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChallengeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChallengeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChallengeHistory_Challenge_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserChallengeHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2510), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2510) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2496), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(1698), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2515), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2515) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2513), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2513) });

            migrationBuilder.CreateIndex(
                name: "IX_UserChallengeHistory_ChallengeId",
                table: "UserChallengeHistory",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChallengeHistory_UserId",
                table: "UserChallengeHistory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChallengeHistory");

            migrationBuilder.DropColumn(
                name: "TitleDes",
                table: "Challenge");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(9117), new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(9117) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(9103), new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(9103) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(8267), new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(9124), new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(9124) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(9121), new DateTime(2025, 7, 28, 7, 52, 37, 449, DateTimeKind.Utc).AddTicks(9121) });
        }
    }
}
