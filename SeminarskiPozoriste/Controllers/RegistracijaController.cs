using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SeminarskiPozoriste.Models;
using SeminarskiPozoriste.data.Models;
using SeminarskiPozoriste.web.Helper;
using SeminarskiPozoriste.web.ViewModels;
using SeminarskiPozoriste.data;
using System.Collections.Generic;

namespace SeminarskiPozoriste.web.Controllers
{
    public class RegistracijaController : Controller
    {
        public IActionResult Index()
        {
            MyContext db = new MyContext();

            RegistracijaIndexVM model = new RegistracijaIndexVM
            {
                gradovi = db.Grad.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = x.Naziv,
                    Value = x.GradID.ToString()
                }).ToList(),
                KorisnickiNalog=new KorisnickiNalog(),
                Kupac=new Kupac()
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Snimi(RegistracijaIndexVM model)
        {
            MyContext db = new MyContext();

            KorisnickiNalog noviNalog = model.KorisnickiNalog;
            db.KorisnickiNalog.Add(noviNalog);
            db.SaveChanges();

            List<int> nalozi = db.KorisnickiNalog.Select(x => x.KorisnickiNalogID).ToList();

            Kupac noviKupac = model.Kupac;
            noviKupac.KorisnickiNalogID = nalozi.LastOrDefault();
            db.Kupac.Add(noviKupac);
            db.SaveChanges();

            return Redirect("/Login/Index");
        }
    }
}