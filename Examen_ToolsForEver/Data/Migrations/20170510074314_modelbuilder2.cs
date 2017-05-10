using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Examen_ToolsForEver.Data.Migrations
{
    public partial class modelbuilder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fabrikanten_Producten_ProductID",
                table: "Fabrikanten");

            migrationBuilder.DropForeignKey(
                name: "FK_Locaties_ProductLocaties_ProductLocatieID",
                table: "Locaties");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocaties_Producten_ProductID",
                table: "ProductLocaties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLocaties",
                table: "ProductLocaties");

            migrationBuilder.DropIndex(
                name: "IX_ProductLocaties_ProductID",
                table: "ProductLocaties");

            migrationBuilder.DropIndex(
                name: "IX_Locaties_ProductLocatieID",
                table: "Locaties");

            migrationBuilder.DropIndex(
                name: "IX_Fabrikanten_ProductID",
                table: "Fabrikanten");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ProductLocaties");

            migrationBuilder.DropColumn(
                name: "ProductLocatieID",
                table: "Locaties");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Fabrikanten");

            migrationBuilder.RenameTable(
                name: "ProductLocaties",
                newName: "ProductLocatie");

            migrationBuilder.AddColumn<int>(
                name: "MinVoorraad",
                table: "ProductLocatie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLocatie",
                table: "ProductLocatie",
                columns: new[] { "ProductID", "LocatieID" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocatie_LocatieID",
                table: "ProductLocatie",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Producten_FabrikantID",
                table: "Producten",
                column: "FabrikantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Fabrikanten_FabrikantID",
                table: "Producten",
                column: "FabrikantID",
                principalTable: "Fabrikanten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocatie_Locaties_LocatieID",
                table: "ProductLocatie",
                column: "LocatieID",
                principalTable: "Locaties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocatie_Producten_ProductID",
                table: "ProductLocatie",
                column: "ProductID",
                principalTable: "Producten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Fabrikanten_FabrikantID",
                table: "Producten");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocatie_Locaties_LocatieID",
                table: "ProductLocatie");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocatie_Producten_ProductID",
                table: "ProductLocatie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLocatie",
                table: "ProductLocatie");

            migrationBuilder.DropIndex(
                name: "IX_ProductLocatie_LocatieID",
                table: "ProductLocatie");

            migrationBuilder.DropIndex(
                name: "IX_Producten_FabrikantID",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "MinVoorraad",
                table: "ProductLocatie");

            migrationBuilder.RenameTable(
                name: "ProductLocatie",
                newName: "ProductLocaties");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ProductLocaties",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProductLocatieID",
                table: "Locaties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Fabrikanten",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLocaties",
                table: "ProductLocaties",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocaties_ProductID",
                table: "ProductLocaties",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Locaties_ProductLocatieID",
                table: "Locaties",
                column: "ProductLocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrikanten_ProductID",
                table: "Fabrikanten",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fabrikanten_Producten_ProductID",
                table: "Fabrikanten",
                column: "ProductID",
                principalTable: "Producten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locaties_ProductLocaties_ProductLocatieID",
                table: "Locaties",
                column: "ProductLocatieID",
                principalTable: "ProductLocaties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocaties_Producten_ProductID",
                table: "ProductLocaties",
                column: "ProductID",
                principalTable: "Producten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
