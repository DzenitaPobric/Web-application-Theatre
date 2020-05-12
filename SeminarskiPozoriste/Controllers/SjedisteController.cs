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
    public class SjedisteController : Controller
    {
      
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            SjedistePrikaziVM model = new SjedistePrikaziVM()
            {
                lista = db.Sjediste.Select(x => new SjedistePrikaziVM.Row()
                {
                   SjedisteID=x.SjedisteID,
                   Kolona=x.Kolona,
                   Red=x.Red,
                   NazivSale=x.Sala.Naziv,
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();
         
            SjedisteDodajVM model = new SjedisteDodajVM()
            {
                Sjediste = new Sjediste(),
                listaSala = db.Sala.Select(x => new SelectListItem()
                {
                    Value = x.SalaID.ToString(),
                    Text = x.Naziv
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Snimi(SjedisteDodajVM model)
        {
        
                MyContext db = new MyContext();
                Sjediste p = model.Sjediste;
                p.SalaID = model.Sjediste.SalaID;
                db.Sjediste.Add(p);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi");
           
        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Sjediste p = db.Sjediste.Find(id);
            db.Sjediste.Remove(p);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Sjediste s = db.Sjediste.Where(x => x.SjedisteID == id).Include(x=>x.Sala).FirstOrDefault();
            SjedisteUrediVM model = new SjedisteUrediVM()
            {
                Id=id,
                Sala = db.Sala.Select(x => new SelectListItem()
                {
                    Value = x.SalaID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                Kolona =s.Kolona,
                Red=s.Red
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult UrediSnimi(SjedisteUrediVM model)
        {
            MyContext db = new MyContext();
            Sjediste s = db.Sjediste.Where(x => x.SjedisteID == model.Id).Include(x => x.Sala).FirstOrDefault();
           
            s.SjedisteID = model.Id;
            s.Red = model.Red;
            s.Kolona = model.Kolona;
            List<SelectListItem> sale = db.Sala.Select(x => new SelectListItem()
            {
                Value = x.SalaID.ToString(),
                Text = x.Naziv
            }).ToList();
            sale = model.Sala;
            s.SalaID = model.salaId;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi/" + model.Id);
        }
    }
}