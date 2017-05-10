using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen_ToolsForEver.Data.Migrations
{
    public partial class testststst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductLocatie_LocatieID",
                table: "ProductLocatie");

            migrationBuilder.DropIndex(
                name: "IX_ProductLocatie_ProductID",
                table: "ProductLocatie");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocatie_LocatieID",
                table: "ProductLocatie",
                column: "LocatieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductLocatie_LocatieID",
                table: "ProductLocatie");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocatie_LocatieID",
                table: "ProductLocatie",
                column: "LocatieID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocatie_ProductID",
                table: "ProductLocatie",
                column: "ProductID",
                unique: true);
        }
    }
}
