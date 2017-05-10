using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen_ToolsForEver.Data.Migrations
{
    public partial class editedLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocatieNaam",
                table: "Locaties",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocatieNaam",
                table: "Locaties",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
