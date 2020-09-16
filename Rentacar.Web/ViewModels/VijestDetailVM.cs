using Rentacar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.Web.ViewModels
{
    public class VijestDetailVM
    {
        public Vijesti Vijest { get; set; }
        public IEnumerable<Komentari> Komentari { get; set; }
        public Komentari NoviKomentar { get; set; }
    }
}
