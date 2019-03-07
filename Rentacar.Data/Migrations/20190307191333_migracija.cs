using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentacar.Data.Migrations
{
    public partial class migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentaris_Korisnicki_nalogs_AutorId",
                table: "Komentaris");

            migrationBuilder.DropForeignKey(
                name: "FK_Komentaris_Vijestis_vijestId",
                table: "Komentaris");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnicki_nalogs_Korisnicis_KorisnikId",
                table: "Korisnicki_nalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnicki_nalogs_Tipovi_korisnickog_nalogas_TipId",
                table: "Korisnicki_nalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Vijestis_Korisnicki_nalogs_AutorId",
                table: "Vijestis");

            migrationBuilder.DropTable(
                name: "Permisije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipovi_korisnickog_nalogas",
                table: "Tipovi_korisnickog_nalogas");

            migrationBuilder.RenameTable(
                name: "Tipovi_korisnickog_nalogas",
                newName: "Tipovi_korisnickog_naloga");

            migrationBuilder.RenameColumn(
                name: "vijestId",
                table: "Komentaris",
                newName: "VijestId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentaris_vijestId",
                table: "Komentaris",
                newName: "IX_Komentaris_VijestId");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Vijestis",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipId",
                table: "Korisnicki_nalogs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Korisnicki_nalogs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpcinaId",
                table: "Korisnicis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VijestId",
                table: "Komentaris",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Komentaris",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Permisije",
                table: "Tipovi_korisnickog_naloga",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipovi_korisnickog_naloga",
                table: "Tipovi_korisnickog_naloga",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Gradovis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Postanski_broj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorijes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv_Kategorije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorijes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacijes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naslov = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    Datum_i_vrijeme_objave = table.Column<string>(nullable: true),
                    Datum_i_vrijeme_pregleda = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacijes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifikacijes_Korisnicki_nalogs_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnicki_nalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjacis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Zemlja_Porijekla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjacis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opcines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opcines_Gradovis_GradId",
                        column: x => x.GradId,
                        principalTable: "Gradovis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenicis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Korisnicko_Ime = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    JMB = table.Column<string>(nullable: true),
                    Datum_rodjenja = table.Column<DateTime>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: false),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenicis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaposlenicis_Gradovis_GradID",
                        column: x => x.GradID,
                        principalTable: "Gradovis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenicis_Korisnicki_nalogs_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "Korisnicki_nalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polozene_Kategorijes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vrijedi_Od = table.Column<DateTime>(nullable: false),
                    Vrijedi_Do = table.Column<DateTime>(nullable: false),
                    KorisniciId = table.Column<int>(nullable: false),
                    NazivId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polozene_Kategorijes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polozene_Kategorijes_Korisnicis_KorisniciId",
                        column: x => x.KorisniciId,
                        principalTable: "Korisnicis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polozene_Kategorijes_Kategorijes_NazivId",
                        column: x => x.NazivId,
                        principalTable: "Kategorijes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Tip_vozila = table.Column<string>(nullable: true),
                    ProizvodjacId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelis_Proizvodjacis_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjacis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salonis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Adresa = table.Column<int>(nullable: false),
                    Broj_Telefona = table.Column<int>(nullable: false),
                    FAX = table.Column<int>(nullable: false),
                    Email = table.Column<int>(nullable: false),
                    OpcinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salonis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salonis_Opcines_OpcinaId",
                        column: x => x.OpcinaId,
                        principalTable: "Opcines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Podmodelis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vrsta_Motora = table.Column<string>(nullable: true),
                    Vrsta_Goriva = table.Column<string>(nullable: true),
                    Maksimalna_Snaga_kW = table.Column<string>(nullable: true),
                    Radni_Obujam_Motora = table.Column<string>(nullable: true),
                    Broj_Sjedista = table.Column<string>(nullable: true),
                    Broj_Vrata = table.Column<string>(nullable: true),
                    Mijenjac = table.Column<string>(nullable: true),
                    Pogon = table.Column<string>(nullable: true),
                    ModelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podmodelis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Podmodelis_Modelis_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Modelis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vozilas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Broj_sasije = table.Column<string>(nullable: true),
                    Broj_Motora = table.Column<string>(nullable: true),
                    Grodina_Proizvodnje = table.Column<string>(nullable: true),
                    Broj_Registracije = table.Column<string>(nullable: true),
                    Datum_Prve_Registracije = table.Column<DateTime>(nullable: false),
                    Datum_Registracije = table.Column<DateTime>(nullable: false),
                    Datum_Isteka_Registracije = table.Column<DateTime>(nullable: false),
                    Predjena_kilometraza = table.Column<string>(nullable: true),
                    Zamjena_ulja = table.Column<string>(nullable: true),
                    Elektricni_podizaci_stakla = table.Column<bool>(nullable: false),
                    Klima = table.Column<bool>(nullable: false),
                    Zracni_Jastuci = table.Column<bool>(nullable: false),
                    Navigacijska_Oprema = table.Column<bool>(nullable: false),
                    Grijaci_Sjedista = table.Column<bool>(nullable: false),
                    Daljinsko_otkljucavanje = table.Column<bool>(nullable: false),
                    PodmodelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vozilas_Podmodelis_PodmodelId",
                        column: x => x.PodmodelId,
                        principalTable: "Podmodelis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nalogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum_I_Vrijeme_Izdavanja = table.Column<DateTime>(nullable: false),
                    Datum_I_Vrijeme_Odobrenja = table.Column<DateTime>(nullable: false),
                    Datum_I_Vrijeme_Preuzimanja_Vozila = table.Column<DateTime>(nullable: false),
                    Datum_I_Vrijeme_Vracanja_Vozila = table.Column<DateTime>(nullable: false),
                    Iznos_U_KM = table.Column<string>(nullable: true),
                    Pocetna_Kilometraza = table.Column<string>(nullable: true),
                    Predjenja_Kilometraza = table.Column<string>(nullable: true),
                    Popust = table.Column<string>(nullable: true),
                    KorisnikID = table.Column<int>(nullable: false),
                    VoziloID = table.Column<int>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nalogs_Korisnicis_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnicis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nalogs_Vozilas_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nalogs_Zaposlenicis_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenicis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servisis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum_Dolaska = table.Column<DateTime>(nullable: false),
                    Datum_Preuzimanja = table.Column<DateTime>(nullable: false),
                    VoziloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servisis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servisis_Vozilas_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utiscis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true),
                    Bodovi = table.Column<int>(nullable: false),
                    Datum_Objave = table.Column<DateTime>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    KorisniciId = table.Column<int>(nullable: true),
                    VoziloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utiscis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utiscis_Korisnicis_KorisniciId",
                        column: x => x.KorisniciId,
                        principalTable: "Korisnicis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Utiscis_Vozilas_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum_Uplate = table.Column<DateTime>(nullable: false),
                    Iznos_U_KM = table.Column<string>(nullable: true),
                    NalogID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    VoziloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplates_Korisnicis_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnicis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uplates_Nalogs_NalogID",
                        column: x => x.NalogID,
                        principalTable: "Nalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Uplates_Vozilas_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetaljiServisas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis_posla = table.Column<string>(nullable: true),
                    Napomene = table.Column<string>(nullable: true),
                    Iznos_U_KM = table.Column<string>(nullable: true),
                    ServisID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaljiServisas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetaljiServisas_Servisis_ServisID",
                        column: x => x.ServisID,
                        principalTable: "Servisis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnicis_OpcinaId",
                table: "Korisnicis",
                column: "OpcinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiServisas_ServisID",
                table: "DetaljiServisas",
                column: "ServisID");

            migrationBuilder.CreateIndex(
                name: "IX_Modelis_ProizvodjacId",
                table: "Modelis",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Nalogs_KorisnikID",
                table: "Nalogs",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Nalogs_VoziloID",
                table: "Nalogs",
                column: "VoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_Nalogs_ZaposlenikID",
                table: "Nalogs",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacijes_KorisnikId",
                table: "Notifikacijes",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Opcines_GradId",
                table: "Opcines",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Podmodelis_ModelID",
                table: "Podmodelis",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Polozene_Kategorijes_KorisniciId",
                table: "Polozene_Kategorijes",
                column: "KorisniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Polozene_Kategorijes_NazivId",
                table: "Polozene_Kategorijes",
                column: "NazivId");

            migrationBuilder.CreateIndex(
                name: "IX_Salonis_OpcinaId",
                table: "Salonis",
                column: "OpcinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisis_VoziloId",
                table: "Servisis",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplates_KorisnikID",
                table: "Uplates",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplates_NalogID",
                table: "Uplates",
                column: "NalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplates_VoziloID",
                table: "Uplates",
                column: "VoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_Utiscis_KorisniciId",
                table: "Utiscis",
                column: "KorisniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Utiscis_VoziloId",
                table: "Utiscis",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilas_PodmodelId",
                table: "Vozilas",
                column: "PodmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenicis_GradID",
                table: "Zaposlenicis",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenicis_KorisnickiNalogId",
                table: "Zaposlenicis",
                column: "KorisnickiNalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentaris_Korisnicki_nalogs_AutorId",
                table: "Komentaris",
                column: "AutorId",
                principalTable: "Korisnicki_nalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentaris_Vijestis_VijestId",
                table: "Komentaris",
                column: "VijestId",
                principalTable: "Vijestis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnicis_Opcines_OpcinaId",
                table: "Korisnicis",
                column: "OpcinaId",
                principalTable: "Opcines",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnicki_nalogs_Korisnicis_KorisnikId",
                table: "Korisnicki_nalogs",
                column: "KorisnikId",
                principalTable: "Korisnicis",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnicki_nalogs_Tipovi_korisnickog_naloga_TipId",
                table: "Korisnicki_nalogs",
                column: "TipId",
                principalTable: "Tipovi_korisnickog_naloga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vijestis_Korisnicki_nalogs_AutorId",
                table: "Vijestis",
                column: "AutorId",
                principalTable: "Korisnicki_nalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentaris_Korisnicki_nalogs_AutorId",
                table: "Komentaris");

            migrationBuilder.DropForeignKey(
                name: "FK_Komentaris_Vijestis_VijestId",
                table: "Komentaris");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnicis_Opcines_OpcinaId",
                table: "Korisnicis");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnicki_nalogs_Korisnicis_KorisnikId",
                table: "Korisnicki_nalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnicki_nalogs_Tipovi_korisnickog_naloga_TipId",
                table: "Korisnicki_nalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Vijestis_Korisnicki_nalogs_AutorId",
                table: "Vijestis");

            migrationBuilder.DropTable(
                name: "DetaljiServisas");

            migrationBuilder.DropTable(
                name: "Notifikacijes");

            migrationBuilder.DropTable(
                name: "Polozene_Kategorijes");

            migrationBuilder.DropTable(
                name: "Salonis");

            migrationBuilder.DropTable(
                name: "Uplates");

            migrationBuilder.DropTable(
                name: "Utiscis");

            migrationBuilder.DropTable(
                name: "Servisis");

            migrationBuilder.DropTable(
                name: "Kategorijes");

            migrationBuilder.DropTable(
                name: "Opcines");

            migrationBuilder.DropTable(
                name: "Nalogs");

            migrationBuilder.DropTable(
                name: "Vozilas");

            migrationBuilder.DropTable(
                name: "Zaposlenicis");

            migrationBuilder.DropTable(
                name: "Podmodelis");

            migrationBuilder.DropTable(
                name: "Gradovis");

            migrationBuilder.DropTable(
                name: "Modelis");

            migrationBuilder.DropTable(
                name: "Proizvodjacis");

            migrationBuilder.DropIndex(
                name: "IX_Korisnicis_OpcinaId",
                table: "Korisnicis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipovi_korisnickog_naloga",
                table: "Tipovi_korisnickog_naloga");

            migrationBuilder.DropColumn(
                name: "OpcinaId",
                table: "Korisnicis");

            migrationBuilder.DropColumn(
                name: "Permisije",
                table: "Tipovi_korisnickog_naloga");

            migrationBuilder.RenameTable(
                name: "Tipovi_korisnickog_naloga",
                newName: "Tipovi_korisnickog_nalogas");

            migrationBuilder.RenameColumn(
                name: "VijestId",
                table: "Komentaris",
                newName: "vijestId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentaris_VijestId",
                table: "Komentaris",
                newName: "IX_Komentaris_vijestId");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Vijestis",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TipId",
                table: "Korisnicki_nalogs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Korisnicki_nalogs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "vijestId",
                table: "Komentaris",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Komentaris",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipovi_korisnickog_nalogas",
                table: "Tipovi_korisnickog_nalogas",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Permisije_Tipovi_korisnickog_nalogaId",
                table: "Permisije",
                column: "Tipovi_korisnickog_nalogaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentaris_Korisnicki_nalogs_AutorId",
                table: "Komentaris",
                column: "AutorId",
                principalTable: "Korisnicki_nalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentaris_Vijestis_vijestId",
                table: "Komentaris",
                column: "vijestId",
                principalTable: "Vijestis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnicki_nalogs_Korisnicis_KorisnikId",
                table: "Korisnicki_nalogs",
                column: "KorisnikId",
                principalTable: "Korisnicis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnicki_nalogs_Tipovi_korisnickog_nalogas_TipId",
                table: "Korisnicki_nalogs",
                column: "TipId",
                principalTable: "Tipovi_korisnickog_nalogas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vijestis_Korisnicki_nalogs_AutorId",
                table: "Vijestis",
                column: "AutorId",
                principalTable: "Korisnicki_nalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
