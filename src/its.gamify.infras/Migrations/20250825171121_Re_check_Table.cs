using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class Re_check_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 11, 20, 296, DateTimeKind.Utc).AddTicks(308), new DateTime(2025, 8, 25, 17, 11, 20, 296, DateTimeKind.Utc).AddTicks(308) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 11, 20, 296, DateTimeKind.Utc).AddTicks(287), new DateTime(2025, 8, 25, 17, 11, 20, 296, DateTimeKind.Utc).AddTicks(288) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 11, 20, 295, DateTimeKind.Utc).AddTicks(9426), new DateTime(2025, 8, 25, 17, 11, 20, 295, DateTimeKind.Utc).AddTicks(9429) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 11, 20, 296, DateTimeKind.Utc).AddTicks(315), new DateTime(2025, 8, 25, 17, 11, 20, 296, DateTimeKind.Utc).AddTicks(315) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 11, 20, 296, DateTimeKind.Utc).AddTicks(311), new DateTime(2025, 8, 25, 17, 11, 20, 296, DateTimeKind.Utc).AddTicks(312) });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMetric_CourseId",
                table: "CourseMetric",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMetric_Course_CourseId",
                table: "CourseMetric",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMetric_Course_CourseId",
                table: "CourseMetric");

            migrationBuilder.DropIndex(
                name: "IX_CourseMetric_CourseId",
                table: "CourseMetric");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(9860), new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(9861) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(9839), new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(9840) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(8510), new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(9866), new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(9867) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(9864), new DateTime(2025, 8, 25, 17, 6, 41, 254, DateTimeKind.Utc).AddTicks(9864) });
        }
    }
}
