using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class changetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_Course_CourseId",
                table: "WishList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_User_UserId",
                table: "WishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishList",
                table: "WishList");

            migrationBuilder.RenameTable(
                name: "WishList",
                newName: "CourseCollection");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_UserId",
                table: "CourseCollection",
                newName: "IX_CourseCollection_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_CourseId",
                table: "CourseCollection",
                newName: "IX_CourseCollection_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseCollection",
                table: "CourseCollection",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CourseMetric",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    SaveCount = table.Column<int>(type: "integer", nullable: false),
                    CompletionCount = table.Column<int>(type: "integer", nullable: false),
                    ReviewCount = table.Column<int>(type: "integer", nullable: false),
                    StartRating = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMetric", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCollection_Course_CourseId",
                table: "CourseCollection",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCollection_User_UserId",
                table: "CourseCollection",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCollection_Course_CourseId",
                table: "CourseCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCollection_User_UserId",
                table: "CourseCollection");

            migrationBuilder.DropTable(
                name: "CourseMetric");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseCollection",
                table: "CourseCollection");

            migrationBuilder.RenameTable(
                name: "CourseCollection",
                newName: "WishList");

            migrationBuilder.RenameIndex(
                name: "IX_CourseCollection_UserId",
                table: "WishList",
                newName: "IX_WishList_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseCollection_CourseId",
                table: "WishList",
                newName: "IX_WishList_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishList",
                table: "WishList",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6296), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6297) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6285), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6285) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(5742), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(5745) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6302), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6302) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6299), new DateTime(2025, 7, 2, 0, 32, 35, 448, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_Course_CourseId",
                table: "WishList",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_User_UserId",
                table: "WishList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
