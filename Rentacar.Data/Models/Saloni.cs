using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Saloni
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Adresa { get; set; }
        public int Broj_Telefona { get; set; }
        public int FAX { get; set; }
        public int Email { get; set; }
        [ForeignKey("Opcina")]
        public int OpcinaId { get; set; }
        public Opcine Opcina { get; set; }

    }
}
