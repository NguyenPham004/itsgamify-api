using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_5_add_fields_course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Course",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "Targets",
                table: "Course",
                type: "text[]",
                nullable: false);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0c6a67c2-f485-41bb-928e-66c9b8d4c141"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 448, DateTimeKind.Local).AddTicks(3692), "", false, "Employee", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 449, DateTimeKind.Local).AddTicks(878) },
                    { new Guid("1a7c5831-8080-4e2f-8bb0-5a29df81f944"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 449, DateTimeKind.Local).AddTicks(1403), "", false, "Manager", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 449, DateTimeKind.Local).AddTicks(1403) },
                    { new Guid("6b3889ae-87a2-4776-8223-b6a53d320da0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 449, DateTimeKind.Local).AddTicks(1392), "", false, "Leader", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 449, DateTimeKind.Local).AddTicks(1393) },
                    { new Guid("87e16dee-0260-4876-bbae-9a98c0740b60"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 449, DateTimeKind.Local).AddTicks(1400), "", false, "TrainingStaff", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 449, DateTimeKind.Local).AddTicks(1401) },
                    { new Guid("d1cae1a6-e5dd-474e-ba72-c6689ee9ab31"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 449, DateTimeKind.Local).AddTicks(1405), "", false, "Admin", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 26, 13, 11, 59, 449, DateTimeKind.Local).AddTicks(1405) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0c6a67c2-f485-41bb-928e-66c9b8d4c141"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("1a7c5831-8080-4e2f-8bb0-5a29df81f944"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6b3889ae-87a2-4776-8223-b6a53d320da0"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("87e16dee-0260-4876-bbae-9a98c0740b60"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d1cae1a6-e5dd-474e-ba72-c6689ee9ab31"));

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Targets",
                table: "Course");
        }
    }
}
