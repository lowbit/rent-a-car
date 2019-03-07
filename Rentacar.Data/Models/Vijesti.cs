﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Vijesti
    {
        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Slika { get; set; }
        public string URL { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime Datum_i_vrijeme_objave { get; set; }
        public int Ukupno_pregleda { get; set; }
        [ForeignKey("Autor")]
        public int AutorId { get; set; }
        public Korisnicki_nalog Autor { get; set; }
    }
}
