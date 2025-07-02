using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class modify_constraint_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "LessonId",
                table: "Lesson");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 25, 27, 916, DateTimeKind.Utc).AddTicks(237), new DateTime(2025, 7, 2, 20, 25, 27, 916, DateTimeKind.Utc).AddTicks(238) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 25, 27, 916, DateTimeKind.Utc).AddTicks(227), new DateTime(2025, 7, 2, 20, 25, 27, 916, DateTimeKind.Utc).AddTicks(227) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 25, 27, 915, DateTimeKind.Utc).AddTicks(9631), new DateTime(2025, 7, 2, 20, 25, 27, 915, DateTimeKind.Utc).AddTicks(9634) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 25, 27, 916, DateTimeKind.Utc).AddTicks(243), new DateTime(2025, 7, 2, 20, 25, 27, 916, DateTimeKind.Utc).AddTicks(243) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 25, 27, 916, DateTimeKind.Utc).AddTicks(241), new DateTime(2025, 7, 2, 20, 25, 27, 916, DateTimeKind.Utc).AddTicks(241) });

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeTag_Lesson_LessonId",
                table: "PracticeTag",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeTag_Lesson_LessonId",
                table: "PracticeTag");

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
    }
}
