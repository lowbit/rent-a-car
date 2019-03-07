using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Servisi
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datum_Dolaska { get; set; }
        public DateTime Datum_Preuzimanja { get; set; }
        [ForeignKey("Vozilo")]
        public int VoziloId { get; set; }
        public Vozila Vozilo { get; set; }
    }
}
