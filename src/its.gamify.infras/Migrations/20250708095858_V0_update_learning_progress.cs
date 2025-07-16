using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_update_learning_progress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoTimePosition",
                table: "LearningProgress",
                type: "integer",
                nullable: true);

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 9, 58, 48, 675, DateTimeKind.Utc).AddTicks(554), new DateTime(2025, 7, 8, 9, 58, 48, 675, DateTimeKind.Utc).AddTicks(555) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 9, 58, 48, 675, DateTimeKind.Utc).AddTicks(523), new DateTime(2025, 7, 8, 9, 58, 48, 675, DateTimeKind.Utc).AddTicks(527) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 9, 58, 48, 674, DateTimeKind.Utc).AddTicks(8741), new DateTime(2025, 7, 8, 9, 58, 48, 674, DateTimeKind.Utc).AddTicks(8750) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 9, 58, 48, 675, DateTimeKind.Utc).AddTicks(566), new DateTime(2025, 7, 8, 9, 58, 48, 675, DateTimeKind.Utc).AddTicks(567) });

            // migrationBuilder.UpdateData(
            //     table: "Role",
            //     keyColumn: "Id",
            //     keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
            //     columns: new[] { "CreatedDate", "UpdatedDate" },
            //     values: new object[] { new DateTime(2025, 7, 8, 9, 58, 48, 675, DateTimeKind.Utc).AddTicks(560), new DateTime(2025, 7, 8, 9, 58, 48, 675, DateTimeKind.Utc).AddTicks(561) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoTimePosition",
                table: "LearningProgress");

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
        }
    }
}
