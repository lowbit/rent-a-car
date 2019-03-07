using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Komentari
    {
        [Key]
        public int Id { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime Datum_objave { get; set; }
        [ForeignKey("Autor")]
        public int AutorId { get; set; }
        public Korisnicki_nalog Autor { get; set; }
        [ForeignKey("Vijest")]
        public int VijestId { get; set; }
        public Vijesti Vijest { get; set; }
    }
}
