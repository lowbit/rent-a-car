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
        public VijestiController(MyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(
            int? pageNumber)
        {

            var vijesti = from v in _context.Vijestis select v;
            int pageSize = 5;
            return View("VijestiList", await PaginatedList<Vijesti>.CreateAsync(vijesti.AsNoTracking().OrderByDescending(v => v.Datum_i_vrijeme_objave), pageNumber ?? 1, pageSize));
            //return View(await _context.Vijestis.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vijest = await _context.Vijestis.Include(a => a.Autor).ThenInclude(k=>k.Korisnik).AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
            if (vijest == null)
                return NotFound();
            vijest.Ukupno_pregleda++;
            _context.Entry(vijest).CurrentValues.SetValues(vijest);
            _context.SaveChanges();
            return View("VijestiDetails", vijest);
        }
        public ActionResult AddEdit(int? id)
        {
            if(id == null)
                return View("VijestiAddEdit");
            return View("VijestiAddEdit", _context.Vijestis.FirstOrDefault(v=> v.Id == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind("Naslov, Slika, URL, Sadrzaj")] Vijesti model)
        {
            //Dodati logovanog korisnika kao autora i postaviti broj pregleda na 0
            try
            {
                if (ModelState.IsValid)
                {
                    model.Ukupno_pregleda = 0;
                    model.Datum_i_vrijeme_objave = DateTime.Now;
                    //Until login system implemented correctly
                    var kNalog = _context.Korisnicki_nalogs.FirstOrDefaultAsync();
                    model.AutorId = kNalog.Result.Id;

                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = model.Id });
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View("VijestiAddEdit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id, Naslov, Slika, URL, Sadrzaj")] Vijesti model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    model.Datum_i_vrijeme_objave = DateTime.Now;
                    //Until login system implemented correctly
                    var kNalog = _context.Korisnicki_nalogs.FirstOrDefaultAsync();
                    model.AutorId = kNalog.Result.Id;
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = model.Id });
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View("VijestiAddEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Vijesti vijest = new Vijesti() { Id = id };
                _context.Entry(vijest).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                //Log error once logging implemented
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
