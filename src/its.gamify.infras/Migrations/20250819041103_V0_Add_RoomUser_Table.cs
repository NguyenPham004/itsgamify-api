using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class V0_Add_RoomUser_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_User_OpponentUserId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_OpponentUserId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "CurrentQuestion",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "IsHostAnswer",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "IsHostReady",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "IsOpponentAnswer",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "IsOpponentReady",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "OpponentUserId",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "OpponentScore",
                table: "Room",
                newName: "MaxPlayers");

            migrationBuilder.RenameColumn(
                name: "HostScore",
                table: "Room",
                newName: "CurrentQuestionIndex");

            migrationBuilder.AlterColumn<Guid>(
                name: "HostUserId",
                table: "Room",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentQuestionId",
                table: "Room",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "RoomCode",
                table: "Room",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RoomUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsOutRoom = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentScore = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "integer", nullable: false),
                    IsCurrentQuestionAnswered = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomUser_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(937), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(938) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(924), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(37), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(41) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(943), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(940), new DateTime(2025, 8, 19, 4, 11, 2, 702, DateTimeKind.Utc).AddTicks(941) });

            migrationBuilder.CreateIndex(
                name: "IX_RoomUser_RoomId",
                table: "RoomUser",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomUser_UserId",
                table: "RoomUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomUser");

            migrationBuilder.DropColumn(
                name: "CurrentQuestionId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomCode",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "MaxPlayers",
                table: "Room",
                newName: "OpponentScore");

            migrationBuilder.RenameColumn(
                name: "CurrentQuestionIndex",
                table: "Room",
                newName: "HostScore");

            migrationBuilder.AlterColumn<Guid>(
                name: "HostUserId",
                table: "Room",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "CurrentQuestion",
                table: "Room",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsHostAnswer",
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
                name: "IsOpponentAnswer",
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

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4733), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4734) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4716), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4717) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(3841), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4739), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4737), new DateTime(2025, 8, 17, 13, 42, 48, 303, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.CreateIndex(
                name: "IX_Room_OpponentUserId",
                table: "Room",
                column: "OpponentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_User_OpponentUserId",
                table: "Room",
                column: "OpponentUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
