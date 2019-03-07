﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rentacar.Data.Models
{
    public class Proizvodjaci
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Zemlja_Porijekla { get; set; }
    }
}
