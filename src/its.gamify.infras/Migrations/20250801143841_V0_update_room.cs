using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_update_room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BetPoint",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "TimeQuestion",
                table: "Room",
                newName: "TimePerQuestion");

            migrationBuilder.RenameColumn(
                name: "AmountQuestion",
                table: "Room",
                newName: "QuestionCount");


            migrationBuilder.AddColumn<int>(
                name: "BetPoints",
                table: "Room",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "HostUserId",
                table: "Room",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAbandoned",
                table: "Room",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHostReady",
                table: "Room",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpponentReady",
                table: "Room",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OpponentUserId",
                table: "Room",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Room",
                type: "text",
                nullable: false,
                defaultValue: "");


            migrationBuilder.CreateIndex(
                name: "IX_Room_HostUserId",
                table: "Room",
                column: "HostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_OpponentUserId",
                table: "Room",
                column: "OpponentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_User_HostUserId",
                table: "Room",
                column: "HostUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_User_OpponentUserId",
                table: "Room",
                column: "OpponentUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_User_HostUserId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_User_OpponentUserId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_HostUserId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_OpponentUserId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "BetPoints",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HostUserId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "IsAbandoned",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "IsHostReady",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "IsOpponentReady",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "OpponentUserId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "TimePerQuestion",
                table: "Room",
                newName: "TimeQuestion");

            migrationBuilder.RenameColumn(
                name: "QuestionCount",
                table: "Room",
                newName: "AmountQuestion");

            // migrationBuilder.RenameColumn(
            //     name: "ThumbnailImage",
            //     table: "Challenge",
            //     newName: "ThumnailImage");

            migrationBuilder.AddColumn<float>(
                name: "BetPoint",
                table: "Room",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
