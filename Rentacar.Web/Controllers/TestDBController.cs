using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rentacar.Data.EF;
using Rentacar.Web.ViewModels;

namespace Rentacar.Web.Controllers
{
    public class TestDBController : Controller
    {
        private MyContext _context;

        public TestDBController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["testDBCounts"] = new TestDBVM
            {
                DetaljiServisa = _context.DetaljiServisas.Count(),
                Gradovi = _context.Gradovis.Count(),
                Kategorije = _context.Kategorijes.Count(),
                Komentari = _context.Komentaris.Count(),
                Korisnici = _context.Korisnicis.Count(),
                Korisnicki_nalog = _context.Korisnicki_nalogs.Count(),
                Modeli = _context.Modelis.Count(),
                Nalog = _context.Nalogs.Count(),
                Notifikacije = _context.Notifikacijes.Count(),
                Opcine = _context.Opcines.Count(),
                Podmodeli = _context.Podmodelis.Count(),
                Polozene_kategorije = _context.Polozene_Kategorijes.Count(),
                Proizvodjaci = _context.Proizvodjacis.Count(),
                Saloni = _context.Salonis.Count(),
                Servisi = _context.Servisis.Count(),
                Uplate = _context.Uplates.Count(),
                Utisci = _context.Utiscis.Count(),
                Vijesti = _context.Vijestis.Count(),
                Vozila = _context.Vozilas.Count(),
                Zaposlenici = _context.Zaposlenicis.Count()
            };
            return View("TestDB");
        }
    }
}