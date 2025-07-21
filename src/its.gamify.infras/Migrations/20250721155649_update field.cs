using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class updatefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeMetric_UserId",
                table: "EmployeeMetric");

            migrationBuilder.AddColumn<int>(
                name: "ChallengeAwardNum",
                table: "EmployeeMetric",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChallengeParticipateNum",
                table: "EmployeeMetric",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseCompletedNum",
                table: "EmployeeMetric",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseParticipatedNum",
                table: "EmployeeMetric",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointInQuarter",
                table: "EmployeeMetric",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "QuarterId",
                table: "EmployeeMetric",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "CourseParticipation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsOptional",
                table: "Course",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMetric_Quarter_QuarterId",
                table: "EmployeeMetric",
                column: "QuarterId",
                principalTable: "Quarter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMetric_Quarter_QuarterId",
                table: "EmployeeMetric");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeMetric_QuarterId",
                table: "EmployeeMetric");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeMetric_UserId",
                table: "EmployeeMetric");

            migrationBuilder.DropColumn(
                name: "ChallengeAwardNum",
                table: "EmployeeMetric");

            migrationBuilder.DropColumn(
                name: "ChallengeParticipateNum",
                table: "EmployeeMetric");

            migrationBuilder.DropColumn(
                name: "CourseCompletedNum",
                table: "EmployeeMetric");

            migrationBuilder.DropColumn(
                name: "CourseParticipatedNum",
                table: "EmployeeMetric");

            migrationBuilder.DropColumn(
                name: "PointInQuarter",
                table: "EmployeeMetric");

            migrationBuilder.DropColumn(
                name: "QuarterId",
                table: "EmployeeMetric");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "CourseParticipation");

            migrationBuilder.DropColumn(
                name: "IsOptional",
                table: "Course");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(5184), new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(5185) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(5169), new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(4383), new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(5201), new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(5187), new DateTime(2025, 7, 14, 15, 38, 35, 141, DateTimeKind.Utc).AddTicks(5188) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMetric_UserId",
                table: "EmployeeMetric",
                column: "UserId",
                unique: true);
        }
    }
}
