using Rentacar.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.Web.ViewModels
{
    public class IznajmljivanjeVozilaVM
    {
        [Required]
        public string Datum_I_Vrijeme_Preuzimanja_Vozila { get; set; }
        [Required]
        public string Datum_I_Vrijeme_Vracanja_Vozila { get; set; }
        public string Iznos_U_KM { get; set; }
        public string Pocetna_Kilometraza { get; set; }
        public string Predjenja_Kilometraza { get; set; }
        public string Popust { get; set; }
        public string KorisnikId { get; set; }
        [Required]
        public string Proizvodjac { get; set; }
        public List<Proizvodjaci> ProizvodjaciList;
        [Required]
        public string Model { get; set; }
        public List<Modeli> ModeliList;
        [Required]
        public string Vozilo { get; set; }
        public List<Vozila> VoziloList { get; set; }
        public int ZaposlenikId { get; set; }
        public string BrojRegistracije { get; set; }
        public string GodinaProizvodnje { get; set; }
        public string BrojSasije { get; set; }
        public string BrojMotora { get; set; }
        public bool ElPodStakla { get; set; }
        public bool Klima { get; set; }
        public bool ZrJastuci { get; set; }
        public bool NavOprema { get; set; }
        public bool GrSjedista { get; set; }
        public string VrstaGoriva { get; set; }
        public string MaxSnaga { get; set; }
        public string BrojSjedista { get; set; }
        public string BrojVrata { get; set; }
        public string Mjenjac { get; set; }
        public string Pogon { get; set; }
    }
}
