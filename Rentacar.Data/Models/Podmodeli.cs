using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Podmodeli
    {
        [Key]
        public int Id { get; set; }
        public string Vrsta_Motora { get; set; }
        public string Vrsta_Goriva { get; set; }
        public string Maksimalna_Snaga_kW { get; set; }
        public string Radni_Obujam_Motora { get; set; }
        public string Broj_Sjedista { get; set; }
        public string Broj_Vrata { get; set; }
        public string Mijenjac { get; set; }
        public string Pogon { get; set; }
        [ForeignKey("Model")]
        public int ModelID { get; set; }
        public Modeli Model { get; set; }
    }
}
