using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarskiPozoriste.data;
using SeminarskiPozoriste.data.Models;
using SeminarskiPozoriste.web.Helper;
using SeminarskiPozoriste.web.ViewModels;

namespace Ispit.Web.Controllers
{
    [Autorizacija(Admin: true, Klijent: true)]
    public class SesijaController : Controller
    {
        public IActionResult Index()
        {
            MyContext db = new MyContext();
            SesijaIndexVM model = new SesijaIndexVM();
            model.Rows = db.AutorizacijskiToken.Select(s => new SesijaIndexVM.Row
            {
                VrijemeLogiranja = s.VrijemeEvidentiranja,
                token = s.Vrijednost,
                IpAdresa = s.IpAdresa
            }).ToList();
            model.TrenutniToken = HttpContext.GetTrenutniToken();
            return View(model);
        }

        public IActionResult Obrisi(string token)
        {
            MyContext db = new MyContext();

            AutorizacijskiToken obrisati = db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == token);
            if (obrisati != null)
            {
                db.AutorizacijskiToken.Remove(obrisati);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}