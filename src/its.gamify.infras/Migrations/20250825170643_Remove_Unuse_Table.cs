using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Unuse_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_LeadearBoard_LeadearBoardId",
                table: "User");

            migrationBuilder.DropTable(
                name: "LeadearBoard");

            migrationBuilder.DropIndex(
                name: "IX_User_LeadearBoardId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LeadearBoardId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "StartRating",
                table: "CourseMetric",
                newName: "StarRating");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "HashedPassword");

            migrationBuilder.RenameColumn(
                name: "StarRating",
                table: "CourseMetric",
                newName: "StartRating");

            migrationBuilder.AddColumn<Guid>(
                name: "LeadearBoardId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "User",
                type: "bytea",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LeadearBoard",
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
                    table.PrimaryKey("PK_LeadearBoard", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6263), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6263) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6251), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6251) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(5505), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6269), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6269) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6266), new DateTime(2025, 8, 25, 3, 45, 5, 154, DateTimeKind.Utc).AddTicks(6267) });

            migrationBuilder.CreateIndex(
                name: "IX_User_LeadearBoardId",
                table: "User",
                column: "LeadearBoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_LeadearBoard_LeadearBoardId",
                table: "User",
                column: "LeadearBoardId",
                principalTable: "LeadearBoard",
                principalColumn: "Id");
        }
    }
}
