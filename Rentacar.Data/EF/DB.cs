using Rentacar.Data.Models;
using System.Collections.Generic;

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
    }
}