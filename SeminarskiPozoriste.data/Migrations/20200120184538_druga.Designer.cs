﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeminarskiPozoriste.data;

namespace SeminarskiPozoriste.data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200120184538_druga")]
    partial class druga
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime");

                    b.Property<int>("KorisnickiNalogID");

                    b.Property<string>("Prezime");

                    b.HasKey("AdminID");

                    b.HasIndex("KorisnickiNalogID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.AutorizacijskiToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IpAdresa");

                    b.Property<int>("KorisnickiNalogID");

                    b.Property<string>("Vrijednost");

                    b.Property<DateTime>("VrijemeEvidentiranja");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogID");

                    b.ToTable("AutorizacijskiToken");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Glumac", b =>
                {
                    b.Property<int>("GlumacID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresaSlike");

                    b.Property<string>("BrojUgovora")
                        .IsRequired();

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<string>("Prezime")
                        .IsRequired();

                    b.HasKey("GlumacID");

                    b.ToTable("Glumac");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.GlumacPredstava", b =>
                {
                    b.Property<int>("GlumacPredstavaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GlumacID");

                    b.Property<int>("PredstavaID");

                    b.HasKey("GlumacPredstavaID");

                    b.HasIndex("GlumacID");

                    b.HasIndex("PredstavaID");

                    b.ToTable("GlumacPredstava");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Grad", b =>
                {
                    b.Property<int>("GradID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("GradID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("KorisnickiNalogID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("KorisnickiNalogID");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Kupac", b =>
                {
                    b.Property<int>("KupacID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojTelefona")
                        .IsRequired();

                    b.Property<int>("GradID");

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<int>("KorisnickiNalogID");

                    b.Property<string>("Prezime")
                        .IsRequired();

                    b.HasKey("KupacID");

                    b.HasIndex("GradID");

                    b.HasIndex("KorisnickiNalogID");

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.KupacNagradnaIgra", b =>
                {
                    b.Property<int>("KupacNagradnaIgraID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KupacID");

                    b.Property<int>("NagradnaIgraID");

                    b.HasKey("KupacNagradnaIgraID");

                    b.HasIndex("KupacID");

                    b.HasIndex("NagradnaIgraID");

                    b.ToTable("KupacNagradnaIgra");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.NagradnaIgra", b =>
                {
                    b.Property<int>("NagradnaIgraID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminID");

                    b.Property<DateTime>("Kraj");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<DateTime>("Pocetak");

                    b.HasKey("NagradnaIgraID");

                    b.HasIndex("AdminID");

                    b.ToTable("NagradnaIgra");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Notifikacije", b =>
                {
                    b.Property<int>("NotifikacijeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumSlanja");

                    b.Property<bool>("IsProcitano");

                    b.Property<int>("NovostiID");

                    b.HasKey("NotifikacijeID");

                    b.HasIndex("NovostiID");

                    b.ToTable("Notifikacije");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Novosti", b =>
                {
                    b.Property<int>("NovostiID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminID");

                    b.Property<string>("AdresaSlike");

                    b.Property<DateTime>("DatumVrijemeObjave");

                    b.Property<string>("Naziv");

                    b.Property<string>("Tekst");

                    b.HasKey("NovostiID");

                    b.HasIndex("AdminID");

                    b.ToTable("Novosti");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Predstava", b =>
                {
                    b.Property<int>("PredstavaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<string>("Reziser");

                    b.Property<int>("Trajanje");

                    b.Property<int>("ZanrID");

                    b.HasKey("PredstavaID");

                    b.HasIndex("ZanrID");

                    b.ToTable("Predstava");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.PredstavaKupac", b =>
                {
                    b.Property<int>("PredstavaKupacID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KupacID");

                    b.Property<float>("Ocjena");

                    b.Property<int>("PredstavaID");

                    b.HasKey("PredstavaKupacID");

                    b.HasIndex("KupacID");

                    b.HasIndex("PredstavaID");

                    b.ToTable("PredstavaKupac");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.PredstavaUplata", b =>
                {
                    b.Property<int>("PredstavaUplataID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumUplate");

                    b.Property<int>("PredstavaID");

                    b.Property<int>("UplataID");

                    b.HasKey("PredstavaUplataID");

                    b.HasIndex("PredstavaID");

                    b.HasIndex("UplataID");

                    b.ToTable("PredstavaUplata");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Prikazivanje", b =>
                {
                    b.Property<int>("PrikazivanjeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojDostupnihMjesta");

                    b.Property<DateTime>("DatumPrikazivanja");

                    b.Property<int>("PredstavaID");

                    b.Property<int>("SalaID");

                    b.HasKey("PrikazivanjeID");

                    b.HasIndex("PredstavaID");

                    b.HasIndex("SalaID");

                    b.ToTable("Prikazivanje");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIsteka");

                    b.Property<DateTime>("DatumRezervacije");

                    b.Property<int>("KupacID");

                    b.Property<bool>("Odobrena");

                    b.Property<int>("PrikazivanjeID");

                    b.HasKey("RezervacijaID");

                    b.HasIndex("KupacID");

                    b.HasIndex("PrikazivanjeID");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Sala", b =>
                {
                    b.Property<int>("SalaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kapacitet");

                    b.Property<bool>("Klimatizacija");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("SalaID");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Sjediste", b =>
                {
                    b.Property<int>("SjedisteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kolona");

                    b.Property<int>("Red");

                    b.Property<int>("SalaID");

                    b.HasKey("SjedisteID");

                    b.HasIndex("SalaID");

                    b.ToTable("Sjediste");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Sponzor", b =>
                {
                    b.Property<int>("SponzorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojTelefona")
                        .IsRequired();

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("SponzorID");

                    b.ToTable("Sponzor");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.TipUlaznice", b =>
                {
                    b.Property<int>("TipUlazniceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("TipUlazniceID");

                    b.ToTable("TipUlaznice");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Ulaznica", b =>
                {
                    b.Property<int>("UlaznicaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cijena");

                    b.Property<int>("KupacID");

                    b.Property<int>("PrikazivanjeID");

                    b.Property<int>("RezervacijaID");

                    b.Property<int>("TipUlazniceID");

                    b.HasKey("UlaznicaID");

                    b.HasIndex("KupacID");

                    b.HasIndex("PrikazivanjeID");

                    b.HasIndex("RezervacijaID");

                    b.HasIndex("TipUlazniceID");

                    b.ToTable("Ulaznica");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Uplata", b =>
                {
                    b.Property<int>("UplataID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Iznos");

                    b.Property<string>("Naziv");

                    b.Property<int>("SponzorID");

                    b.Property<string>("Svrha");

                    b.HasKey("UplataID");

                    b.HasIndex("SponzorID");

                    b.ToTable("Uplata");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Zanr", b =>
                {
                    b.Property<int>("ZanrID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("ZanrID");

                    b.ToTable("Zanr");
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Admin", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.AutorizacijskiToken", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.GlumacPredstava", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Glumac", "Glumac")
                        .WithMany()
                        .HasForeignKey("GlumacID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.Predstava", "Predstava")
                        .WithMany()
                        .HasForeignKey("PredstavaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Kupac", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.KupacNagradnaIgra", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.NagradnaIgra", "NagradnaIgra")
                        .WithMany()
                        .HasForeignKey("NagradnaIgraID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.NagradnaIgra", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Notifikacije", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Novosti", "Novosti")
                        .WithMany()
                        .HasForeignKey("NovostiID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Novosti", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Predstava", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Zanr", "Zanr")
                        .WithMany()
                        .HasForeignKey("ZanrID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.PredstavaKupac", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.Predstava", "Predstava")
                        .WithMany()
                        .HasForeignKey("PredstavaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.PredstavaUplata", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Predstava", "Predstava")
                        .WithMany()
                        .HasForeignKey("PredstavaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.Uplata", "Uplata")
                        .WithMany()
                        .HasForeignKey("UplataID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Prikazivanje", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Predstava", "Predstava")
                        .WithMany()
                        .HasForeignKey("PredstavaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Rezervacija", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.Prikazivanje", "Prikazivanje")
                        .WithMany()
                        .HasForeignKey("PrikazivanjeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Sjediste", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Ulaznica", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.Prikazivanje", "Prikazivanje")
                        .WithMany()
                        .HasForeignKey("PrikazivanjeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.Rezervacija", "Rezervacija")
                        .WithMany()
                        .HasForeignKey("RezervacijaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeminarskiPozoriste.data.Models.TipUlaznice", "TipUlaznice")
                        .WithMany()
                        .HasForeignKey("TipUlazniceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeminarskiPozoriste.data.Models.Uplata", b =>
                {
                    b.HasOne("SeminarskiPozoriste.data.Models.Sponzor", "Sponzor")
                        .WithMany()
                        .HasForeignKey("SponzorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
