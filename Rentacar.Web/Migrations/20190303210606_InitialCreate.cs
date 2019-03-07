using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentacar.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnicis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Ostvareni_popust = table.Column<float>(nullable: false),
                    Datum_rodjenja = table.Column<DateTime>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    Broj_telefona = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnicis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipovi_korisnickog_nalogas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipovi_korisnickog_nalogas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnicki_nalogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Korsnicko_ime = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    Datum_prijave = table.Column<string>(nullable: true),
                    TipId = table.Column<int>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnicki_nalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnicki_nalogs_Korisnicis_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnicis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnicki_nalogs_Tipovi_korisnickog_nalogas_TipId",
                        column: x => x.TipId,
                        principalTable: "Tipovi_korisnickog_nalogas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permisije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Tipovi_korisnickog_nalogaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permisije_Tipovi_korisnickog_nalogas_Tipovi_korisnickog_nalogaId",
                        column: x => x.Tipovi_korisnickog_nalogaId,
                        principalTable: "Tipovi_korisnickog_nalogas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vijestis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naslov = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    Datum_i_vrijeme_objave = table.Column<DateTime>(nullable: false),
                    Ukupno_pregleda = table.Column<int>(nullable: false),
                    AutorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vijestis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vijestis_Korisnicki_nalogs_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Korisnicki_nalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Komentaris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sadrzaj = table.Column<string>(nullable: true),
                    Datum_objave = table.Column<DateTime>(nullable: false),
                    AutorId = table.Column<int>(nullable: true),
                    vijestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentaris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentaris_Korisnicki_nalogs_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Korisnicki_nalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Komentaris_Vijestis_vijestId",
                        column: x => x.vijestId,
                        principalTable: "Vijestis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentaris_AutorId",
                table: "Komentaris",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentaris_vijestId",
                table: "Komentaris",
                column: "vijestId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnicki_nalogs_KorisnikId",
                table: "Korisnicki_nalogs",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnicki_nalogs_TipId",
                table: "Korisnicki_nalogs",
                column: "TipId");

            migrationBuilder.CreateIndex(
                name: "IX_Permisije_Tipovi_korisnickog_nalogaId",
                table: "Permisije",
                column: "Tipovi_korisnickog_nalogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vijestis_AutorId",
                table: "Vijestis",
                column: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentaris");

            migrationBuilder.DropTable(
                name: "Permisije");

            migrationBuilder.DropTable(
                name: "Vijestis");

            migrationBuilder.DropTable(
                name: "Korisnicki_nalogs");

            migrationBuilder.DropTable(
                name: "Korisnicis");

            migrationBuilder.DropTable(
                name: "Tipovi_korisnickog_nalogas");
        }
    }
}
