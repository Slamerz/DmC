﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EvilMortyBot.Migrations
{
    public partial class minwaifuprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinWaifuPrice",
                table: "BotConfig",
                nullable: false,
                defaultValue: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinWaifuPrice",
                table: "BotConfig");
        }
    }
}
