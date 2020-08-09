using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rentacar.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rentacar.Data.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyContext(serviceProvider.GetRequiredService<DbContextOptions<MyContext>>()))
            {
                if (!context.Gradovis.Any())
                {
                    context.Gradovis.AddRange(
                        new Gradovi
                        {
                            Naziv = "Sarajevo",
                            Postanski_broj = "71000"
                        });
                    context.SaveChanges();
                }
                if (!context.Opcines.Any())
                {
                    context.Opcines.AddRange(
                        new Opcine
                        {
                            Naziv = "Novi Grad",
                            GradId = context.Gradovis.First().Id
                        },
                        new Opcine
                        {
                            Naziv = "Centar",
                            GradId = context.Gradovis.First().Id
                        },
                        new Opcine
                        {
                            Naziv = "Hadžići",
                            GradId = context.Gradovis.First().Id
                        },
                        new Opcine
                        {
                            Naziv = "Novo Sarajevo",
                            GradId = context.Gradovis.First().Id
                        },
                        new Opcine
                        {
                            Naziv = "Ilidža",
                            GradId = context.Gradovis.First().Id
                        },
                        new Opcine
                        {
                            Naziv = "Ilijaš",
                            GradId = context.Gradovis.First().Id
                        },
                        new Opcine
                        {
                            Naziv = "Stari Grad",
                            GradId = context.Gradovis.First().Id
                        },
                        new Opcine
                        {
                            Naziv = "Trnovo",
                            GradId = context.Gradovis.First().Id
                        },
                        new Opcine
                        {
                            Naziv = "Vogošća",
                            GradId = context.Gradovis.First().Id
                        });
                    context.SaveChanges();
                }
                if (!context.Korisnicis.Any())
                {
                    context.Korisnicis.AddRange(
                        new Korisnici
                        {
                            Ime = "Rijad",
                            Prezime = "Spahic",
                            OpcinaId = context.Opcines.First().Id,
                            Ostvareni_popust = 0
                        },
                        new Korisnici
                        {
                            Ime = "Mark",
                            Prezime = "Johnson",
                            OpcinaId = context.Opcines.First().Id,
                            Ostvareni_popust = 10
                        },
                        new Korisnici
                        {
                            Ime = "William",
                            Prezime = "Donaldson",
                            OpcinaId = context.Opcines.First().Id,
                            Ostvareni_popust = 10
                        },
                        new Korisnici
                        {
                            Ime = "Stevie",
                            Prezime = "Clerk",
                            OpcinaId = context.Opcines.First().Id,
                            Ostvareni_popust = 10
                        },
                        new Korisnici
                        {
                            Ime = "John",
                            Prezime = "Doe",
                            OpcinaId = context.Opcines.First().Id,
                            Ostvareni_popust = 10
                        });
                    context.SaveChanges();
                }
                if (!context.Tipovi_korisnickog_nalogas.Any())
                {
                    context.Tipovi_korisnickog_nalogas.AddRange(
                        new Tipovi_korisnickog_naloga
                        {
                            Naziv = "Administrator",
                            Opis = "Administrator",
                            Permisije = "Administrator"
                        },
                        new Tipovi_korisnickog_naloga
                        {
                            Naziv = "Marketing",
                            Opis = "Zaduzen za azuriranje i pisanje novosti i brisanje nepozeljnih komentara",
                            Permisije = "Vijesti - citanje,pisanje i brisanje. Komentari,Utisci - citanje i brisanje"
                        }, 
                        new Tipovi_korisnickog_naloga
                        {
                            Naziv = "Prodavac",
                            Opis = "Unosi uplate.",
                            Permisije = "Uplate - citanje i pisanje, Nalog - citanje i pisanje"
                        },
                        new Tipovi_korisnickog_naloga
                        {
                            Naziv = "Logistika",
                            Opis = "Azurira podatke o vozilima,salonima i servisima",
                            Permisije = "Vozila,Servisi,Detalji_servisa,Podmodeli,Modeli,Proizvodjaci,Saloni,Opcine,Gradovi - citanje,pisanje i brisanje"
                        },
                        new Tipovi_korisnickog_naloga
                        {
                            Naziv = "Kupac",
                            Opis = "Pretrazuje ponude, iznajmljuje vozila.",
                            Permisije = "Vozila,Saloni,Vijesti - citanje. Komentari, Utisci, - citanje,pisanje i brisanje(samo svoje). Nalog - citanje(samo svoje),pisanje(samo svoje)"
                        });
                    context.SaveChanges();
                }
                if (!context.Korisnicki_nalogs.Any())
                {
                    context.Korisnicki_nalogs.AddRange(
                        new Korisnicki_nalog
                        {
                            Korsnicko_ime = "administrator",
                            Lozinka = "administrator",
                            Datum_prijave = DateTime.Now.ToString(),
                            TipId = context.Tipovi_korisnickog_nalogas.ToList()[0].Id,
                            KorisnikId = context.Korisnicis.ToList()[0].Id
                        },
                        new Korisnicki_nalog
                        {
                            Korsnicko_ime = "marketing",
                            Lozinka = "marketing",
                            Datum_prijave = DateTime.Now.ToString(),
                            TipId = context.Tipovi_korisnickog_nalogas.ToList()[1].Id,
                            KorisnikId = context.Korisnicis.ToList()[1].Id
                        },
                        new Korisnicki_nalog
                        {
                            Korsnicko_ime = "prodavac",
                            Lozinka = "prodavac",
                            Datum_prijave = DateTime.Now.ToString(),
                            TipId = context.Tipovi_korisnickog_nalogas.ToList()[2].Id,
                            KorisnikId = context.Korisnicis.ToList()[2].Id
                        },
                        new Korisnicki_nalog
                        {
                            Korsnicko_ime = "logistika",
                            Lozinka = "logistika",
                            Datum_prijave = DateTime.Now.ToString(),
                            TipId = context.Tipovi_korisnickog_nalogas.ToList()[3].Id,
                            KorisnikId = context.Korisnicis.ToList()[3].Id
                        },
                        new Korisnicki_nalog
                        {
                            Korsnicko_ime = "kupac",
                            Lozinka = "kupac",
                            Datum_prijave = DateTime.Now.ToString(),
                            TipId = context.Tipovi_korisnickog_nalogas.ToList()[4].Id,
                            KorisnikId = context.Korisnicis.ToList()[4].Id
                        });
                    context.SaveChanges();
                }
                if (!context.Vijestis.Any())
                {
                    context.Vijestis.AddRange(
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       },
                       new Vijesti
                       {
                           AutorId = context.Korisnicki_nalogs.First().Id,
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
                           Ukupno_pregleda = 0
                       });
                    context.SaveChanges();
                }
            }
        }
    }
}
