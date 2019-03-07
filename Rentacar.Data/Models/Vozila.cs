using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Vozila
    {
        [Key]
        public int Id { get; set; }
        public string Broj_sasije { get; set; }
        public string Broj_Motora { get; set; }
        public string Grodina_Proizvodnje { get; set; }
        public string Broj_Registracije { get; set; }
        public DateTime Datum_Prve_Registracije { get; set; }
        public DateTime Datum_Registracije { get; set; }
        public DateTime Datum_Isteka_Registracije { get; set; }
        public string Predjena_kilometraza { get; set; }
        public string Zamjena_ulja { get; set; }
        public bool Elektricni_podizaci_stakla { get; set; }
        public bool Klima { get; set; }
        public bool Zracni_Jastuci { get; set; }
        public bool Navigacijska_Oprema { get; set; }
        public bool Grijaci_Sjedista { get; set; }
        public bool Daljinsko_otkljucavanje { get; set; }
        [ForeignKey("Podmodel")]
        public int PodmodelId { get; set; }
        public Podmodeli Podmodel { get; set; }
    }
}
