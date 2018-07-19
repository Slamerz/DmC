﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvilMortyBot.Migrations
{
    public partial class totalxp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalXp",
                table: "DiscordUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(MigrationQueries.TotalXp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalXp",
                table: "DiscordUser");
        }
    }
}
