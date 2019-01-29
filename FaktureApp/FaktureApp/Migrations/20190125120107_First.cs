using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FaktureApp.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faktura",
                columns: table => new
                {
                    BrojDokumenta = table.Column<string>(nullable: false),
                    BrojFakture = table.Column<string>(maxLength: 10, nullable: false),
                    DatumDokumenta = table.Column<DateTime>(nullable: false),
                    Ukupno = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktura", x => x.BrojDokumenta);
                });

            migrationBuilder.CreateTable(
                name: "Stavka",
                columns: table => new
                {
                    RedniBroj = table.Column<int>(nullable: false),
                    BrojDokumenta = table.Column<string>(nullable: false),
                    Cena = table.Column<double>(nullable: false),
                    Kolicina = table.Column<double>(nullable: false),
                    Ukupno = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stavka", x => new { x.RedniBroj, x.BrojDokumenta});
                    table.ForeignKey(
                        name: "FK_Stavka_Faktura_BrojDokumenta",
                        column: x => x.BrojDokumenta,
                        principalTable: "Faktura",
                        principalColumn: "BrojDokumenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stavka_BrojFakture",
                table: "Stavka",
                column: "BrojDokumenta");

          
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stavka");

            migrationBuilder.DropTable(
                name: "Faktura");
        }
    }
}
