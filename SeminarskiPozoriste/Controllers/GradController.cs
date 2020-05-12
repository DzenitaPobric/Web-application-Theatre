using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SeminarskiPozoriste.data;
using SeminarskiPozoriste.data.Models;
using SeminarskiPozoriste.web.ViewModels;
using Korzh.EasyQuery.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeminarskiPozoriste.web.Helper;

namespace SeminarskiPozoriste.web.Controllers
{
    public class GradController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            GradPrikaziVM model = new GradPrikaziVM()
            {
                lista = db.Grad.Select(x => new GradPrikaziVM.Row()
                {
                    Naziv=x.Naziv,
                    Id=x.GradID
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult Dodaj()
        {     
            GradDodajVM model = new GradDodajVM()
            {
                Grad = new Grad()
            };            
            return View(model);
        }
     
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Grad g = db.Grad.Find(id);

            List<Kupac> kupci = db.Kupac.Where(x => x.GradID == g.GradID).ToList();

            foreach (var y in kupci)
            {
                var kni = y.KupacID;
                List<KupacNagradnaIgra> kupacigre = db.KupacNagradnaIgra.Where(x => x.KupacID == kni).ToList();
                foreach(var n in kupacigre)
                {
                    db.KupacNagradnaIgra.Remove(n);
                }
                List<PredstavaKupac> pkList = db.PredstavaKupac.Where(x => x.KupacID == kni).ToList();
                foreach (var pk in pkList)
                {
                    db.PredstavaKupac.Remove(pk);
                }
                List<Rezervacija> rList = db.Rezervacija.Where(x => x.KupacID == kni).ToList();
                foreach (var r in rList)
                {
                    var rez = r.RezervacijaID;
                    List<Ulaznica> ul = db.Ulaznica.Where(x => x.RezervacijaID == rez).ToList();
                    foreach (var yz in ul)
                    {
                        db.Ulaznica.Remove(yz);
                    }
                    db.Rezervacija.Remove(r);
                }
                List<Komentar> komList = db.Komentar.Where(x => x.KupacID == kni).ToList();
                foreach (var k in komList)
                {
                    db.Komentar.Remove(k);
                }
                db.Kupac.Remove(y);
            }

            db.Grad.Remove(g);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Snimi(GradDodajVM model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Grad g = model.Grad;
                db.Grad.Add(g);
                db.SaveChanges();
                db.Dispose();

                return RedirectToAction("Prikazi");
            }
            return View("Dodaj");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Grad g = db.Grad.Where(x => x.GradID == id).FirstOrDefault();
            db.Dispose();
            return View(g);
        }

        public IActionResult UrediSnimi(Grad model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Grad g = db.Grad.Where(x => x.GradID == model.GradID).FirstOrDefault();
                g.GradID = model.GradID;
                g.Naziv = model.Naziv;
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi/" + model.GradID);
            }
            return View("Uredi");

        }

    }
}