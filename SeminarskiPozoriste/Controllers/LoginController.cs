using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SeminarskiPozoriste.Models;
using SeminarskiPozoriste.data.Models;
using SeminarskiPozoriste.web.Helper;
using SeminarskiPozoriste.web.ViewModels;
using SeminarskiPozoriste.data;

namespace SeminarskiPozoriste.web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View(new LoginVM() {
                ZapamtiPassword = true
            });
        }

        public ActionResult Logout()
        {
            MyContext db = new MyContext();
            KorisnickiNalog nalog = HttpContext.GetLogiraniKorisnik();
            //if (nalog != null)
            //{
            //    AutorizacijskiToken token = db.AutorizacijskiToken.FirstOrDefault(x => x.KorisnickiNalogId == nalog.KorisnickiNalogID);
            //    db.AutorizacijskiToken.Remove(token);
            //    db.SaveChanges();
            //    HttpContext.Response.RemoveCookie(Autentifikacija.LogiraniKorisnik);
            //}

            return RedirectToAction("Index");
        }

        public ActionResult Provjera(LoginVM Input)
        {
            MyContext _db = new MyContext();

            KorisnickiNalog korisnik = _db.KorisnickiNalog.SingleOrDefault(x => x.Username == Input.Username && x.Password == Input.Password);

            if (korisnik == null)
            {
                TempData["error_poruka"] = "pogresan username ili password";
                return View("Index", Input);
            }

            if (korisnik.KorisnickiNalogID <= 1)
            {
                HttpContext.SetLogiraniKorisnik(korisnik);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                HttpContext.SetLogiraniKorisnik(korisnik);

                return RedirectToAction("ONama", "Klijent");

            }
        }
    }
}