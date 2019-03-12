using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rentacar.Data.EF;

namespace Rentacar.Web.Controllers
{
    public class NovostiController : Controller
    {
        private MyContext _context;

        public NovostiController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["NotifikacijeVD"] = _context.Notifikacijes.ToList();
            ViewBag.NovostiVB = _context.Notifikacijes.ToList();
            return View("GetNovosti");
        }
    }
}