using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V2_update_lesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_LearningProgress_LearningProgressId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_LearningProgressId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "LearningProgressId",
                table: "Lesson");

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "LearningProgress",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(7523), new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(7523) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(7512), new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(7512) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(6741), new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(6744) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(7529), new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(7530) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(7527), new DateTime(2025, 7, 6, 8, 17, 42, 296, DateTimeKind.Utc).AddTicks(7527) });

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgress_LessonId",
                table: "LearningProgress",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningProgress_Lesson_LessonId",
                table: "LearningProgress",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningProgress_Lesson_LessonId",
                table: "LearningProgress");

            migrationBuilder.DropIndex(
                name: "IX_LearningProgress_LessonId",
                table: "LearningProgress");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "LearningProgress");

            migrationBuilder.AddColumn<Guid>(
                name: "LearningProgressId",
                table: "Lesson",
                type: "uuid",
                nullable: true);

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(6790), new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(6790) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(6775), new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(6775) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(5954), new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(5958) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(6794), new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(6795) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(6792), new DateTime(2025, 7, 5, 15, 51, 53, 455, DateTimeKind.Utc).AddTicks(6792) });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_LearningProgressId",
                table: "Lesson",
                column: "LearningProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_LearningProgress_LearningProgressId",
                table: "Lesson",
                column: "LearningProgressId",
                principalTable: "LearningProgress",
                principalColumn: "Id");
        }
    }
}
