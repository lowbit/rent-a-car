using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Index()
        {
            var userId = _context.Korisnicki_nalogs.Where(k => k.UserName == this.User.Identity.Name).FirstOrDefault().Id;
            ViewData["ulazniModel"] = new NovostiGetVM
            {
                rows = _context.Notifikacijes.Select(x => new NovostiGetVM.Row
                {
                    Naslov = x.Naslov,
                    Sadrzaj = x.Sadrzaj,
                    Datum_i_vrijeme_objave = x.Datum_i_vrijeme_objave,
                    KorisnikId = x.KorisnikId,
                    Id = x.Id
                }).Where(x=>x.KorisnikId == userId).OrderByDescending(x=>x.Id).ToList()
            };
            var novosti = _context.Notifikacijes.Where(n => n.KorisnikId == userId).ToList();
            novosti.ForEach(n => n.Datum_i_vrijeme_pregleda = DateTime.Now.ToString());
            _context.SaveChanges();
            return View("GetNovosti");
        }
        [Authorize]
        public JsonResult GetNumberOfNewNotifications()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var id = _context.Korisnicki_nalogs.Where(k => k.UserName == this.User.Identity.Name).FirstOrDefault().Id;
                var numberOfNotifications = _context.Notifikacijes.Where(n => n.KorisnikId == id && n.Datum_i_vrijeme_pregleda==null).Count();
                return Json(numberOfNotifications);
            }
            return Json(0);
        }
    }
}