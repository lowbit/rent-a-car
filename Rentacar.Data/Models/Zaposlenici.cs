using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Zaposlenici
    {
        [Key]
        public int Id { get; set; }
        public string Korisnicko_Ime { get; set; }
        public string Lozinka { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string JMB { get; set; }
        public DateTime Datum_rodjenja { get; set; }
        public string Adresa { get; set; }
        public string Spol { get; set; }
       [ForeignKey("KorisnickiNalog")]
        public int KorisnickiNalogId { get; set; }
        public Korisnicki_nalog KorisnickiNalog { get; set; }
        [ForeignKey("Grad")]
        public int GradID { get; set; }
        public Gradovi grad { get; set; }
    }
}
