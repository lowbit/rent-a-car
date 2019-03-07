using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Opcine
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        [ForeignKey("Grad")]
        public int GradId { get; set; }
        public Gradovi Grad { get; set; }
    }
}
