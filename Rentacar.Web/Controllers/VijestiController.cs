using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rentacar.Data.EF;
using Rentacar.Data.Models;
using Rentacar.Web.Shared;
using Rentacar.Web.ViewModels;

namespace Rentacar.Web.Controllers
{
    public class VijestiController : Controller
    {
        private MyContext _context;

        private readonly IHostingEnvironment _appEnvironment;
        public VijestiController(MyContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;

            _appEnvironment = appEnvironment;
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
            var vijest = await _context.Vijestis.Include(a => a.Autor).ThenInclude(k => k.Korisnik).AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
            if (vijest == null)
                return NotFound();
            vijest.Ukupno_pregleda++;
            _context.Update(vijest);
            _context.SaveChanges();
            VijestDetailVM vijestVM = new VijestDetailVM();
            vijestVM.Vijest = vijest;

            vijestVM.Komentari = await _context.Komentaris.Where(k => k.VijestId == id).Include(a => a.Autor).ThenInclude(k => k.Korisnik).AsNoTracking().OrderByDescending(k=>k.Id).ToListAsync();
            vijestVM.NoviKomentar = new Komentari();
            return View("VijestiDetails", vijestVM);
        }
        [Authorize(Roles ="Administrator")]
        public ActionResult AddEdit(int? id)
        {
            if (id == null)
                return View("VijestiAddEdit", new Vijesti());
            return View("VijestiAddEdit", _context.Vijestis.FirstOrDefault(v => v.Id == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind("Naslov, Slika, URL, Sadrzaj")] Vijesti model, IFormFile file)
        {
            var filePath = UploadImage(file).Result;
            if (filePath == "")
            {
                ModelState.AddModelError("Slika", "Niste dodali sliku za upload");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    model.Ukupno_pregleda = 0;
                    model.Datum_i_vrijeme_objave = DateTime.Now;

                    var kNalog = _context.Korisnicki_nalogs.Where(k=>k.UserName == this.User.Identity.Name).FirstOrDefault();
                    model.AutorId = kNalog.Id;
                    model.Slika = filePath;
                    _context.Add(model);
                    _context.SaveChanges();
                    var korisnici = _context.Korisnicki_nalogs.ToList();
                    List<Notifikacije> notifikacije = new List<Notifikacije>();
                    korisnici.ForEach(k =>
                    {
                        var obavijest = new Notifikacije();
                        obavijest.Datum_i_vrijeme_objave = DateTime.Now.ToString();
                        obavijest.Naslov = "Nova Vijest";
                        obavijest.Sadrzaj = "Procitajte objavljenu vijest: " + "<a href='/Vijesti/Details/" + model.Id + "'>" + model.Naslov + "</a>";
                        obavijest.KorisnikId = k.Id;
                        notifikacije.Add(obavijest);
                    });
                    _context.Notifikacijes.AddRange(notifikacije);
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
        public async Task<ActionResult> Edit([Bind("Id, Naslov, Slika, URL, Sadrzaj, Ukupno_pregleda")] Vijesti model, IFormFile file)
        {
            var filePath = UploadImage(file).Result;
            try
            {
                if (ModelState.IsValid)
                {
                    if (filePath != "")
                    {
                        model.Slika = filePath;
                    }
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

        public async Task<string> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "";

            var timeString = DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss.");
            string path_Root = _appEnvironment.WebRootPath;
            string path_to_Images = path_Root + "\\images\\vijesti\\" + timeString + file.FileName;
            using (var stream = new FileStream(path_to_Images, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            ViewData["FilePath"] = path_to_Images;
            var filePath = "images/vijesti/" + timeString + file.FileName;
            return filePath;
        }
        public IActionResult AddKomentar()
        {
            return RedirectToAction("Index", "Vijesti");
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddKomentar(VijestDetailVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.NoviKomentar.VijestId = model.Vijest.Id;
                    model.NoviKomentar.Datum_objave = DateTime.Now;
                    var kNalog = _context.Korisnicki_nalogs.Where(k=>k.UserName==this.User.Identity.Name).FirstOrDefaultAsync();
                    model.NoviKomentar.AutorId = kNalog.Result.Id;
                    _context.Add(model.NoviKomentar);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = model.Vijest.Id });
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction(nameof(Details), new { id = model.Vijest.Id });
        }
    }
}
