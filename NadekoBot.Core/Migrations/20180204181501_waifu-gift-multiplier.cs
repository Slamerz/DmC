﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EvilMortyBot.Migrations
{
    public partial class waifugiftmultiplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WaifuGiftMultiplier",
                table: "BotConfig",
                nullable: false,
                defaultValue: 1)
                .Annotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaifuGiftMultiplier",
                table: "BotConfig");
        }
    }
}
