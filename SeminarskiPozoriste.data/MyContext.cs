using System;
using Microsoft.EntityFrameworkCore;
using SeminarskiPozoriste.data.Models;

namespace SeminarskiPozoriste.data
{
    public class MyContext : DbContext
    {
        public DbSet<Glumac> Glumac { get; set; }

        public DbSet<GlumacPredstava> GlumacPredstava { get; set; }

        public DbSet<Grad> Grad { get; set; }

        public DbSet<Kupac> Kupac { get; set; }

        public DbSet<Predstava> Predstava { get; set; }

        public DbSet<PredstavaUplata> PredstavaUplata { get; set; }

        public DbSet<Prikazivanje> Prikazivanje { get; set; }

        public DbSet<Rezervacija> Rezervacija { get; set; }

        public DbSet<Sala> Sala { get; set; }

        public DbSet<Sjediste> Sjediste { get; set; }

        public DbSet<Sponzor> Sponzor { get; set; }

        public DbSet<Ulaznica> Ulaznica { get; set; }

        public DbSet<Uplata> Uplata { get; set; }

        public DbSet<Zanr> Zanr { get; set; }

        public DbSet<PredstavaKupac> PredstavaKupac { get; set; }

        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public DbSet<Novosti> Novosti { get; set; }
        public DbSet<NagradnaIgra> NagradnaIgra { get; set; }
        public DbSet<KupacNagradnaIgra> KupacNagradnaIgra { get; set; }
        public DbSet<Komentar> Komentar { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseSqlServer("Server=.;Database=SeminarskiPozoriste;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }

}
