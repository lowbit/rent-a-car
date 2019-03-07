using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Kategorije
    {
        [Key]
        public int Id { get; set; }
        public string Naziv_Kategorije { get; set; }
    }
}
