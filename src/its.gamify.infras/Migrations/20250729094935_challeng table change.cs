using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class challengtablechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Category_Quarter_QuarterId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_UserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "QuarterId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Category");*/

            migrationBuilder.RenameColumn(
                name: "TitleDes",
                table: "Challenge",
                newName: "ThumnailImage");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(7529), new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(7506), new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(7506) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(6565), new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(6568) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(7536), new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(7533), new DateTime(2025, 7, 29, 9, 49, 34, 518, DateTimeKind.Utc).AddTicks(7533) });

           /* migrationBuilder.AddForeignKey(
                name: "FK_UserMetrics_Quarter_QuarterId",
                table: "UserMetrics",
                column: "QuarterId",
                principalTable: "Quarter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMetrics_User_UserId",
                table: "UserMetrics",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserMetrics_Quarter_QuarterId",
            //    table: "UserMetrics");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserMetrics_User_UserId",
            //    table: "UserMetrics");

            migrationBuilder.RenameColumn(
                name: "ThumnailImage",
                table: "Challenge",
                newName: "TitleDes");

            /*migrationBuilder.AddColumn<Guid>(
                name: "QuarterId",
                table: "Category",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Category",
                type: "uuid",
                nullable: true);*/

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2510), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2510) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2496), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(1698), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2515), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2515) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2513), new DateTime(2025, 7, 29, 4, 26, 32, 392, DateTimeKind.Utc).AddTicks(2513) });

            /*migrationBuilder.AddForeignKey(
                name: "FK_Category_Quarter_QuarterId",
                table: "Category",
                column: "QuarterId",
                principalTable: "Quarter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_UserId",
                table: "Category",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }
    }
}
