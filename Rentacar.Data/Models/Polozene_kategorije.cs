using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Polozene_kategorije
    {
        [Key]
        public int Id { get; set; }
        public DateTime Vrijedi_Od { get; set; }
        public DateTime Vrijedi_Do { get; set; }
        [ForeignKey("Korisnik")]
        public int KorisniciId { get; set; }
        public Korisnici Korisnik { get; set; }
        [ForeignKey("Naziv")]
        public int NazivId { get; set; }
        public Kategorije Naziv { get; set; }
    }
}
