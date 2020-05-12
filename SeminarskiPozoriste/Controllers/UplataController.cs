using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarskiPozoriste.data;
using SeminarskiPozoriste.data.Models;
using SeminarskiPozoriste.web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SeminarskiPozoriste.web.Controllers
{
    public class UplataController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            UplataPrikaziVM model = new UplataPrikaziVM()
            {
                lista = db.Uplata.Select(x => new UplataPrikaziVM.Row()
                {
                   Iznos=x.Iznos,
                   Naziv=x.Naziv,
                   NazivSponzora=x.Sponzor.Naziv,
                   Svrha=x.Svrha,
                   UplataID=x.UplataID
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();
           
            UplataDodajVM model = new UplataDodajVM()
            {
                Uplata=new Uplata(),
                Sponzor = db.Sponzor.Select(x => new SelectListItem()
                {
                    Value = x.SponzorID.ToString(),
                    Text = x.Naziv
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Snimi(UplataDodajVM model)
        {
            MyContext db = new MyContext();
            Uplata u = model.Uplata;
            db.Uplata.Add(u);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Uplata u = db.Uplata.Find(id);

            List <PredstavaUplata> pulist = db.PredstavaUplata.Where(x => x.UplataID == id).ToList();
            foreach(var pu in pulist)
            {
                db.PredstavaUplata.Remove(pu);
            }

            db.Uplata.Remove(u);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Uplata u = db.Uplata.Where(x => x.UplataID == id).Include(x => x.Sponzor).FirstOrDefault();

            UplataUrediVM model = new UplataUrediVM()
            {
                UplataID=id,
                Sponzor = db.Sponzor.Select(x => new SelectListItem()
                {
                    Value = x.SponzorID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                sponzorID = u.SponzorID,
                Naziv = u.Naziv,
                Iznos=u.Iznos,
                Svrha=u.Svrha
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult UrediSnimi(UplataUrediVM model)
        {
            MyContext db = new MyContext();
            Uplata u = db.Uplata.Where(x => x.UplataID == model.UplataID).Include(x => x.Sponzor).FirstOrDefault();

            u.UplataID = model.UplataID;
            u.SponzorID = model.sponzorID;
            u.Naziv = model.Naziv;
            u.Iznos = model.Iznos;
            u.Svrha = model.Svrha;

            List<SelectListItem> sponzor = db.Sponzor.Select(x => new SelectListItem()
            {
                Value = x.SponzorID.ToString(),
                Text = x.Naziv
            }).ToList();
            sponzor = model.Sponzor;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi/" + model.UplataID);
        }
    }
}