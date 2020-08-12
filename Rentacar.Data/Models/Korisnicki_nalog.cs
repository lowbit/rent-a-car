using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentacar.Data.Models
{
    public class Korisnicki_nalog : IdentityUser
    {
        public string Korsnicko_ime { get; set; }
        public string Datum_prijave { get; set; }
        [ForeignKey("Korisnik")]
        public int KorisnikId { get; set; }
        public Korisnici Korisnik { get; set; }

    }
}
