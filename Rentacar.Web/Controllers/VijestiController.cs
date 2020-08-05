using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentacar.Data.EF;
using Rentacar.Data.Models;
using Rentacar.Web.Shared;

namespace Rentacar.Web.Controllers
{
    public class VijestiController : Controller
    {
        private MyContext _context;
        public VijestiController (MyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(
            int? pageNumber)
        {

            var vijesti = from v in _context.Vijestis select v;
            int pageSize = 5;
            return View("VijestiList", await PaginatedList<Vijesti>.CreateAsync(vijesti.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await _context.Vijestis.ToListAsync());
        }
        public async Task<IActionResult> Details(
            int? id)
        {
            var vijest = await _context.Vijestis.FindAsync(id);
            vijest.Ukupno_pregleda++;
            _context.Entry(vijest).CurrentValues.SetValues(vijest);
            _context.SaveChanges();
            return View("VijestiDetails", vijest);
        }
    }
}
