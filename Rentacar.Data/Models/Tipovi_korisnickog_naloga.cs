﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Tipovi_korisnickog_naloga
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Permisije { get; set; }
        public string Opis { get; set; }

    }
}
