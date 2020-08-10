using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentacar.Data.EF;
using Rentacar.Data.Models;
using Rentacar.Web.ViewModels;

namespace Rentacar.Web.Controllers
{
    public class KorisnikController : Controller
    {
        private MyContext _context;
        public KorisnikController (MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            var register = new RegisterVM();
            register.Opstine = _context.Opcines.ToListAsync().Result;
            return View("RegisterUser", register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM registerUser)
        {
            try
            {
                var usernameExists = _context.Korisnicki_nalogs.FirstOrDefault(u => u.Korsnicko_ime == registerUser.Username);
                if (usernameExists != null)
                    ModelState.AddModelError("Username", "Korisnik sa ovim korisnickim imenom vec postoji");
                var emailExists = _context.Korisnicis.FirstOrDefault(u => u.Email == registerUser.Email);
                if (emailExists != null)
                    ModelState.AddModelError("Email", "Korisnik sa ovim Email-om vec postoji");
                if (ModelState.IsValid)
                {
                    Korisnicki_nalog nalog = new Korisnicki_nalog();
                    Korisnici korisnik = new Korisnici();
                    korisnik.Email = registerUser.Email;
                    korisnik.Ime = registerUser.Ime;
                    korisnik.Prezime = registerUser.Prezime;
                    korisnik.OpcinaId = registerUser.Opstina;
                    nalog.Korisnik = korisnik;
                    nalog.Datum_prijave = DateTime.Now.ToString();
                    nalog.Korsnicko_ime = registerUser.Username;
                    nalog.Lozinka = registerUser.Password;
                    //Default new user is "Kupac"
                    nalog.TipId = _context.Tipovi_korisnickog_nalogas.First(tip => tip.Naziv == "Kupac").Id;
                    _context.Korisnicki_nalogs.Add(nalog);
                    _context.SaveChanges();

                    return RedirectToAction("Login", "Korisnik", new { tekRegistrovan = true });
                }
                registerUser.Password = "";
                registerUser.ConfirmPassword = "";
                registerUser.Opstine = _context.Opcines.ToListAsync().Result;
                return View("RegisterUser", registerUser);
            } 
            catch (Exception ex)
            {
                registerUser.Password = "";
                registerUser.ConfirmPassword = "";
                registerUser.Opstine = _context.Opcines.ToListAsync().Result;
                return View("RegisterUser", registerUser);
            }
        }
        public IActionResult Login(bool tekRegistrovan)
        {
            LoginVM loginModel = new LoginVM();
            if (tekRegistrovan)
                loginModel.novoRegistrovan = true;
            return View("LoginUser", loginModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginUser(LoginVM loginUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var korisnik = _context.Korisnicki_nalogs.FirstOrDefault(k => k.Korsnicko_ime == loginUser.Username && k.Lozinka == loginUser.Password);
                    if (korisnik != null)
                        return RedirectToAction("Index", "Home");
                    else
                        ModelState.AddModelError("Password", "Korisnicko Ime ili password pogresan!");
                }
                loginUser.Password = "";
                return View("LoginUser", loginUser);
            }
            catch (Exception ex)
            {
                loginUser.Password = "";
                return View("LoginUser", loginUser);
            }
        }
    }
}
