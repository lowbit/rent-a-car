using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Modeli
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tip_vozila { get; set; }
        [ForeignKey("Proizvodjac")]
        public int ProizvodjacId { get; set; }
        public Proizvodjaci Proizvodjac { get; set; }
    }
}
