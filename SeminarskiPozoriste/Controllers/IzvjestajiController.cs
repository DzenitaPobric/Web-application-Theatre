using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarskiPozoriste.data;
using SeminarskiPozoriste.data.Models;
using SeminarskiPozoriste.web.ViewModels;

namespace SeminarskiPozoriste.web.Controllers
{
    public class IzvjestajiController : Controller
    {
        public IActionResult Index()
        {
            MyContext db = new MyContext();
            
            var list = db.Uplata.GroupBy(m => m.Sponzor.Naziv).ToList();
            IzvjestajUplataVM model = new IzvjestajUplataVM();
            model.lista = list.Select(x => new IzvjestajUplataVM.Row() 
            {          
                nazivSponzora = db.Uplata.Where(k => k.Sponzor.Naziv == x.Key).Select(m => m.Sponzor.Naziv).FirstOrDefault(),
                brojUplata = db.Uplata.Where(k => k.Sponzor.Naziv == x.Key).Count(),
                zarada = db.Uplata.Where(k => k.Sponzor.Naziv == x.Key).Select(m => m.Iznos).Sum(),
               
            }).ToList();
            return View(model);
        }

        public IActionResult Index2()
        {
            MyContext db = new MyContext();

            var list = db.Uplata.GroupBy(m => m.Sponzor.Naziv).ToList();
            IzvjestajUplataVM model = new IzvjestajUplataVM();
            model.lista = list.Select(x => new IzvjestajUplataVM.Row()
            {
                nazivSponzora = db.Uplata.Where(k => k.Sponzor.Naziv == x.Key).Select(m => m.Sponzor.Naziv).FirstOrDefault(),
                brojUplata = db.Uplata.Where(k => k.Sponzor.Naziv == x.Key).Count(),
                zarada = db.Uplata.Where(k => k.Sponzor.Naziv == x.Key).Select(m => m.Iznos).Sum(),

            }).ToList();
            return View(model);
        }


        public IActionResult Rezervacije()
        {
            
            MyContext db = new MyContext();

            var list = db.Rezervacija.Include(x=>x.Prikazivanje).ThenInclude(x=>x.Predstava).GroupBy(m => m.Prikazivanje.Predstava.Naziv).ToList();
            IzvjestajRezervacijeVM model = new IzvjestajRezervacijeVM();
            model.lista = list.Select(x => new IzvjestajRezervacijeVM.Row()
            {
                Predstava = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).Where(k => k.Prikazivanje.Predstava.Naziv == x.Key).Select(m => m.Prikazivanje.Predstava.Naziv).FirstOrDefault(),
                BrojRezervacija = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).Where(k => k.Prikazivanje.Predstava.Naziv == x.Key).Count(),
                Zarada = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).Where(k => k.Prikazivanje.Predstava.Naziv == x.Key).Select(m => m.Prikazivanje.Cijena).Sum(),
                
            }).ToList();
            return View(model);
        }

        public IActionResult Rezervacije2()
        {

            MyContext db = new MyContext();

            var list = db.Rezervacija.Include(x => x.Prikazivanje).ThenInclude(x => x.Predstava).GroupBy(m => m.Prikazivanje.Predstava.Naziv).ToList();
            IzvjestajRezervacijeVM model = new IzvjestajRezervacijeVM();
            model.lista = list.Select(x => new IzvjestajRezervacijeVM.Row()
            {
                Predstava = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).Where(k => k.Prikazivanje.Predstava.Naziv == x.Key).Select(m => m.Prikazivanje.Predstava.Naziv).FirstOrDefault(),
                BrojRezervacija = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).Where(k => k.Prikazivanje.Predstava.Naziv == x.Key).Count(),
                Zarada = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).Where(k => k.Prikazivanje.Predstava.Naziv == x.Key).Select(m => m.Prikazivanje.Cijena).Sum(),

            }).ToList();
            return View(model);
        }

        public IActionResult PoZanru()
        {
            MyContext db = new MyContext();

            var list = db.Rezervacija.Include(x => x.Prikazivanje).ThenInclude(x => x.Predstava).ThenInclude(x=>x.Zanr).GroupBy(m => m.Prikazivanje.Predstava.Zanr.Naziv).ToList();
            IzvjestajRezervacijeVM model = new IzvjestajRezervacijeVM();
            model.lista = list.Select(x => new IzvjestajRezervacijeVM.Row()
            {
                Zanr = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).ThenInclude(m=> m.Zanr).Where(k => k.Prikazivanje.Predstava.Zanr.Naziv == x.Key).Select(m => m.Prikazivanje.Predstava.Zanr.Naziv).FirstOrDefault(),
                BrojRezervacija = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).ThenInclude(m => m.Zanr).Where(k => k.Prikazivanje.Predstava.Zanr.Naziv == x.Key).Count(),
                Zarada = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).ThenInclude(m => m.Zanr).Where(k => k.Prikazivanje.Predstava.Zanr.Naziv == x.Key).Select(m => m.Prikazivanje.Cijena).Sum(),

            }).ToList();
            return View(model);
        }
        public IActionResult PoZanru2()
        {
            MyContext db = new MyContext();

            var list = db.Rezervacija.Include(x => x.Prikazivanje).ThenInclude(x => x.Predstava).ThenInclude(x => x.Zanr).GroupBy(m => m.Prikazivanje.Predstava.Zanr.Naziv).ToList();
            IzvjestajRezervacijeVM model = new IzvjestajRezervacijeVM();
            model.lista = list.Select(x => new IzvjestajRezervacijeVM.Row()
            {
                Zanr = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).ThenInclude(m => m.Zanr).Where(k => k.Prikazivanje.Predstava.Zanr.Naziv == x.Key).Select(m => m.Prikazivanje.Predstava.Zanr.Naziv).FirstOrDefault(),
                BrojRezervacija = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).ThenInclude(m => m.Zanr).Where(k => k.Prikazivanje.Predstava.Zanr.Naziv == x.Key).Count(),
                Zarada = db.Rezervacija.Include(m => m.Prikazivanje).ThenInclude(m => m.Predstava).ThenInclude(m => m.Zanr).Where(k => k.Prikazivanje.Predstava.Zanr.Naziv == x.Key).Select(m => m.Prikazivanje.Cijena).Sum(),

            }).ToList();
            return View(model);
        }
    }
}
