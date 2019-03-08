using Rentacar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rentacar.Data.EF
{
    public class DbInitialize
    {
        static List<Korisnici> korisniks = new List<Korisnici>();
        static List<Korisnicki_nalog> Korisnicki_nalogs = new List<Korisnicki_nalog>();
        static List<Tipovi_korisnickog_naloga> Tipovi_korisnickog_nalogas = new List<Tipovi_korisnickog_naloga>();
        static List<Vijesti> Vijestis = new List<Vijesti>();
        static List<Komentari> Komentaris = new List<Komentari>();
        public static void Run(MyContext db)
        {
            GenerateUsers();
            if (db.Tipovi_korisnickog_nalogas.Any() == false)
                GenerisTipoveKorisnickihNaloga();
            if (db.Korisnicki_nalogs.Any() == false)
                GenerisiKorisnickeNaloge();
        }
        public static void GenerateUsers()
        {
            Korisnici k = new Korisnici();
            k.Ime = "John";
            k.Prezime = "Doe";
            k.Email = "john.doe@gmail.com";
            k.Adresa = "John Doe 243";
            k.Broj_telefona = "777 333 222";
            k.Datum_rodjenja = new System.DateTime();
            k.Ostvareni_popust = 10;
            korisniks.Add(k);
        }

        public static void GenerisiKorisnike()
        {
            MyContext db = new MyContext();
            Gradovi grad = new Gradovi();
            grad.Naziv = "Sarajevo";
            grad.Postanski_broj = "71000";
            Opcine opcina = new Opcine();
            opcina.Naziv = "Novi grad";
            opcina.GradId = 0;
            opcina.Grad = grad;
            Korisnici korisnik0 = new Korisnici();
            korisnik0.Ime = "John";
            korisnik0.Prezime = "Johnson";
            korisnik0.OpcinaId = 0;
            korisnik0.Opcina = opcina;
            korisnik0.Ostvareni_popust = 10;
            Korisnici korisnik1 = new Korisnici();
            korisnik1.Ime = "Mark";
            korisnik1.Prezime = "Johnson";
            korisnik1.OpcinaId = 0;
            korisnik1.Opcina = opcina;
            korisnik1.Ostvareni_popust = 10;
            Korisnici korisnik2 = new Korisnici();
            korisnik2.Ime = "John";
            korisnik2.Prezime = "Markson";
            korisnik2.OpcinaId = 0;
            korisnik2.Opcina = opcina;
            korisnik2.Ostvareni_popust = 10;
            Korisnici korisnik3 = new Korisnici();
            korisnik3.Ime = "Donald";
            korisnik3.Prezime = "Markson";
            korisnik3.OpcinaId = 0;
            korisnik3.Opcina = opcina;
            korisnik3.Ostvareni_popust = 10;
            Korisnici korisnik4 = new Korisnici();
            korisnik4.Ime = "William";
            korisnik4.Prezime = "Donaldson";
            korisnik4.OpcinaId = 0;
            korisnik4.Opcina = opcina;
            korisnik4.Ostvareni_popust = 10;
            db.Add(grad);
            db.SaveChanges();
            db.Add(opcina);
            db.SaveChanges();
            db.Add(korisnik0);
            db.Add(korisnik1);
            db.Add(korisnik2);
            db.Add(korisnik3);
            db.Add(korisnik4);
            db.SaveChanges();

        }
        public static void GenerisTipoveKorisnickihNaloga()
        {
            MyContext db = new MyContext();
            Tipovi_korisnickog_naloga tip1 = new Tipovi_korisnickog_naloga();
            tip1.Naziv = "Marketing";
            tip1.Opis = "Zaduzen za azuriranje i pisanje novosti i brisanje nepozeljnih komentara.";
            tip1.Permisije = "Vijesti - citanje,pisanje i brisanje. Komentari,Utisci - citanje i brisanje";
            Tipovi_korisnickog_naloga tip2 = new Tipovi_korisnickog_naloga();
            tip2.Naziv = "Prodavac";
            tip2.Opis = "Unosi uplate.";
            tip2.Permisije = "Uplate - citanje i pisanje, Nalog - citanje i pisanje";
            Tipovi_korisnickog_naloga tip3 = new Tipovi_korisnickog_naloga();
            tip3.Naziv = "Logistika";
            tip3.Opis = "Azurira podatke o vozilima,salonima i servisima.";
            tip3.Permisije = "Vozila,Servisi,Detalji_servisa,Podmodeli,Modeli,Proizvodjaci,Saloni,Opcine,Gradovi - citanje,pisanje i brisanje,";
            Tipovi_korisnickog_naloga tip4 = new Tipovi_korisnickog_naloga();
            tip4.Naziv = "Kupac";
            tip4.Opis = "Pretrazuje ponude, iznajmljuje vozila.";
            tip4.Permisije = "Vozila,Saloni,Vijesti - citanje. Komentari, Utisci, - citanje,pisanje i brisanje(samo svoje). Nalog - citanje(samo svoje),pisanje(samo svoje)";
            db.Add(tip1);
            db.Add(tip2);
            db.Add(tip3);
            db.Add(tip4);
            db.SaveChanges();
            db.Dispose();


        }
        public static void GenerisiKorisnickeNaloge()
        {
            MyContext db = new MyContext();
            List<Tipovi_korisnickog_naloga> tipovi = db.Tipovi_korisnickog_nalogas.ToList();
            List<Korisnici> korisnici = db.Korisnicis.ToList();
            Korisnicki_nalog administrator = new Korisnicki_nalog();
            administrator.Korsnicko_ime = "administrator";
            administrator.Lozinka = "admin";
            administrator.Datum_prijave = DateTime.Now.ToString();
            administrator.Tip = tipovi[0];
            administrator.Korisnik = korisnici[0];
            administrator.KorisnikId = 0;


            Korisnicki_nalog marketing = new Korisnicki_nalog();
            marketing.Korsnicko_ime = "marketing";
            marketing.Lozinka = "market";
            marketing.Datum_prijave = DateTime.Now.ToString();
            marketing.Tip = tipovi[1];
            marketing.Korisnik = korisnici[1];
            marketing.KorisnikId = 1;

            Korisnicki_nalog prodavac = new Korisnicki_nalog();
            prodavac.Korsnicko_ime = "prodavac";
            prodavac.Lozinka = "prodaja";
            prodavac.Datum_prijave = DateTime.Now.ToString();
            prodavac.Tip = tipovi[2];
            prodavac.Korisnik = korisnici[2];
            prodavac.KorisnikId = 2;

            Korisnicki_nalog logistika = new Korisnicki_nalog();
            logistika.Korsnicko_ime = "logistika";
            logistika.Lozinka = "log";
            logistika.Datum_prijave = DateTime.Now.ToString();
            logistika.Tip = tipovi[3];
            logistika.Korisnik = korisnici[3];
            logistika.KorisnikId = 3;

            Korisnicki_nalog kupac = new Korisnicki_nalog();
            kupac.Korsnicko_ime = "kupac";
            kupac.Lozinka = "kupac";
            kupac.Datum_prijave = DateTime.Now.ToString();
            kupac.Tip = tipovi[4];
            kupac.Korisnik = korisnici[4];
            kupac.KorisnikId = 4;

            db.Add(administrator);
            db.Add(marketing);
            db.Add(prodavac);
            db.Add(logistika);
            db.Add(kupac);
            db.SaveChanges();
            db.Dispose();

        }
    }
}