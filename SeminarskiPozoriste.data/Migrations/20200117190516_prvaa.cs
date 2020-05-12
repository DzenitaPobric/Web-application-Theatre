using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiPozoriste.data.Migrations
{
    public partial class prvaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Glumac",
                columns: table => new
                {
                    GlumacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    BrojUgovora = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    AdresaSlike = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glumac", x => x.GlumacID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    KorisnickiNalogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.KorisnickiNalogID);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    SalaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false),
                    Klimatizacija = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.SalaID);
                });

            migrationBuilder.CreateTable(
                name: "Sponzor",
                columns: table => new
                {
                    SponzorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponzor", x => x.SponzorID);
                });

            migrationBuilder.CreateTable(
                name: "TipUlaznice",
                columns: table => new
                {
                    TipUlazniceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipUlaznice", x => x.TipUlazniceID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ZanrID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.ZanrID);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    KorisnickiNalogID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admin_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AutorizacijskiToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vrijednost = table.Column<string>(nullable: true),
                    KorisnickiNalogID = table.Column<int>(nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(nullable: false),
                    IpAdresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorizacijskiToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutorizacijskiToken_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: false),
                    GradID = table.Column<int>(nullable: false),
                    KorisnickiNalogID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacID);
                    table.ForeignKey(
                        name: "FK_Kupac_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kupac_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sjediste",
                columns: table => new
                {
                    SjedisteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Red = table.Column<int>(nullable: false),
                    Kolona = table.Column<int>(nullable: false),
                    SalaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjediste", x => x.SjedisteID);
                    table.ForeignKey(
                        name: "FK_Sjediste_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    UplataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Svrha = table.Column<string>(nullable: true),
                    Iznos = table.Column<float>(nullable: false),
                    SponzorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.UplataID);
                    table.ForeignKey(
                        name: "FK_Uplata_Sponzor_SponzorID",
                        column: x => x.SponzorID,
                        principalTable: "Sponzor",
                        principalColumn: "SponzorID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Predstava",
                columns: table => new
                {
                    PredstavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Reziser = table.Column<string>(nullable: true),
                    Trajanje = table.Column<int>(nullable: false),
                    ZanrID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstava", x => x.PredstavaID);
                    table.ForeignKey(
                        name: "FK_Predstava_Zanr_ZanrID",
                        column: x => x.ZanrID,
                        principalTable: "Zanr",
                        principalColumn: "ZanrID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Novosti",
                columns: table => new
                {
                    NovostiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Tekst = table.Column<string>(nullable: true),
                    DatumVrijemeObjave = table.Column<DateTime>(nullable: false),
                    AdresaSlike = table.Column<string>(nullable: true),
                    AdminID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novosti", x => x.NovostiID);
                    table.ForeignKey(
                        name: "FK_Novosti_Admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GlumacPredstava",
                columns: table => new
                {
                    GlumacPredstavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GlumacID = table.Column<int>(nullable: false),
                    PredstavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlumacPredstava", x => x.GlumacPredstavaID);
                    table.ForeignKey(
                        name: "FK_GlumacPredstava_Glumac_GlumacID",
                        column: x => x.GlumacID,
                        principalTable: "Glumac",
                        principalColumn: "GlumacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GlumacPredstava_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PredstavaKupac",
                columns: table => new
                {
                    PredstavaKupacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ocjena = table.Column<float>(nullable: false),
                    PredstavaID = table.Column<int>(nullable: false),
                    KupacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredstavaKupac", x => x.PredstavaKupacID);
                    table.ForeignKey(
                        name: "FK_PredstavaKupac_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PredstavaKupac_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PredstavaUplata",
                columns: table => new
                {
                    PredstavaUplataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    PredstavaID = table.Column<int>(nullable: false),
                    UplataID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredstavaUplata", x => x.PredstavaUplataID);
                    table.ForeignKey(
                        name: "FK_PredstavaUplata_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PredstavaUplata_Uplata_UplataID",
                        column: x => x.UplataID,
                        principalTable: "Uplata",
                        principalColumn: "UplataID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Prikazivanje",
                columns: table => new
                {
                    PrikazivanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPrikazivanja = table.Column<DateTime>(nullable: false),
                    PredstavaID = table.Column<int>(nullable: false),
                    SalaID = table.Column<int>(nullable: false),
                    BrojDostupnihMjesta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prikazivanje", x => x.PrikazivanjeID);
                    table.ForeignKey(
                        name: "FK_Prikazivanje_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Prikazivanje_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacije",
                columns: table => new
                {
                    NotifikacijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumSlanja = table.Column<DateTime>(nullable: false),
                    IsProcitano = table.Column<bool>(nullable: false),
                    NovostiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacije", x => x.NotifikacijeID);
                    table.ForeignKey(
                        name: "FK_Notifikacije_Novosti_NovostiID",
                        column: x => x.NovostiID,
                        principalTable: "Novosti",
                        principalColumn: "NovostiID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRezervacije = table.Column<DateTime>(nullable: false),
                    DatumIsteka = table.Column<DateTime>(nullable: false),
                    Odobrena = table.Column<bool>(nullable: false),
                    KupacID = table.Column<int>(nullable: false),
                    PrikazivanjeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Prikazivanje_PrikazivanjeID",
                        column: x => x.PrikazivanjeID,
                        principalTable: "Prikazivanje",
                        principalColumn: "PrikazivanjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ulaznica",
                columns: table => new
                {
                    UlaznicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    TipUlazniceID = table.Column<int>(nullable: false),
                    PrikazivanjeID = table.Column<int>(nullable: false),
                    KupacID = table.Column<int>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulaznica", x => x.UlaznicaID);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Prikazivanje_PrikazivanjeID",
                        column: x => x.PrikazivanjeID,
                        principalTable: "Prikazivanje",
                        principalColumn: "PrikazivanjeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ulaznica_TipUlaznice_TipUlazniceID",
                        column: x => x.TipUlazniceID,
                        principalTable: "TipUlaznice",
                        principalColumn: "TipUlazniceID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_KorisnickiNalogID",
                table: "Admin",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacijskiToken_KorisnickiNalogID",
                table: "AutorizacijskiToken",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_GlumacPredstava_GlumacID",
                table: "GlumacPredstava",
                column: "GlumacID");

            migrationBuilder.CreateIndex(
                name: "IX_GlumacPredstava_PredstavaID",
                table: "GlumacPredstava",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_GradID",
                table: "Kupac",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnickiNalogID",
                table: "Kupac",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacije_NovostiID",
                table: "Notifikacije",
                column: "NovostiID");

            migrationBuilder.CreateIndex(
                name: "IX_Novosti_AdminID",
                table: "Novosti",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Predstava_ZanrID",
                table: "Predstava",
                column: "ZanrID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaKupac_KupacID",
                table: "PredstavaKupac",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaKupac_PredstavaID",
                table: "PredstavaKupac",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaUplata_PredstavaID",
                table: "PredstavaUplata",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaUplata_UplataID",
                table: "PredstavaUplata",
                column: "UplataID");

            migrationBuilder.CreateIndex(
                name: "IX_Prikazivanje_PredstavaID",
                table: "Prikazivanje",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prikazivanje_SalaID",
                table: "Prikazivanje",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KupacID",
                table: "Rezervacija",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_PrikazivanjeID",
                table: "Rezervacija",
                column: "PrikazivanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sjediste_SalaID",
                table: "Sjediste",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_KupacID",
                table: "Ulaznica",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_PrikazivanjeID",
                table: "Ulaznica",
                column: "PrikazivanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_RezervacijaID",
                table: "Ulaznica",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_TipUlazniceID",
                table: "Ulaznica",
                column: "TipUlazniceID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_SponzorID",
                table: "Uplata",
                column: "SponzorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorizacijskiToken");

            migrationBuilder.DropTable(
                name: "GlumacPredstava");

            migrationBuilder.DropTable(
                name: "Notifikacije");

            migrationBuilder.DropTable(
                name: "PredstavaKupac");

            migrationBuilder.DropTable(
                name: "PredstavaUplata");

            migrationBuilder.DropTable(
                name: "Sjediste");

            migrationBuilder.DropTable(
                name: "Ulaznica");

            migrationBuilder.DropTable(
                name: "Glumac");

            migrationBuilder.DropTable(
                name: "Novosti");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "TipUlaznice");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Sponzor");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Prikazivanje");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Predstava");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Zanr");
        }
    }
}
