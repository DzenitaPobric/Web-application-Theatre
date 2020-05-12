using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiPozoriste.data;
using SeminarskiPozoriste.data.Models;
using SeminarskiPozoriste.web.ViewModels;

namespace SeminarskiPozoriste.web.Controllers
{
    public class SponzorController : Controller
    {

        public IActionResult Prikazi(string search)
        {
            MyContext db = new MyContext();
            SponzorPrikaziVM model = new SponzorPrikaziVM()
            {
                lista = db.Sponzor.Select(x => new SponzorPrikaziVM.Row()
                {
                    Id = x.SponzorID,
                    BrojTelefona = x.BrojTelefona,
                    Naziv = x.Naziv
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();

            SponzorDodajVM model = new SponzorDodajVM()
            {
                Sponzor = new Sponzor()
            };
            return View(model);
        }

        public IActionResult Snimi(SponzorDodajVM model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Sponzor s = model.Sponzor;
                db.Sponzor.Add(s);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi");
            }
            return View("Dodaj");
        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Sponzor s = db.Sponzor.Find(id);

            List<Uplata> uList = db.Uplata.Where(x => x.SponzorID == id).ToList();
            foreach(var u in uList)
            {
                var up = u.UplataID;
                List<PredstavaUplata> puList = db.PredstavaUplata.Where(x => x.UplataID == up).ToList();
                foreach(var pu in puList)
                {
                    db.PredstavaUplata.Remove(pu);
                }
                db.Uplata.Remove(u);
            }
            db.Sponzor.Remove(s);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Detalji(int id)
        {
            MyContext db = new MyContext();

            Sponzor s = db.Sponzor.Where(x => x.SponzorID == id).FirstOrDefault();

            return View(s);
        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Sponzor s = db.Sponzor.Where(x => x.SponzorID == id).FirstOrDefault();
            db.Dispose();
            return View(s);
        }
        public IActionResult UrediSnimi(Sponzor model)
        {
            MyContext db = new MyContext();
            Sponzor s = db.Sponzor.Where(x => x.SponzorID == model.SponzorID).FirstOrDefault();
            s.SponzorID = model.SponzorID;
            s.Naziv = model.Naziv;
            s.BrojTelefona = model.BrojTelefona;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi/" + model.SponzorID);
        }


    }
}