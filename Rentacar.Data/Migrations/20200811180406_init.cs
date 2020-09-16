using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentacar.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                name: "Tipovi_korisnickog_nalogas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Permisije = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipovi_korisnickog_nalogas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Broj_telefona = table.Column<string>(nullable: true),
                    OpcinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnicis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnicis_Opcines_OpcinaId",
                        column: x => x.OpcinaId,
                        principalTable: "Opcines",
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Korsnicko_ime = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    Datum_prijave = table.Column<string>(nullable: true),
                    TipId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Korisnicis_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnicis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Tipovi_korisnickog_nalogas_TipId",
                        column: x => x.TipId,
                        principalTable: "Tipovi_korisnickog_nalogas",
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    KorisnikId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacijes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifikacijes_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vijestis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naslov = table.Column<string>(nullable: false),
                    Slika = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: false),
                    Datum_i_vrijeme_objave = table.Column<DateTime>(nullable: false),
                    Ukupno_pregleda = table.Column<int>(nullable: false),
                    AutorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vijestis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vijestis_AspNetUsers_AutorId",
                        column: x => x.AutorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    KorisnickiNalogId = table.Column<string>(nullable: true),
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
                        name: "FK_Zaposlenicis_AspNetUsers_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Komentaris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sadrzaj = table.Column<string>(maxLength: 480, nullable: false),
                    Datum_objave = table.Column<DateTime>(nullable: false),
                    AutorId = table.Column<string>(nullable: true),
                    VijestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentaris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentaris_AspNetUsers_AutorId",
                        column: x => x.AutorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Komentaris_Vijestis_VijestId",
                        column: x => x.VijestId,
                        principalTable: "Vijestis",
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
                        onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KorisnikId",
                table: "AspNetUsers",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TipId",
                table: "AspNetUsers",
                column: "TipId");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiServisas_ServisID",
                table: "DetaljiServisas",
                column: "ServisID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentaris_AutorId",
                table: "Komentaris",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentaris_VijestId",
                table: "Komentaris",
                column: "VijestId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnicis_OpcinaId",
                table: "Korisnicis",
                column: "OpcinaId");

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
                name: "IX_Vijestis_AutorId",
                table: "Vijestis",
                column: "AutorId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetaljiServisas");

            migrationBuilder.DropTable(
                name: "Komentaris");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Servisis");

            migrationBuilder.DropTable(
                name: "Vijestis");

            migrationBuilder.DropTable(
                name: "Kategorijes");

            migrationBuilder.DropTable(
                name: "Nalogs");

            migrationBuilder.DropTable(
                name: "Vozilas");

            migrationBuilder.DropTable(
                name: "Zaposlenicis");

            migrationBuilder.DropTable(
                name: "Podmodelis");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Modelis");

            migrationBuilder.DropTable(
                name: "Korisnicis");

            migrationBuilder.DropTable(
                name: "Tipovi_korisnickog_nalogas");

            migrationBuilder.DropTable(
                name: "Proizvodjacis");

            migrationBuilder.DropTable(
                name: "Opcines");

            migrationBuilder.DropTable(
                name: "Gradovis");
        }
    }
}
