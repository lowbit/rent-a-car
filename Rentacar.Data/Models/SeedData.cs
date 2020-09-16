using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rentacar.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Data.Models
{
    public class SeedData
    {
        private readonly MyContext _context;
        private readonly UserManager<Korisnicki_nalog> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedData(MyContext context, UserManager<Korisnicki_nalog> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Initialize()
        {
            _context.Database.EnsureCreated();
            if (!_context.Gradovis.Any())
            {
                _context.Gradovis.AddRange(
                    new Gradovi
                    {
                        Naziv = "Sarajevo",
                        Postanski_broj = "71000"
                    });
                _context.SaveChanges();
            }
            if (!_context.Opcines.Any())
            {
                _context.Opcines.AddRange(
                    new Opcine
                    {
                        Naziv = "Novi Grad",
                        GradId = _context.Gradovis.First().Id
                    },
                    new Opcine
                    {
                        Naziv = "Centar",
                        GradId = _context.Gradovis.First().Id
                    },
                    new Opcine
                    {
                        Naziv = "Hadžići",
                        GradId = _context.Gradovis.First().Id
                    },
                    new Opcine
                    {
                        Naziv = "Novo Sarajevo",
                        GradId = _context.Gradovis.First().Id
                    },
                    new Opcine
                    {
                        Naziv = "Ilidža",
                        GradId = _context.Gradovis.First().Id
                    },
                    new Opcine
                    {
                        Naziv = "Ilijaš",
                        GradId = _context.Gradovis.First().Id
                    },
                    new Opcine
                    {
                        Naziv = "Stari Grad",
                        GradId = _context.Gradovis.First().Id
                    },
                    new Opcine
                    {
                        Naziv = "Trnovo",
                        GradId = _context.Gradovis.First().Id
                    },
                    new Opcine
                    {
                        Naziv = "Vogošća",
                        GradId = _context.Gradovis.First().Id
                    });
                _context.SaveChanges();
            }
            if (!_context.Korisnicis.Any())
            {
                _context.Korisnicis.AddRange(
                    new Korisnici
                    {
                        Ime = "Rijad",
                        Prezime = "Spahic",
                        OpcinaId = _context.Opcines.First().Id,
                        Ostvareni_popust = 0
                    },
                    new Korisnici
                    {
                        Ime = "Mark",
                        Prezime = "Johnson",
                        OpcinaId = _context.Opcines.First().Id,
                        Ostvareni_popust = 10
                    },
                    new Korisnici
                    {
                        Ime = "William",
                        Prezime = "Donaldson",
                        OpcinaId = _context.Opcines.First().Id,
                        Ostvareni_popust = 10
                    },
                    new Korisnici
                    {
                        Ime = "Stevie",
                        Prezime = "Clerk",
                        OpcinaId = _context.Opcines.First().Id,
                        Ostvareni_popust = 10
                    },
                    new Korisnici
                    {
                        Ime = "John",
                        Prezime = "Doe",
                        OpcinaId = _context.Opcines.First().Id,
                        Ostvareni_popust = 10
                    });
                _context.SaveChanges();
            }
            var role1 = new IdentityRole()
            {
                Name = "Administrator"
            };
            var role2 = new IdentityRole()
            {
                Name = "Kupac"
            };
            var role3 = new IdentityRole()
            {
                Name = "Marketing"
            };
            var role4 = new IdentityRole()
            {
                Name = "Prodavac"
            };
            var role5 = new IdentityRole()
            {
                Name = "Logistika"
            };
            var roleExists = await _roleManager.FindByNameAsync("Administrator");
            if (roleExists == null)
            {
                await _roleManager.CreateAsync(role1);
                await _roleManager.CreateAsync(role2);
                await _roleManager.CreateAsync(role3);
                await _roleManager.CreateAsync(role4);
                await _roleManager.CreateAsync(role5);
            }
                
            if (!_context.Korisnicki_nalogs.Any())
            {
                Korisnicki_nalog user = new Korisnicki_nalog()
                {
                    Korsnicko_ime = "administrator",
                    UserName = "administrator",
                    Email = "test@gmail.com",
                    Datum_prijave = DateTime.Now.ToString(),
                    KorisnikId = _context.Korisnicis.ToList()[0].Id
                };
                var result = await _userManager.CreateAsync(user, "S@rajev0");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user with Identity");
                }
                Korisnicki_nalog user2 = new Korisnicki_nalog()
                {
                    Korsnicko_ime = "korisnik",
                    UserName = "korisnik",
                    Email = "test2@gmail.com",
                    Datum_prijave = DateTime.Now.ToString(),
                    KorisnikId = _context.Korisnicis.ToList()[1].Id
                };
                result = await _userManager.CreateAsync(user2, "S@rajev0");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user with Identity");
                }
                //Add users to roles
                await _userManager.AddToRoleAsync(user, role1.Name);
                await _userManager.AddToRoleAsync(user2, role2.Name);

                _context.SaveChanges();
            }
            if (!_context.Vijestis.Any())
            {
                _context.Vijestis.AddRange(
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Otvaranje novog salona",
                       Sadrzaj = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                       "labore et dolore magna aliqua. Elementum nisi quis eleifend quam adipiscing vitae proin sagittis nisl. " +
                       "Consectetur libero id faucibus nisl tincidunt. Aliquet bibendum enim facilisis gravida. Leo a diam sollicitudin" +
                       " tempor id eu. Mattis ullamcorper velit sed ullamcorper. Magnis dis parturient montes nascetur ridiculus mus mauris" +
                       " vitae. Nibh tellus molestie nunc non blandit massa enim nec dui. Libero volutpat sed cras ornare arcu dui vivamus arcu." +
                       " Mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare. Non consectetur a erat nam at. Ac odio tempor orci dapibus " +
                       "ultrices in iaculis. Mauris augue neque gravida in fermentum et. Id consectetur purus ut faucibus pulvinar. Dolor sit amet" +
                       " consectetur adipiscing elit. Viverra nam libero justo laoreet. Posuere ac ut consequat semper.Ipsum suspendisse ultrices" +
                       " gravida dictum fusce ut.Sagittis nisl rhoncus mattis rhoncus urna neque.Nunc sed id semper risus in hendrerit.Orci ac auctor" +
                       " augue mauris augue neque gravida in fermentum.Pulvinar pellentesque habitant morbi tristique senectus.Volutpat maecenas volutpat " +
                       "blandit aliquam etiam.Arcu bibendum at varius vel.Aliquet eget sit amet tellus cras adipiscing enim.Et pharetra pharetra massa" +
                       " massa ultricies mi quis hendrerit dolor.Ut sem viverra aliquet eget sit amet tellus.Facilisi etiam dignissim diam quis enim." +
                       "Dignissim cras tincidunt lobortis feugiat vivamus at augue eget arcu.Rhoncus aenean vel elit scelerisque mauris pellentesque pulvinar. " +
                       "Mi sit amet mauris commodo quis imperdiet massa tincidunt.Facilisi morbi tempus iaculis urna id.Non nisi est sit amet facilisis " +
                       "magna.Ipsum dolor sit amet consectetur adipiscing.Morbi tempus iaculis urna id volutpat.Facilisi nullam vehicula ipsum a arcu" +
                       " cursus vitae congue mauris.In fermentum et sollicitudin ac.Elementum sagittis vitae et leo duis ut diam.Nec feugiat in fermentum" +
                       " posuere urna.Massa eget egestas purus viverra.Tempus imperdiet nulla malesuada pellentesque elit.In metus vulputate eu scelerisque" +
                       " felis imperdiet proin fermentum leo.Aliquet eget sit amet tellus cras adipiscing enim eu.Mattis vulputate enim nulla aliquet" +
                       " porttitor lacus luctus accumsan.Eu non diam phasellus vestibulum lorem sed risus ultricies.Nisi porta lorem mollis aliquam ut " +
                       "porttitor leo a.Est sit amet facilisis magna etiam tempor orci eu lobortis. Fames ac turpis egestas integer eget aliquet nibh" +
                       " praesent.Etiam tempor orci eu lobortis elementum nibh.Varius morbi enim nunc faucibus a pellentesque sit amet.Eleifend mi in " +
                       "nulla posuere sollicitudin.Pellentesque id nibh tortor id aliquet.Eget gravida cum sociis natoque penatibus et magnis.Massa eget" +
                       " egestas purus viverra accumsan in. Viverra aliquet eget sit amet tellus.Sed velit dignissim sodales ut eu sem.Rhoncus est" +
                       " pellentesque elit ullamcorper.Proin gravida hendrerit lectus a.Fringilla phasellus faucibus scelerisque eleifend donec." +
                       "Tellus rutrum tellus pellentesque eu tincidunt tortor aliquam nulla facilisi.Neque aliquam vestibulum morbi blandit cursus risus." +
                       "Commodo viverra maecenas accumsan lacus vel facilisis.Sem viverra aliquet eget sit amet tellus cras adipiscing.Odio pellentesque" +
                       " diam volutpat commodo sed egestas egestas fringilla phasellus.Eu feugiat pretium nibh ipsum consequat nisl vel.Et malesuada " +
                       "fames ac turpis egestas.Porttitor massa id neque aliquam vestibulum morbi blandit cursus risus.Eget felis eget nunc lobortis " +
                       "mattis aliquam.Cursus eget nunc scelerisque viverra mauris.Cras adipiscing enim eu turpis egestas pretium aenean pharetra " +
                       "magna.Sed nisi lacus sed viverra.Dictum varius duis at consectetur lorem donec.Blandit cursus risus at ultrices mi.Id faucibus " +
                       "nisl tincidunt eget nullam non nisi est.Ut etiam sit amet nisl purus in mollis.Dignissim convallis aenean et tortor at risus" +
                       " viverra adipiscing at.Sed vulputate odio ut enim blandit volutpat maecenas.Egestas quis ipsum suspendisse ultrices gravida dictum " +
                       "fusce ut.Ultrices vitae auctor eu augue ut.Eget lorem dolor sed viverra.Diam sollicitudin tempor id eu nisl nunc mi.",
                       Slika = "images/vijesti/otvaranje.jpg",
                       Ukupno_pregleda = 20
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Nabavka novih automobila",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/ponuda.jpg",
                       Ukupno_pregleda = 30
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Uživajte u pogodnostima na svim  PumpaTM pumpama sa rent-a-car karticom",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/pumpa.jpg",
                       Ukupno_pregleda = 4
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Samo najbolje za vas, nova C klasa u ponudi",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/cclass.jpg",
                       Ukupno_pregleda = 0
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Sva auta redovno servisirana",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/carservice.jpg",
                       Ukupno_pregleda = 1
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Sponzor Goodyear gume, samo najbolje",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/goodyear.jpg",
                       Ukupno_pregleda = 2
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "50% sniženje 06.2020 - 08.2020",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/50.png",
                       Ukupno_pregleda = 6
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Otvorena nova lokacija kod aerodroma",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/aerodrom.jpg",
                       Ukupno_pregleda = 3
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Novi F30 u prostorijama Rent-a-car",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/f30.jpg",
                       Ukupno_pregleda = 2
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Premium osigurnaje po nižoj cijeni",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/osiguranje.png",
                       Ukupno_pregleda = 3
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Sniženja i do 30%",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/30.png",
                       Ukupno_pregleda = 5
                   },
                   new Vijesti
                   {
                       AutorId = _context.Korisnicki_nalogs.First().Id,
                       Datum_i_vrijeme_objave = DateTime.Now,
                       Naslov = "Nova ponuda",
                       Sadrzaj = "Feugiat pretium nibh ipsum consequat nisl vel pretium. Sed felis eget velit aliquet sagittis id consectetur." +
                       " Phasellus egestas tellus rutrum tellus pellentesque eu. Molestie at elementum eu facilisis sed odio morbi quis. " +
                       "Donec enim diam vulputate ut pharetra sit. Parturient montes nascetur ridiculus mus mauris. Eleifend mi in nulla posuere sollicitudin. " +
                       "Donec massa sapien faucibus et molestie ac. Vitae tempus quam pellentesque nec nam aliquam. Ut tellus elementum sagittis vitae et leo duis ut." +
                       "Parturient montes nascetur ridiculus mus.Ipsum nunc aliquet bibendum enim facilisis.Luctus venenatis lectus magna fringilla urna porttitor" +
                       " rhoncus dolor.Viverra nam libero justo laoreet sit amet cursus.Quis commodo odio aenean sed adipiscing diam donec.Tortor id aliquet lectus " +
                       "proin nibh.In metus vulputate eu scelerisque felis imperdiet proin.Scelerisque eleifend donec pretium vulputate sapien nec sagittis aliquam." +
                       "Tempor nec feugiat nisl pretium fusce id velit ut tortor.Dictum fusce ut placerat orci nulla.At augue eget arcu dictum.Urna cursus eget nunc " +
                       "scelerisque.Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque.Lorem ipsum dolor sit amet.Donec et odio pellentesque diam " +
                       "volutpat commodo sed. Bibendum at varius vel pharetra vel turpis nunc eget lorem.Tellus orci ac auctor augue mauris augue.Integer eget aliquet" +
                       " nibh praesent.Nec sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae.Lectus vestibulum mattis ullamcorper velit sed" +
                       " ullamcorper morbi tincidunt ornare.Justo eget magna fermentum iaculis eu non diam.Diam maecenas sed enim ut sem viverra.Faucibus turpis in eu " +
                       "mi bibendum neque.Turpis massa tincidunt dui ut ornare lectus.Non curabitur gravida arcu ac tortor.Nulla pharetra diam sit amet nisl suscipit " +
                       "adipiscing bibendum est.Ac auctor augue mauris augue neque.Feugiat vivamus at augue eget arcu dictum.Consectetur lorem donec massa sapien faucibus" +
                       " et molestie ac feugiat.",
                       Slika = "images/vijesti/novaponuda.png",
                       Ukupno_pregleda = 6
                   });
                _context.SaveChanges();
            }
            if (!_context.Notifikacijes.Any())
            {
                _context.Notifikacijes.AddRange(
                    new Notifikacije
                    {
                        Datum_i_vrijeme_objave = DateTime.Now.ToString(),
                        KorisnikId = _context.Korisnicki_nalogs.First().Id,
                        Naslov = "Dobro došli na rent-a-car aplikaciju",
                        Sadrzaj = "Pregledajte šta trenutno imamo u ponudi!"
                    });
             }
            if (!_context.Komentaris.Any())
            {
                _context.Komentaris.AddRange(
                    new Komentari
                    {
                        AutorId = _context.Korisnicki_nalogs.First().Id,
                        Datum_objave = DateTime.Now,
                        VijestId = _context.Vijestis.First().Id,
                        Sadrzaj = "Testni komentar na vijest 233134e21541512"
                    });
                _context.SaveChanges();
            }
            if (!_context.Proizvodjacis.Any())
            {
                _context.Proizvodjacis.AddRange(
                    new Proizvodjaci
                    {
                        Naziv = "Volkswagen",
                        Zemlja_Porijekla = "Germany"
                    }, 
                    new Proizvodjaci
                    {
                        Naziv = "BMW",
                        Zemlja_Porijekla = "Germany"
                    },
                    new Proizvodjaci
                    {
                        Naziv = "Peugeot",
                        Zemlja_Porijekla = "France"
                    });
                _context.SaveChanges();
            }
            if (!_context.Modelis.Any())
            {
                _context.Modelis.AddRange(
                    new Modeli
                    {
                        Naziv = "Golf 7",
                        ProizvodjacId = 1,
                        Tip_vozila = "Hatchback"
                    }, 
                    new Modeli
                    {
                        Naziv = "3 Serija",
                        ProizvodjacId = 2,
                        Tip_vozila = "Sedan"
                    },
                    new Modeli
                    {
                        Naziv = "5 Serija",
                        ProizvodjacId = 2,
                        Tip_vozila = "Sedan"
                    },
                    new Modeli
                    {
                        Naziv = "207",
                        ProizvodjacId = 3,
                        Tip_vozila = "Hatchback"
                    },
                    new Modeli
                    {
                        Naziv = "307",
                        ProizvodjacId = 3,
                        Tip_vozila = "Hatchback"
                    });
                _context.SaveChanges();
            }
            if (!_context.Podmodelis.Any())
            {
                _context.Podmodelis.AddRange(
                    new Podmodeli
                    {
                        ModelID = 11,
                        Broj_Sjedista = "5",
                        Broj_Vrata = "5",
                        Maksimalna_Snaga_kW = "77",
                        Mijenjac = "Manual",
                        Pogon = "Prednji",
                        Vrsta_Goriva = "Diesel",
                        Vrsta_Motora = "2.0 TDI"
                    },
                    new Podmodeli
                    {
                        ModelID = 12,
                        Broj_Sjedista = "5",
                        Broj_Vrata = "3",
                        Maksimalna_Snaga_kW = "125",
                        Mijenjac = "Automatic",
                        Pogon = "Zadnji",
                        Vrsta_Goriva = "Diesel",
                        Vrsta_Motora = "2.0D"
                    },
                    new Podmodeli
                    {
                        ModelID = 13,
                        Broj_Sjedista = "5",
                        Broj_Vrata = "5",
                        Maksimalna_Snaga_kW = "125",
                        Mijenjac = "Automatic",
                        Pogon = "XDrive",
                        Vrsta_Goriva = "Diesel",
                        Vrsta_Motora = "2.0D"
                    },
                    new Podmodeli
                    {
                        ModelID = 14,
                        Broj_Sjedista = "5",
                        Broj_Vrata = "3",
                        Maksimalna_Snaga_kW = "66",
                        Mijenjac = "Manual",
                        Pogon = "Prednji",
                        Vrsta_Goriva = "Diesel",
                        Vrsta_Motora = "1.6D"
                    },
                    new Podmodeli
                    {
                        ModelID = 15,
                        Broj_Sjedista = "5",
                        Broj_Vrata = "3",
                        Maksimalna_Snaga_kW = "66",
                        Mijenjac = "Manual",
                        Pogon = "Prednji",
                        Vrsta_Goriva = "Diesel",
                        Vrsta_Motora = "1.6D"
                    });
                _context.SaveChanges();
            }
            if (!_context.Vozilas.Any())
            {
                _context.Vozilas.AddRange(
                    new Vozila
                    {
                        PodmodelId = 3,
                        Daljinsko_otkljucavanje = true,
                        Grijaci_Sjedista = true,
                        Elektricni_podizaci_stakla = true,
                        Zracni_Jastuci = true,
                        Klima = true,
                        Navigacijska_Oprema = false,
                        Datum_Isteka_Registracije = new DateTime(2021,05,23),
                        Datum_Prve_Registracije = new DateTime(2017, 01, 16),
                        Datum_Registracije = new DateTime(2020, 05, 23),
                        Broj_Motora = "OIUfhh*73JI",
                        Broj_sasije = "5325235253",
                        Broj_Registracije = "A-733-284",
                        Grodina_Proizvodnje = "2017",
                        Predjena_kilometraza = "84766",
                        Zamjena_ulja = "88000",
                    },
                    new Vozila
                    {
                        PodmodelId = 4,
                        Daljinsko_otkljucavanje = true,
                        Grijaci_Sjedista = true,
                        Elektricni_podizaci_stakla = true,
                        Zracni_Jastuci = true,
                        Klima = true,
                        Navigacijska_Oprema = true,
                        Datum_Isteka_Registracije = new DateTime(2021, 04, 23),
                        Datum_Prve_Registracije = new DateTime(2018, 01, 22),
                        Datum_Registracije = new DateTime(2020, 04, 23),
                        Broj_Motora = "3ifj29uhnf9",
                        Broj_sasije = "8932984789234",
                        Broj_Registracije = "A-133-222",
                        Grodina_Proizvodnje = "2018",
                        Predjena_kilometraza = "33766",
                        Zamjena_ulja = "36000",
                    },
                    new Vozila
                    {
                        PodmodelId = 5,
                        Daljinsko_otkljucavanje = true,
                        Grijaci_Sjedista = true,
                        Elektricni_podizaci_stakla = true,
                        Zracni_Jastuci = true,
                        Klima = true,
                        Navigacijska_Oprema = true,
                        Datum_Isteka_Registracije = new DateTime(2021, 01, 01),
                        Datum_Prve_Registracije = new DateTime(2019, 11, 12),
                        Datum_Registracije = new DateTime(2020, 01, 01),
                        Broj_Motora = "HJD*&U@fIOJ",
                        Broj_sasije = "3254325623",
                        Broj_Registracije = "B-111-111",
                        Grodina_Proizvodnje = "2019",
                        Predjena_kilometraza = "21766",
                        Zamjena_ulja = "28000",
                    },
                    new Vozila
                    {
                        PodmodelId = 6,
                        Daljinsko_otkljucavanje = true,
                        Grijaci_Sjedista = true,
                        Elektricni_podizaci_stakla = true,
                        Zracni_Jastuci = true,
                        Klima = true,
                        Navigacijska_Oprema = false,
                        Datum_Isteka_Registracije = new DateTime(2021, 05, 23),
                        Datum_Prve_Registracije = new DateTime(2015, 01, 25),
                        Datum_Registracije = new DateTime(2020, 05, 23),
                        Broj_Motora = "FUWHJ8987",
                        Broj_sasije = "6436346734",
                        Broj_Registracije = "V-722-124",
                        Grodina_Proizvodnje = "2014",
                        Predjena_kilometraza = "145766",
                        Zamjena_ulja = "150000",
                    },
                    new Vozila
                    {
                        PodmodelId = 7,
                        Daljinsko_otkljucavanje = true,
                        Grijaci_Sjedista = true,
                        Elektricni_podizaci_stakla = true,
                        Zracni_Jastuci = true,
                        Klima = true,
                        Navigacijska_Oprema = false,
                        Datum_Isteka_Registracije = new DateTime(2021, 05, 23),
                        Datum_Prve_Registracije = new DateTime(2017, 03, 12),
                        Datum_Registracije = new DateTime(2020, 05, 23),
                        Broj_Motora = "NFWIJHI5675",
                        Broj_sasije = "5326267423",
                        Broj_Registracije = "B-274-553",
                        Grodina_Proizvodnje = "2017",
                        Predjena_kilometraza = "85766",
                        Zamjena_ulja = "89000",
                    },
                    new Vozila
                    {
                        PodmodelId = 7,
                        Daljinsko_otkljucavanje = true,
                        Grijaci_Sjedista = true,
                        Elektricni_podizaci_stakla = true,
                        Zracni_Jastuci = true,
                        Klima = true,
                        Navigacijska_Oprema = true,
                        Datum_Isteka_Registracije = new DateTime(2021, 05, 23),
                        Datum_Prve_Registracije = new DateTime(2018, 01, 15),
                        Datum_Registracije = new DateTime(2020, 05, 23),
                        Broj_Motora = "IUWFFWHG7687",
                        Broj_sasije = "35265236632",
                        Broj_Registracije = "B-274-554",
                        Grodina_Proizvodnje = "2018",
                        Predjena_kilometraza = "44726",
                        Zamjena_ulja = "50000",
                    });
                _context.SaveChanges();
            }
            if (!_context.Zaposlenicis.Any())
            {
                _context.Zaposlenicis.AddRange(
                    new Zaposlenici
                    {
                        Adresa = "Adresa 1",
                        GradID = _context.Gradovis.FirstOrDefault().Id,
                        Ime = "Rijad",
                        JMB = "1211995284475",
                        KorisnickiNalogId = _context.Korisnicki_nalogs.Where(k=>k.Korsnicko_ime=="administrator").FirstOrDefault().Id,
                        Korisnicko_Ime = "administrator",
                        Prezime = "Spahic",
                        Spol = "M"
                    });
                _context.SaveChanges();
            }
        }
    }
}
