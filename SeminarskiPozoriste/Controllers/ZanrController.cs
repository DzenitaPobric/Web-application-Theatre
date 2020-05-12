using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korzh.EasyQuery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SeminarskiPozoriste.data;
using SeminarskiPozoriste.data.Models;
using SeminarskiPozoriste.web.ViewModels;


namespace SeminarskiPozoriste.web.Controllers
{
    public class ZanrController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();

            ZanrPrikaziVM model = new ZanrPrikaziVM()
            {
                lista = db.Zanr.Select(x => new ZanrPrikaziVM.Row()
                {
                    Id = x.ZanrID,
                    Naziv = x.Naziv,                 
                }).ToList()
            };
           
            return View(model);
        }

        public IActionResult Dodaj()
        {
            ZanrDodajVM model = new ZanrDodajVM()
            {
                Zanr = new Zanr()
            };
            return View(model);
        }

        public IActionResult Snimi(ZanrDodajVM model)
        {
             MyContext db = new MyContext();
             Zanr zanr = model.Zanr;
             db.Zanr.Add(zanr);
             db.SaveChanges();
             db.Dispose();
             return RedirectToAction("Prikazi");            
        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Zanr z = db.Zanr.Find(id);

            List<Predstava> predstave = db.Predstava.Where(x => x.ZanrID == z.ZanrID).ToList();
     
            foreach(var p in predstave)
            {
                var y = p.PredstavaID;
                List<Prikazivanje> prList = db.Prikazivanje.Where(x => x.PredstavaID == y).ToList();
                foreach(var pr in prList)
                {
                    var prik = pr.PrikazivanjeID;
                    List<Rezervacija> rList = db.Rezervacija.Where(x => x.PrikazivanjeID == prik).ToList();
                    foreach(var r in rList)
                    {
                        var ul = r.RezervacijaID;
                        List<Ulaznica> ulList = db.Ulaznica.Where(x => x.RezervacijaID == ul).ToList();
                        foreach(var u in ulList)
                        {
                            db.Ulaznica.Remove(u);
                        }
                        db.Rezervacija.Remove(r);
                    }
                    db.Prikazivanje.Remove(pr);
                }
                List<PredstavaKupac> pkList = db.PredstavaKupac.Where(x => x.PredstavaID == y).ToList();
                foreach (var pk in pkList)
                {
                    db.PredstavaKupac.Remove(pk);
                }
                db.Predstava.Remove(p);
                List<Komentar> komList = db.Komentar.Where(x => x.PredstavaID == y).ToList();
                foreach (var kom in komList)
                {
                    db.Komentar.Remove(kom);
                }
                List<GlumacPredstava> gpList = db.GlumacPredstava.Where(x => x.PredstavaID == y).ToList();
                foreach (var gp in gpList)
                { 
                    db.GlumacPredstava.Remove(gp);
                }
                List<PredstavaUplata> pulist = db.PredstavaUplata.Where(x => x.PredstavaID == y).ToList();
                foreach (var pu in pulist)
                {
                    db.PredstavaUplata.Remove(pu);
                }

                db.Predstava.Remove(p);
            }

            db.Zanr.Remove(z);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Zanr g = db.Zanr.Where(x => x.ZanrID == id).FirstOrDefault();
            db.Dispose();
            return View(g);
        }

        public IActionResult UrediSnimi(Zanr model)
        {
            MyContext db = new MyContext();
            Zanr g = db.Zanr.Where(x => x.ZanrID == model.ZanrID).FirstOrDefault();
            g.ZanrID = model.ZanrID;
            g.Naziv = model.Naziv;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi/" + model.ZanrID);
        }
    }
}