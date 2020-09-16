using Rentacar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.Web.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Vijesti> Vijesti { get; set; }
        public IEnumerable<Nalog> Nalozi { get; set; }
    }
}
