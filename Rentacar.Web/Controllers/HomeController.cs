using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rentacar.Data.EF;

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
            return View();
        }

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
