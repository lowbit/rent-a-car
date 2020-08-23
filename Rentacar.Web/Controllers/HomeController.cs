using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentacar.Data.EF;
using Rentacar.Web.ViewModels;

namespace Rentacar.Web.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _db;

        public HomeController(MyContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var home = new HomeVM();
            home.Vijesti = _db.Vijestis.OrderByDescending(v => v.Id).ToList().Take(3);
            if (this.User.Identity.IsAuthenticated) {

                var korisnikId = _db.Korisnicki_nalogs.Where(k => k.UserName == this.User.Identity.Name).Include(k => k.Korisnik).AsNoTracking().FirstOrDefault().Korisnik.Id;
                home.Nalozi = _db.Nalogs.Include(v => v.Vozilo).AsNoTracking().Where(x => x.KorisnikID == korisnikId).OrderByDescending(v => v.Id).ToList().Take(3);
            }
            return View(home);
        }
        public IActionResult ONama()
        {
            return View("ONama");
        }
        [Authorize(Roles ="Administrator")]
        public IActionResult TestDB()
        {
            _db.Notifikacijes.Count();
            return View();
        }
        public IActionResult Autentifikacija()
        {
            return View();
        }
    }
}
