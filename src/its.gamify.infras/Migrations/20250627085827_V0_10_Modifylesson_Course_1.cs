using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_10_Modifylesson_Course_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Challenge_ChallengeId",
                table: "Quiz");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChallengeId",
                table: "Quiz",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChallengIdId",
                table: "Quiz",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9769), new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9758), new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9758) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9216), new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9785), new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9785) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9773), new DateTime(2025, 6, 27, 8, 58, 26, 553, DateTimeKind.Utc).AddTicks(9773) });

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Challenge_ChallengeId",
                table: "Quiz",
                column: "ChallengeId",
                principalTable: "Challenge",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Challenge_ChallengeId",
                table: "Quiz");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChallengeId",
                table: "Quiz",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ChallengIdId",
                table: "Quiz",
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
                values: new object[] { new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(4107), new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(4107) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(4096), new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(3537), new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(4114), new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(4114) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(4111), new DateTime(2025, 6, 27, 6, 8, 13, 213, DateTimeKind.Utc).AddTicks(4111) });

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Challenge_ChallengeId",
                table: "Quiz",
                column: "ChallengeId",
                principalTable: "Challenge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
