using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V2_update_learning_progress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "LearningProgress");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "LearningProgress",
                type: "text",
                nullable: false,
                defaultValue: "");

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6910), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6911) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6872), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6875) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(4020), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(4026) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6921), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6922) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6917), new DateTime(2025, 7, 9, 16, 59, 3, 541, DateTimeKind.Utc).AddTicks(6918) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "LearningProgress");

            migrationBuilder.AddColumn<double>(
                name: "Percentage",
                table: "LearningProgress",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(7166), new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(7166) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(7155), new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(7156) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(6408), new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(6412) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(7171), new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(7171) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(7169), new DateTime(2025, 7, 8, 14, 25, 45, 985, DateTimeKind.Utc).AddTicks(7169) });
        }
    }
}
