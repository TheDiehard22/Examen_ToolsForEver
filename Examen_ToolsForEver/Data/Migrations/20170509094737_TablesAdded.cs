using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Examen_ToolsForEver.Data.Migrations
{
    public partial class TablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Producten",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InkoopWaarde = table.Column<decimal>(nullable: false),
                    Naam = table.Column<string>(nullable: false),
                    ProductLocatieID = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    VerkoopWaarde = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producten", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Fabrikanten",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FabrikantNaam = table.Column<string>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrikanten", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fabrikanten_Producten_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Producten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductLocaties",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aantal = table.Column<int>(nullable: false),
                    LocatieID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocaties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductLocaties_Producten_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Producten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocatieNaam = table.Column<string>(nullable: true),
                    ProductLocatieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Locaties_ProductLocaties_ProductLocatieID",
                        column: x => x.ProductLocatieID,
                        principalTable: "ProductLocaties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fabrikanten_ProductID",
                table: "Fabrikanten",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Locaties_ProductLocatieID",
                table: "Locaties",
                column: "ProductLocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocaties_ProductID",
                table: "ProductLocaties",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fabrikanten");

            migrationBuilder.DropTable(
                name: "Locaties");

            migrationBuilder.DropTable(
                name: "ProductLocaties");

            migrationBuilder.DropTable(
                name: "Producten");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
