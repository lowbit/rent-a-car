using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<Korisnicki_nalog> _signInManager;
        private readonly UserManager<Korisnicki_nalog> _userManager;

        public KorisnikController (MyContext context, SignInManager<Korisnicki_nalog> signInManager, UserManager<Korisnicki_nalog> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
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
        [Authorize]
        public IActionResult UserDetails()
        {
            var korisnicki_nalog = _context.Korisnicki_nalogs.Where(k => k.UserName == this.User.Identity.Name).Include(k=>k.Korisnik).ThenInclude(k=>k.Opcina).AsNoTracking().FirstOrDefault();
            var userDetails = new UserDetailsVM();
            userDetails.firstName = korisnicki_nalog.Korisnik.Ime;
            userDetails.lastName = korisnicki_nalog.Korisnik.Prezime;
            userDetails.username = korisnicki_nalog.UserName;
            userDetails.email = korisnicki_nalog.Email;
            userDetails.opstina = korisnicki_nalog.Korisnik.Opcina.Naziv;
            return View("UserDetails", userDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterVM registerUser)
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
                    nalog.UserName = registerUser.Username;
                    nalog.Email = registerUser.Email;
                    //_context.Korisnicki_nalogs.Add(nalog);
                    //_context.SaveChanges();
                    var result = await _userManager.CreateAsync(nalog, registerUser.Password);
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create new user with Identity");
                    }
                    //Default new user is "Kupac"
                    await _userManager.AddToRoleAsync(nalog, "Kupac");

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
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            LoginVM loginModel = new LoginVM(); 
            if (Request.Query.Keys.Contains("ReturnUrl"))
            {
                loginModel.ReturnUrl = Request.Query["ReturnUrl"].First();
            }
            if (tekRegistrovan)
            {
                loginModel.NovoRegistrovan = true;
            }
            return View("LoginUser", loginModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginUser, string RedirectUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(loginUser.Username, loginUser.Password, loginUser.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if (loginUser.ReturnUrl!= null)
                        {
                            return Redirect(loginUser.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Korisnicko Ime ili password pogresan!");
                    }
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
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); 
        }
        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
    }
}
