using Rentacar.Data.Models;
using Rentacar.Web.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.Web.ViewModels
{
    public class RegisterVM
    {
        [MinLength(2)]
        public string Ime { get; set; }
        [MinLength(2)]
        public string Prezime { get; set; }
        [MinLength(5)]
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
        public List<Opcine> Opstine { get; set; }
        public int Opstina { get; set; }
    }
}
