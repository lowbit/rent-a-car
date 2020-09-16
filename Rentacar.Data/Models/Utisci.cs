using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Utisci
    {
        [Key]
        public int Id { get; set; }
        public string Opis { get; set; }
        public int Bodovi { get; set; }
        public DateTime Datum_Objave { get; set; }
        [ForeignKey("Korisnik")]
        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }
        [ForeignKey("Vozilo")]
        public int VoziloId { get; set; }
        public Vozila Vozilo { get; set; }
    }
}
