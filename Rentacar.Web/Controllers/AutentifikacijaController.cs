using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rentacar.Data;
using Microsoft.AspNetCore.Mvc;
using Rentacar.Data.EF;
using Rentacar.Web.ViewModels;
using Rentacar.Data.Models;

namespace Rentacar.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private readonly MyContext _db;

        public AutentifikacijaController(MyContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(new AutentifikacijaVM());
        }

        public IActionResult Autentifikacija(AutentifikacijaVM ulaz)
        {
            Korisnicki_nalog korisnik = _db.Korisnicki_nalogs.SingleOrDefault(x => x.Korsnicko_ime == ulaz.korisnicko_ime && x.Lozinka == ulaz.lozinka);

            if(korisnik == null)
            {
                ViewData["error_poruka"] = "Pogrešno korisničko ime ili lozinka!";
                return View("Index", ulaz);
            }

            HttpContext.Session.SetString("nekiKey", korisnik.Korsnicko_ime);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Izlaz()
        {
            return RedirectToAction("Index");
        }
    }
}