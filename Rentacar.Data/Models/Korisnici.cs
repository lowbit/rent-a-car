﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar.Data.Models
{
    class Korisnici
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public float Ostvareni_popust { get; set; }
        public DateTime Datum_rodjenja { get; set; }
        public string Adresa { get; set; }
        public string Broj_telefona { get; set; }
    }
}