using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class modify_constraint_db_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeTag_Lesson_LessonId",
                table: "PracticeTag");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2952), new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2953) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2943), new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2943) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2376), new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2378) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2957), new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2957) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2955), new DateTime(2025, 7, 2, 20, 32, 6, 654, DateTimeKind.Utc).AddTicks(2955) });

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeTag_Lesson_LessonId",
                table: "PracticeTag",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeTag_Lesson_LessonId",
                table: "PracticeTag");

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
    }
}
