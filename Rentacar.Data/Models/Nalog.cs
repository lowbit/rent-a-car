using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Nalog
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datum_I_Vrijeme_Izdavanja { get; set; }
        public DateTime Datum_I_Vrijeme_Odobrenja { get; set; }
        public DateTime Datum_I_Vrijeme_Preuzimanja_Vozila { get; set; }
        public DateTime Datum_I_Vrijeme_Vracanja_Vozila { get; set; }
        public string Iznos_U_KM { get; set; }
        public string Pocetna_Kilometraza { get; set; }
        public string Predjenja_Kilometraza { get; set; }
        public string Popust { get; set; }
        [ForeignKey("Korisnik")]
        public int KorisnikID { get; set; }
        public Korisnici Korisnik { get; set; }
        [ForeignKey("Vozilo")]
        public int VoziloID { get; set; }
        public Vozila Vozilo { get; set; }
        [ForeignKey("Zaposlenik")]
        public int ZaposlenikID { get; set; }
        public Zaposlenici Zaposlenik { get; set; }
    }
}
