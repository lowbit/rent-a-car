using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.Web.ViewModels
{
    public class AutentifikacijaVM
    {
        public string korisnicko_ime { get; set; }
        [DataType(DataType.Password)]
        public string lozinka { get; set; }
    }
}
