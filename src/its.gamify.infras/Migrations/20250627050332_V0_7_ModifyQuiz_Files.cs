using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_7_ModifyQuiz_Files : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningProgress_QuizResult_QuizResultId",
                table: "LearningProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_LearningProgress_LearningProgressId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_LearningProgress_QuizResultId",
                table: "LearningProgress");

            migrationBuilder.DropColumn(
                name: "QuizResultId",
                table: "LearningProgress");

            migrationBuilder.AddColumn<Guid>(
                name: "LearningProgressId",
                table: "QuizResult",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "LearningProgressId",
                table: "Lesson",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Course",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "Targets",
                table: "Course",
                type: "text[]",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7602), "", false, "TrainingStaff", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7602) },
                    { new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7589), "", false, "Leader", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7590) },
                    { new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7077), "", false, "Employee", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7079) },
                    { new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7621), "", false, "Admin", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7622) },
                    { new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7619), "", false, "Manager", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 27, 5, 3, 31, 879, DateTimeKind.Utc).AddTicks(7619) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizResult_LearningProgressId",
                table: "QuizResult",
                column: "LearningProgressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_LearningProgress_LearningProgressId",
                table: "Lesson",
                column: "LearningProgressId",
                principalTable: "LearningProgress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResult_LearningProgress_LearningProgressId",
                table: "QuizResult",
                column: "LearningProgressId",
                principalTable: "LearningProgress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_LearningProgress_LearningProgressId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizResult_LearningProgress_LearningProgressId",
                table: "QuizResult");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropIndex(
                name: "IX_QuizResult_LearningProgressId",
                table: "QuizResult");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"));

            migrationBuilder.DropColumn(
                name: "LearningProgressId",
                table: "QuizResult");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Targets",
                table: "Course");

            migrationBuilder.AlterColumn<Guid>(
                name: "LearningProgressId",
                table: "Lesson",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "QuizResultId",
                table: "LearningProgress",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgress_QuizResultId",
                table: "LearningProgress",
                column: "QuizResultId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LearningProgress_QuizResult_QuizResultId",
                table: "LearningProgress",
                column: "QuizResultId",
                principalTable: "QuizResult",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_LearningProgress_LearningProgressId",
                table: "Lesson",
                column: "LearningProgressId",
                principalTable: "LearningProgress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
