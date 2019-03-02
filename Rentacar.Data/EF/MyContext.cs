using Microsoft.EntityFrameworkCore;
using Rentacar.Data.Models;

namespace Rentacar.Data.EF
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Korisnici> Korisnicis { set; get; }
        public DbSet<Korisnicki_nalog> Korisnicki_nalogs { set; get; }
        public DbSet<Tipovi_korisnickog_naloga> Tipovi_korisnickog_nalogas { set; get; }
        public DbSet<Vijesti> Vijestis { set; get; }
        public DbSet<Komentari> Komentaris { set; get; }
    }
}