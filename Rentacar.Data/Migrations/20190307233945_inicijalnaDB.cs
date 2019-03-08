using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentacar.Data.Migrations
{
    public partial class inicijalnaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnicki_nalogs_Tipovi_korisnickog_naloga_TipId",
                table: "Korisnicki_nalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipovi_korisnickog_naloga",
                table: "Tipovi_korisnickog_naloga");

            migrationBuilder.RenameTable(
                name: "Tipovi_korisnickog_naloga",
                newName: "Tipovi_korisnickog_nalogas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipovi_korisnickog_nalogas",
                table: "Tipovi_korisnickog_nalogas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnicki_nalogs_Tipovi_korisnickog_nalogas_TipId",
                table: "Korisnicki_nalogs",
                column: "TipId",
                principalTable: "Tipovi_korisnickog_nalogas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnicki_nalogs_Tipovi_korisnickog_nalogas_TipId",
                table: "Korisnicki_nalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipovi_korisnickog_nalogas",
                table: "Tipovi_korisnickog_nalogas");

            migrationBuilder.RenameTable(
                name: "Tipovi_korisnickog_nalogas",
                newName: "Tipovi_korisnickog_naloga");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipovi_korisnickog_naloga",
                table: "Tipovi_korisnickog_naloga",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnicki_nalogs_Tipovi_korisnickog_naloga_TipId",
                table: "Korisnicki_nalogs",
                column: "TipId",
                principalTable: "Tipovi_korisnickog_naloga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
