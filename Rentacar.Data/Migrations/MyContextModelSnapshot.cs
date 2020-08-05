﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rentacar.Data.EF;

namespace Rentacar.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rentacar.Data.Models.DetaljiServisa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Iznos_U_KM");

                    b.Property<string>("Napomene");

                    b.Property<string>("Opis_posla");

                    b.Property<int>("ServisID");

                    b.HasKey("Id");

                    b.HasIndex("ServisID");

                    b.ToTable("DetaljiServisas");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Gradovi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Postanski_broj");

                    b.HasKey("Id");

                    b.ToTable("Gradovis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Kategorije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv_Kategorije");

                    b.HasKey("Id");

                    b.ToTable("Kategorijes");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Komentari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId");

                    b.Property<DateTime>("Datum_objave");

                    b.Property<string>("Sadrzaj");

                    b.Property<int>("VijestId");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("VijestId");

                    b.ToTable("Komentaris");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Korisnici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("Broj_telefona");

                    b.Property<DateTime>("Datum_rodjenja");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<int>("OpcinaId");

                    b.Property<float>("Ostvareni_popust");

                    b.Property<string>("Prezime");

                    b.HasKey("Id");

                    b.HasIndex("OpcinaId");

                    b.ToTable("Korisnicis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Korisnicki_nalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Datum_prijave");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Korsnicko_ime");

                    b.Property<string>("Lozinka");

                    b.Property<int>("TipId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("TipId");

                    b.ToTable("Korisnicki_nalogs");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Modeli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<int>("ProizvodjacId");

                    b.Property<string>("Tip_vozila");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodjacId");

                    b.ToTable("Modelis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Nalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum_I_Vrijeme_Izdavanja");

                    b.Property<DateTime>("Datum_I_Vrijeme_Odobrenja");

                    b.Property<DateTime>("Datum_I_Vrijeme_Preuzimanja_Vozila");

                    b.Property<DateTime>("Datum_I_Vrijeme_Vracanja_Vozila");

                    b.Property<string>("Iznos_U_KM");

                    b.Property<int>("KorisnikID");

                    b.Property<string>("Pocetna_Kilometraza");

                    b.Property<string>("Popust");

                    b.Property<string>("Predjenja_Kilometraza");

                    b.Property<int>("VoziloID");

                    b.Property<int>("ZaposlenikID");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("VoziloID");

                    b.HasIndex("ZaposlenikID");

                    b.ToTable("Nalogs");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Notifikacije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Datum_i_vrijeme_objave");

                    b.Property<string>("Datum_i_vrijeme_pregleda");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Naslov");

                    b.Property<string>("Sadrzaj");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Notifikacijes");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Opcine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradId");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.ToTable("Opcines");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Podmodeli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Broj_Sjedista");

                    b.Property<string>("Broj_Vrata");

                    b.Property<string>("Maksimalna_Snaga_kW");

                    b.Property<string>("Mijenjac");

                    b.Property<int>("ModelID");

                    b.Property<string>("Pogon");

                    b.Property<string>("Radni_Obujam_Motora");

                    b.Property<string>("Vrsta_Goriva");

                    b.Property<string>("Vrsta_Motora");

                    b.HasKey("Id");

                    b.HasIndex("ModelID");

                    b.ToTable("Podmodelis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Polozene_kategorije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisniciId");

                    b.Property<int>("NazivId");

                    b.Property<DateTime>("Vrijedi_Do");

                    b.Property<DateTime>("Vrijedi_Od");

                    b.HasKey("Id");

                    b.HasIndex("KorisniciId");

                    b.HasIndex("NazivId");

                    b.ToTable("Polozene_Kategorijes");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Proizvodjaci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Zemlja_Porijekla");

                    b.HasKey("Id");

                    b.ToTable("Proizvodjacis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Saloni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adresa");

                    b.Property<int>("Broj_Telefona");

                    b.Property<int>("Email");

                    b.Property<int>("FAX");

                    b.Property<string>("Naziv");

                    b.Property<int>("OpcinaId");

                    b.HasKey("Id");

                    b.HasIndex("OpcinaId");

                    b.ToTable("Salonis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Servisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum_Dolaska");

                    b.Property<DateTime>("Datum_Preuzimanja");

                    b.Property<int>("VoziloId");

                    b.HasKey("Id");

                    b.HasIndex("VoziloId");

                    b.ToTable("Servisis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Tipovi_korisnickog_naloga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<string>("Permisije");

                    b.HasKey("Id");

                    b.ToTable("Tipovi_korisnickog_nalogas");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Uplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum_Uplate");

                    b.Property<string>("Iznos_U_KM");

                    b.Property<int>("KorisnikID");

                    b.Property<int>("NalogID");

                    b.Property<int>("VoziloID");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("NalogID");

                    b.HasIndex("VoziloID");

                    b.ToTable("Uplates");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Utisci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bodovi");

                    b.Property<DateTime>("Datum_Objave");

                    b.Property<int?>("KorisniciId");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Opis");

                    b.Property<int>("VoziloId");

                    b.HasKey("Id");

                    b.HasIndex("KorisniciId");

                    b.HasIndex("VoziloId");

                    b.ToTable("Utiscis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Vijesti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId");

                    b.Property<DateTime>("Datum_i_vrijeme_objave");

                    b.Property<string>("Naslov");

                    b.Property<string>("Sadrzaj");

                    b.Property<string>("Slika");

                    b.Property<string>("URL");

                    b.Property<int>("Ukupno_pregleda");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Vijestis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Vozila", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Broj_Motora");

                    b.Property<string>("Broj_Registracije");

                    b.Property<string>("Broj_sasije");

                    b.Property<bool>("Daljinsko_otkljucavanje");

                    b.Property<DateTime>("Datum_Isteka_Registracije");

                    b.Property<DateTime>("Datum_Prve_Registracije");

                    b.Property<DateTime>("Datum_Registracije");

                    b.Property<bool>("Elektricni_podizaci_stakla");

                    b.Property<bool>("Grijaci_Sjedista");

                    b.Property<string>("Grodina_Proizvodnje");

                    b.Property<bool>("Klima");

                    b.Property<bool>("Navigacijska_Oprema");

                    b.Property<int>("PodmodelId");

                    b.Property<string>("Predjena_kilometraza");

                    b.Property<string>("Zamjena_ulja");

                    b.Property<bool>("Zracni_Jastuci");

                    b.HasKey("Id");

                    b.HasIndex("PodmodelId");

                    b.ToTable("Vozilas");
                });

            modelBuilder.Entity("Rentacar.Data.Models.Zaposlenici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("Datum_rodjenja");

                    b.Property<int>("GradID");

                    b.Property<string>("Ime");

                    b.Property<string>("JMB");

                    b.Property<int>("KorisnickiNalogId");

                    b.Property<string>("Korisnicko_Ime");

                    b.Property<string>("Lozinka");

                    b.Property<string>("Prezime");

                    b.Property<string>("Spol");

                    b.HasKey("Id");

                    b.HasIndex("GradID");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("Zaposlenicis");
                });

            modelBuilder.Entity("Rentacar.Data.Models.DetaljiServisa", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Servisi", "Servis")
                        .WithMany()
                        .HasForeignKey("ServisID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Komentari", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Korisnicki_nalog", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentacar.Data.Models.Vijesti", "Vijest")
                        .WithMany()
                        .HasForeignKey("VijestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Korisnici", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Opcine", "Opcina")
                        .WithMany()
                        .HasForeignKey("OpcinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Korisnicki_nalog", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Korisnici", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentacar.Data.Models.Tipovi_korisnickog_naloga", "Tip")
                        .WithMany()
                        .HasForeignKey("TipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Modeli", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Proizvodjaci", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Nalog", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Korisnici", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentacar.Data.Models.Vozila", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentacar.Data.Models.Zaposlenici", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Notifikacije", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Korisnicki_nalog", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Opcine", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Gradovi", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Podmodeli", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Modeli", "Model")
                        .WithMany()
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Polozene_kategorije", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Korisnici", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisniciId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentacar.Data.Models.Kategorije", "Naziv")
                        .WithMany()
                        .HasForeignKey("NazivId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Saloni", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Opcine", "Opcina")
                        .WithMany()
                        .HasForeignKey("OpcinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Servisi", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Vozila", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Uplate", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Korisnici", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentacar.Data.Models.Nalog", "Nalog")
                        .WithMany()
                        .HasForeignKey("NalogID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentacar.Data.Models.Vozila", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Utisci", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Korisnici", "Korisnici")
                        .WithMany()
                        .HasForeignKey("KorisniciId");

                    b.HasOne("Rentacar.Data.Models.Vozila", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Vijesti", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Korisnicki_nalog", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Vozila", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Podmodeli", "Podmodel")
                        .WithMany()
                        .HasForeignKey("PodmodelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentacar.Data.Models.Zaposlenici", b =>
                {
                    b.HasOne("Rentacar.Data.Models.Gradovi", "grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentacar.Data.Models.Korisnicki_nalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}