using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDb_Practice_Lesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeTag_Practice_PracticeId",
                table: "PracticeTag");

            migrationBuilder.DropTable(
                name: "Practice");

            migrationBuilder.RenameColumn(
                name: "TagName",
                table: "PracticeTag",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "PracticeId",
                table: "PracticeTag",
                newName: "LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_PracticeTag_PracticeId",
                table: "PracticeTag",
                newName: "IX_PracticeTag_LessonId");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "PracticeTag",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Lesson",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "Lesson",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3913), new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3913) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3900), new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3308), new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3311) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3940), new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3916), new DateTime(2025, 7, 2, 18, 30, 18, 517, DateTimeKind.Utc).AddTicks(3917) });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_LessonId",
                table: "Lesson",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Lesson_LessonId",
                table: "Lesson",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeTag_Lesson_LessonId",
                table: "PracticeTag",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Lesson_LessonId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_PracticeTag_Lesson_LessonId",
                table: "PracticeTag");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_LessonId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "PracticeTag");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Lesson");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "PracticeTag",
                newName: "TagName");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "PracticeTag",
                newName: "PracticeId");

            migrationBuilder.RenameIndex(
                name: "IX_PracticeTag_LessonId",
                table: "PracticeTag",
                newName: "IX_PracticeTag_PracticeId");

            migrationBuilder.CreateTable(
                name: "Practice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseSectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Practice_CourseSection_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Practice_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Practice_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(8717), new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(8717) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(8701), new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(8701) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(7793), new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(7796) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(8723), new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(8723) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(8720), new DateTime(2025, 7, 2, 4, 35, 1, 485, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.CreateIndex(
                name: "IX_Practice_CourseId",
                table: "Practice",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Practice_CourseSectionId",
                table: "Practice",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Practice_LessonId",
                table: "Practice",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeTag_Practice_PracticeId",
                table: "PracticeTag",
                column: "PracticeId",
                principalTable: "Practice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
