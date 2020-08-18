using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rentacar.Data.EF;
using Rentacar.Data.Models;
using Rentacar.Web.ViewModels;

namespace Rentacar.Web.Controllers
{
    public class IznajmljivanjeController : Controller
    {
        private readonly MyContext _context;
        public IznajmljivanjeController(MyContext context)
        {
            _context = context;
        }
        [Authorize(Roles= "Administrator,Kupac")]
        public IActionResult Index()
        {
            var iznajmiVozilo = new IznajmljivanjeVozilaVM();
            iznajmiVozilo.ProizvodjaciList = _context.Proizvodjacis.ToListAsync().Result;
            iznajmiVozilo.ProizvodjaciList.Insert(0, new Proizvodjaci());
            iznajmiVozilo.ModeliList = new List<Modeli>();
            iznajmiVozilo.Datum_I_Vrijeme_Preuzimanja_Vozila = DateTime.Now.ToString("dd.MM.yyyy - HH:mm");
            iznajmiVozilo.Datum_I_Vrijeme_Vracanja_Vozila = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy - HH:mm");
            iznajmiVozilo.Popust = _context.Korisnicki_nalogs.Where(k => k.UserName == this.User.Identity.Name).Include(k => k.Korisnik).AsNoTracking().FirstOrDefault().Korisnik.Ostvareni_popust.ToString();
            return View("IznajmiVozilo", iznajmiVozilo);
        }
        public JsonResult GetModels(string proizvodjacId)
        {
            var list = _context.Modelis.Where(m => m.ProizvodjacId == int.Parse(proizvodjacId)).ToList();
            list.Insert(0, new Modeli());
            var response = Json(new SelectList(list, "Id", "Naziv"));
            return response;
        }
        public JsonResult GetVozila(string modelId)
        {
            var list = _context.Vozilas.Where(p => p.Podmodel.ModelID == int.Parse(modelId)).Include(v => v.Podmodel).AsNoTracking().ToList();
            var vozilo = new Vozila();
            var podmodel = new Podmodeli();
            podmodel.Vrsta_Motora = "";
            vozilo.Podmodel = podmodel;
            list.Insert(0, vozilo);
            return Json(new SelectList(list, "Id", "Podmodel.Vrsta_Motora"));
        }
        public JsonResult GetVoziloInfo(string voziloId, string odDatuma, string doDatuma)
        {
            if (voziloId != null && odDatuma != null && doDatuma != null){
                var vozilo = _context.Vozilas.Where(v => v.Id == int.Parse(voziloId)).Include(v => v.Podmodel).AsNoTracking().FirstOrDefault();
                var model = new IznajmljivanjeVozilaVM();

                model.Iznos_U_KM = getIznosIznajmljivanja(voziloId, odDatuma, doDatuma).ToString();
                model.Predjenja_Kilometraza = vozilo.Predjena_kilometraza;
                model.BrojRegistracije = vozilo.Broj_Registracije;
                model.BrojSjedista = vozilo.Podmodel.Broj_Sjedista;
                model.BrojVrata = vozilo.Podmodel.Broj_Vrata;
                model.BrojMotora = vozilo.Broj_Motora;
                model.BrojSasije = vozilo.Broj_sasije;
                model.ElPodStakla = vozilo.Elektricni_podizaci_stakla;
                model.GodinaProizvodnje = vozilo.Grodina_Proizvodnje;
                model.GrSjedista = vozilo.Grijaci_Sjedista;
                model.Klima = vozilo.Klima;
                model.MaxSnaga = vozilo.Podmodel.Maksimalna_Snaga_kW;
                model.Mjenjac = vozilo.Podmodel.Mijenjac;
                model.NavOprema = vozilo.Navigacijska_Oprema;
                model.Pogon = vozilo.Podmodel.Pogon;
                model.VrstaGoriva = vozilo.Podmodel.Vrsta_Goriva;
                model.ZrJastuci = vozilo.Zracni_Jastuci;

                return Json(model);
            } else
            {
                return Json("");
            }
        }
        public double getIznosIznajmljivanja(string voziloId, string odDatuma, string doDatuma)
        {
            double basePricePerDay = 120;
            double baseMultiplier = 1;
            var popust = _context.Korisnicki_nalogs.Where(k => k.UserName == this.User.Identity.Name).Include(k=>k.Korisnik).AsNoTracking().FirstOrDefault().Korisnik.Ostvareni_popust;
            DateTime parsedOd = DateTime.ParseExact(odDatuma, "dd.MM.yyyy - HH:mm", null);
            DateTime parsedDo = DateTime.ParseExact(doDatuma, "dd.MM.yyyy - HH:mm", null);
            var ukupanBrojDana = (parsedDo - parsedOd).TotalDays;
            var voziloZaIznajmiti = _context.Vozilas.Where(v => v.Id == int.Parse(voziloId)).Include(v => v.Podmodel).AsNoTracking().FirstOrDefault();
            //Calculate mutiplier for vehicle
            if(voziloZaIznajmiti.Klima == true)
            {
                baseMultiplier += 0.1;
            }
            if (voziloZaIznajmiti.Navigacijska_Oprema == true)
            {
                baseMultiplier += 0.1;
            }
            if (voziloZaIznajmiti.Grijaci_Sjedista == true)
            {
                baseMultiplier += 0.15;
            }
            if (voziloZaIznajmiti.Podmodel.Mijenjac.Equals("Automatic"))
            {
                baseMultiplier += 0.15;
            }
            if (int.Parse(voziloZaIznajmiti.Podmodel.Maksimalna_Snaga_kW)>100)
            {
                baseMultiplier += 0.2;
            }
            if (int.Parse(voziloZaIznajmiti.Predjena_kilometraza)>100000)
            {
                baseMultiplier -= 0.2;
            }
            double starostGod = DateTime.Now.Year - int.Parse(voziloZaIznajmiti.Grodina_Proizvodnje);
            starostGod = starostGod * 0.04;
            baseMultiplier -= starostGod;
            baseMultiplier += popust * 0.01;

            var ukupanIznos = basePricePerDay * baseMultiplier * ukupanBrojDana;
            ukupanIznos = Math.Round(ukupanIznos, 2, MidpointRounding.ToEven);
            return ukupanIznos;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IznajmiVozilo(IznajmljivanjeVozilaVM iznajmi)
        {
            if (iznajmi.Vozilo == "0")
            {
                ModelState.AddModelError("Vozilo", "Izaberite vozilo");
            }
            if (ModelState.IsValid)
            {
                var nalog = new Nalog();
                nalog.Datum_I_Vrijeme_Izdavanja = DateTime.Now;
                nalog.Datum_I_Vrijeme_Preuzimanja_Vozila = DateTime.ParseExact(iznajmi.Datum_I_Vrijeme_Preuzimanja_Vozila, "dd.MM.yyyy - HH:mm", null);
                nalog.Datum_I_Vrijeme_Vracanja_Vozila = DateTime.ParseExact(iznajmi.Datum_I_Vrijeme_Vracanja_Vozila, "dd.MM.yyyy - HH:mm", null);
                //Izracunati ponovo na server side cijenu zbog client side tempering-a
                nalog.Iznos_U_KM = getIznosIznajmljivanja(iznajmi.Vozilo, iznajmi.Datum_I_Vrijeme_Preuzimanja_Vozila, iznajmi.Datum_I_Vrijeme_Vracanja_Vozila).ToString();
                nalog.KorisnikID = _context.Korisnicki_nalogs.Where(k => k.UserName == this.User.Identity.Name).FirstOrDefault().KorisnikId;
                //pocetna kilometraza za nalog je do sad predjena kilometraza
                nalog.Pocetna_Kilometraza = iznajmi.Predjenja_Kilometraza;
                nalog.Popust = iznajmi.Popust;
                nalog.VoziloID = int.Parse(iznajmi.Vozilo);
                nalog.ZaposlenikID = _context.Zaposlenicis.FirstOrDefault().Id;
                try
                {
                    _context.Nalogs.Add(nalog);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            iznajmi.ProizvodjaciList = _context.Proizvodjacis.ToListAsync().Result;
            iznajmi.ProizvodjaciList.Insert(0, new Proizvodjaci());
            iznajmi.ModeliList = new List<Modeli>();
            iznajmi.ModeliList = new List<Modeli>();
            return View("IznajmiVozilo", iznajmi);
        }
    }
}
