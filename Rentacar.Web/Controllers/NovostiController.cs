using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rentacar.Data.EF;
using Rentacar.Web.ViewModels;

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
            int userId = 58;
            ViewData["ulazniModel"] = new NovostiGetVM
            {
                rows = _context.Notifikacijes.Select(x => new NovostiGetVM.Row
                {
                    Naslov = x.Naslov,
                    Sadrzaj = x.Sadrzaj,
                    Datum_i_vrijeme_objave = x.Datum_i_vrijeme_objave,
                    KorisnikId = x.KorisnikId
                }).Where(x=>x.KorisnikId== userId).ToList()
            };

            return View("GetNovosti");
        }
    }
}