using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class DetaljiServisa
    {
        [Key]
        public int Id { get; set; }
        public string Opis_posla { get; set; }
        public string Napomene { get; set; }
        public string Iznos_U_KM { get; set; }
        [ForeignKey("Servis")]
        public int ServisID { get; set; }
        public Servisi Servis { get; set; }
    }
}
