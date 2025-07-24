using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class changetablename2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeMetric");

            migrationBuilder.DropColumn(
                name: "QuestionBankId",
                table: "Question");

            migrationBuilder.CreateTable(
                name: "UserMetrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseParticipatedNum = table.Column<int>(type: "integer", nullable: false),
                    CourseCompletedNum = table.Column<int>(type: "integer", nullable: false),
                    ChallengeParticipateNum = table.Column<int>(type: "integer", nullable: false),
                    ChallengeAwardNum = table.Column<int>(type: "integer", nullable: false),
                    PointInQuarter = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuarterId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMetrics_Quarter_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "Quarter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMetrics_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(6457), new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(6457) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(6440), new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(5274), new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(5279) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(6466), new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(6466) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(6461), new DateTime(2025, 7, 21, 18, 5, 24, 596, DateTimeKind.Utc).AddTicks(6461) });

            migrationBuilder.CreateIndex(
                name: "IX_UserMetrics_QuarterId",
                table: "UserMetrics",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMetrics_UserId",
                table: "UserMetrics",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMetrics");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionBankId",
                table: "Question",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EmployeeMetric",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuarterId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChallengeAwardNum = table.Column<int>(type: "integer", nullable: false),
                    ChallengeParticipateNum = table.Column<int>(type: "integer", nullable: false),
                    CourseCompletedNum = table.Column<int>(type: "integer", nullable: false),
                    CourseParticipatedNum = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    PointInQuarter = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMetric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeMetric_Quarter_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "Quarter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMetric_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(7803), new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(7803) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(7786), new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(7787) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(6753), new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(6756) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(7809), new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(7806), new DateTime(2025, 7, 21, 15, 56, 48, 405, DateTimeKind.Utc).AddTicks(7806) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMetric_QuarterId",
                table: "EmployeeMetric",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMetric_UserId",
                table: "EmployeeMetric",
                column: "UserId");
        }
    }
}
