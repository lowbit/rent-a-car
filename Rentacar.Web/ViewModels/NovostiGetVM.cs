using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.Web.ViewModels
{
    public class NovostiGetVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int Id {get; set;}
            public string Naslov { get; set; }
            public string Sadrzaj { get; set; }
            public string Datum_i_vrijeme_objave { get; set; }
            public string KorisnikId { get; set; }
        }
    }

    
}
