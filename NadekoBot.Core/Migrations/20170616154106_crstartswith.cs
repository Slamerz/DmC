﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EvilMortyBot.Migrations
{
    public partial class crstartswith : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CustomReactionsStartWith",
                table: "BotConfig",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomReactionsStartWith",
                table: "BotConfig");
        }
    }
}
