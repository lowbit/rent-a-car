using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rentacar.Data.Models;

namespace Rentacar.Data.EF
{
    public class MyContext : IdentityDbContext <Korisnicki_nalog>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=p1848.database.windows.net;Database=p1848_rentacar;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=p1848;Password=Ph%*aqArWE#9M#s%");
        }
        public MyContext(DbContextOptions<MyContext> x) : base(x)
        {
        }
        public MyContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Korisnici> Korisnicis { set; get; }
        public DbSet<Korisnicki_nalog> Korisnicki_nalogs { set; get; }
        public DbSet<Vijesti> Vijestis { set; get; }
        public DbSet<Komentari> Komentaris { set; get; }
        public DbSet<DetaljiServisa> DetaljiServisas { set; get; }
        public DbSet<Gradovi> Gradovis { set; get; }
        public DbSet<Kategorije> Kategorijes { set; get; }
        public DbSet<Modeli> Modelis { set; get; }
        public DbSet<Nalog> Nalogs { set; get; }
        public DbSet<Notifikacije> Notifikacijes { set; get; }
        public DbSet<Opcine> Opcines { set; get; }
        public DbSet<Podmodeli> Podmodelis { set; get; }
        public DbSet<Polozene_kategorije> Polozene_Kategorijes { set; get; }
        public DbSet<Proizvodjaci> Proizvodjacis { set; get; }
        public DbSet<Saloni> Salonis { set; get; }
        public DbSet<Servisi> Servisis { set; get; }
        public DbSet<Uplate> Uplates { set; get; }
        public DbSet<Utisci> Utiscis { set; get; }
        public DbSet<Vozila> Vozilas { set; get; }
        public DbSet<Zaposlenici> Zaposlenicis { set; get; }

    }
}