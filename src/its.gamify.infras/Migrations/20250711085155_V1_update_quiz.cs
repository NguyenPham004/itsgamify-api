using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V1_update_quiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResult_LearningProgress_LearningProgressId",
                table: "QuizResult");

            migrationBuilder.DropIndex(
                name: "IX_QuizResult_LearningProgressId",
                table: "QuizResult");

            migrationBuilder.DropColumn(
                name: "LearningProgressId",
                table: "QuizResult");

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "QuizAnswer",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "QuizResultId",
                table: "LearningProgress",
                type: "uuid",
                nullable: true);

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3876), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3877) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3864), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3864) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3111), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3114) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3882), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3882) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3880), new DateTime(2025, 7, 11, 8, 51, 54, 415, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgress_QuizResultId",
                table: "LearningProgress",
                column: "QuizResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningProgress_QuizResult_QuizResultId",
                table: "LearningProgress",
                column: "QuizResultId",
                principalTable: "QuizResult",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningProgress_QuizResult_QuizResultId",
                table: "LearningProgress");

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

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "QuizAnswer",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7473), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7473) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7449), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7450) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(6376), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(6381) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7479), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7479) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7476), new DateTime(2025, 7, 10, 15, 11, 41, 490, DateTimeKind.Utc).AddTicks(7476) });

            migrationBuilder.CreateIndex(
                name: "IX_QuizResult_LearningProgressId",
                table: "QuizResult",
                column: "LearningProgressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResult_LearningProgress_LearningProgressId",
                table: "QuizResult",
                column: "LearningProgressId",
                principalTable: "LearningProgress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
