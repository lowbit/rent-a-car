using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentacar.Data.Models
{
    public class Korisnici
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public float Ostvareni_popust { get; set; }
        public DateTime Datum_rodjenja { get; set; }
        public string Adresa { get; set; }
        public string Broj_telefona { get; set; }
        [ForeignKey("Opcina")]
        public int OpcinaId { get; set; }
        public Opcine Opcina { get; set; }
    }
}
