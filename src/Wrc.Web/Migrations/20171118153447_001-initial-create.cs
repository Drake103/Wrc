using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Wrc.Web.Migrations
{
    public partial class _001initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EugenUserId = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "replay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AI = table.Column<bool>(type: "bool", nullable: false),
                    AllowObservers = table.Column<bool>(type: "bool", nullable: false),
                    DateConstraint = table.Column<string>(type: "text", nullable: true),
                    DownloadCount = table.Column<int>(type: "int4", nullable: false),
                    FileHash = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    GameMapCode = table.Column<string>(type: "text", nullable: true),
                    GameModeCode = table.Column<string>(type: "text", nullable: true),
                    GameTypeCode = table.Column<string>(type: "text", nullable: true),
                    IncomeRate = table.Column<int>(type: "int4", nullable: false),
                    InitMoney = table.Column<int>(type: "int4", nullable: false),
                    IsNetworkMode = table.Column<bool>(type: "bool", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bool", nullable: false),
                    MaxPlayers = table.Column<int>(type: "int4", nullable: false),
                    NationConstraint = table.Column<string>(type: "text", nullable: true),
                    ScoreLimit = table.Column<int>(type: "int4", nullable: false),
                    Seed = table.Column<string>(type: "text", nullable: true),
                    ServerName = table.Column<string>(type: "text", nullable: true),
                    ThematicConstraint = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: true),
                    VictoryConditionCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_replay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccountRecordId = table.Column<int>(type: "int4", nullable: true),
                    Alliance = table.Column<int>(type: "int4", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    DeckContent = table.Column<string>(type: "text", nullable: true),
                    DeckName = table.Column<string>(type: "text", nullable: true),
                    Elo = table.Column<double>(type: "float8", nullable: false),
                    IALevel = table.Column<string>(type: "text", nullable: true),
                    IncomeRate = table.Column<int>(type: "int4", nullable: false),
                    IsEnteredInLobby = table.Column<bool>(type: "bool", nullable: false),
                    Level = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "int4", nullable: false),
                    Rank = table.Column<int>(type: "int4", nullable: false),
                    ReplayRecordId = table.Column<int>(type: "int4", nullable: true),
                    ScoreLimit = table.Column<int>(type: "int4", nullable: false),
                    TeamName = table.Column<string>(type: "text", nullable: true),
                    WasReady = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_player_account_AccountRecordId",
                        column: x => x.AccountRecordId,
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_player_replay_ReplayRecordId",
                        column: x => x.ReplayRecordId,
                        principalTable: "replay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_player_AccountRecordId",
                table: "player",
                column: "AccountRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_player_ReplayRecordId",
                table: "player",
                column: "ReplayRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "replay");
        }
    }
}
