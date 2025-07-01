using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDb_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8187), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8187) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8172), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8173) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(7358), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8193), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8193) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8190), new DateTime(2025, 7, 1, 14, 59, 16, 446, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_DepartmentId",
                table: "Course",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_DepartmentId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_DepartmentId",
                table: "Course");

            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6993), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6993) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6980), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6418), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6421) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(7001), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6996), new DateTime(2025, 6, 30, 14, 52, 0, 935, DateTimeKind.Utc).AddTicks(6996) });
        }
    }
}
