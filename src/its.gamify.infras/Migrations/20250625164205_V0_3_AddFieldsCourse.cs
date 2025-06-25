using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_3_AddFieldsCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Course",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<ValueTuple<string, string>>>(
                name: "Medias",
                table: "Course",
                type: "record[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "Tags",
                table: "Course",
                type: "text[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Medias",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Course");
        }
    }
}
