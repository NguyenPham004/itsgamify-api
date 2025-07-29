using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class removechallendeparti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChallengeParticipation");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Challenge",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "NumOfRoom",
                table: "Challenge",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4181), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4182) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4161), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(2410), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(2421) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4189), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4185), new DateTime(2025, 7, 28, 3, 40, 28, 481, DateTimeKind.Utc).AddTicks(4186) });

            migrationBuilder.CreateIndex(
                name: "IX_Challenge_CourseId",
                table: "Challenge",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_Course_CourseId",
                table: "Challenge",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_Course_CourseId",
                table: "Challenge");

            migrationBuilder.DropIndex(
                name: "IX_Challenge_CourseId",
                table: "Challenge");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Challenge");

            migrationBuilder.DropColumn(
                name: "NumOfRoom",
                table: "Challenge");

            migrationBuilder.CreateTable(
                name: "ChallengeParticipation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChallengeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeParticipation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipation_Challenge_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipation_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1199), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1162), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1163) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(241), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(245) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1208), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1209) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1204), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1204) });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipation_ChallengeId",
                table: "ChallengeParticipation",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipation_EmployeeId",
                table: "ChallengeParticipation",
                column: "EmployeeId");
        }
    }
}
