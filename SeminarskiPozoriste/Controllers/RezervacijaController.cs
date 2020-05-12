using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using SeminarskiPozoriste.data;
using SeminarskiPozoriste.data.Models;
using SeminarskiPozoriste.web.ViewModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Microsoft.EntityFrameworkCore;
using SeminarskiPozoriste.web.Helper;

namespace SeminarskiPozoriste.web.Controllers
{
    public class RezervacijaController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            RezervacijaPrikaziVM model = new RezervacijaPrikaziVM()
            {
                lista = db.Rezervacija.Select(x => new RezervacijaPrikaziVM.Row()
                {
                    DatumIsteka=x.DatumIsteka,
                    DatumRezervacije=x.DatumRezervacije,
                    Id=x.RezervacijaID,
                    ImePrezime=x.Kupac.Ime + " "+ x.Kupac.Prezime,
                    prikazivanje= db.Prikazivanje.Where(k => k.PrikazivanjeID == x.PrikazivanjeID)
                    .FirstOrDefault()
                    .Predstava.Naziv + "/" + x.Prikazivanje.DatumPrikazivanja.ToShortDateString(),
                    Odobrena =x.Odobrena
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult Prikazi2()
        {
            MyContext db = new MyContext();
            RezervacijaPrikaziVM model = new RezervacijaPrikaziVM()
            {
                lista = db.Rezervacija.Select(x => new RezervacijaPrikaziVM.Row()
                {
                    DatumIsteka = x.DatumIsteka,
                    DatumRezervacije = x.DatumRezervacije,
                    Id = x.RezervacijaID,
                    ImePrezime = x.Kupac.Ime + " " + x.Kupac.Prezime,
                    prikazivanje= db.Prikazivanje.Where(k=>k.PrikazivanjeID==x.PrikazivanjeID)
                    .FirstOrDefault()
                    .Predstava.Naziv+"/"+x.Prikazivanje.DatumPrikazivanja.ToShortDateString(),
                    Odobrena = x.Odobrena
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();
            
            RezervacijaDodajVM model = new RezervacijaDodajVM()
            {
                Rezervacija = new Rezervacija(),
                Kupci = db.Kupac.Select(x => new SelectListItem()
                {
                    Value = x.KupacID.ToString(),
                    Text = x.Ime + " " + x.Prezime
                }).ToList(),
                Prikazivanja = db.Prikazivanje.Select(x => new SelectListItem()
                {
                    Value = x.PrikazivanjeID.ToString(),
                    Text = x.Predstava.Naziv+" / "+x.DatumPrikazivanja.ToShortDateString()
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Snimi(RezervacijaDodajVM model)
        {
            MyContext db = new MyContext();
            Rezervacija r = model.Rezervacija;
            r.KupacID = model.Rezervacija.KupacID;
            r.DatumRezervacije = DateTime.Now;
            r.DatumIsteka = db.Prikazivanje.Where(x => x.PrikazivanjeID == r.PrikazivanjeID).Select(x => x.DatumPrikazivanja).FirstOrDefault();
            db.Rezervacija.Add(r);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Rezervacija r = db.Rezervacija.Find(id);

            List<Ulaznica> u = db.Ulaznica.Where(x => x.RezervacijaID == r.RezervacijaID).ToList();
          
             foreach (var yz in u)
             {
                 db.Ulaznica.Remove(yz);
             }
             
            db.Rezervacija.Remove(r);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Odobri(int id)
        {
            MyContext db = new MyContext();
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();    
         

            Rezervacija r = db.Rezervacija.Find(id);
            if (r.Odobrena==false)
            {
                r.Odobrena = true;
            }

            string mailKupca = db.Rezervacija.Where(x=>x.KupacID==r.KupacID).Select(x => x.Kupac.Email).FirstOrDefault();



            db.SaveChanges();
            {
                var message = new MimeMessage();
                message.To.Add(new MailboxAddress(mailKupca));
                message.From.Add(new MailboxAddress("pozoriste.1234@outlook.com"));

                message.Subject = "Zahtjev za rezervaciju";
                message.Body = new TextPart("plain")
                {
                    Text = "Vaša rezervacija je odobrena!"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.outlook.com", 587, false);

                    client.Authenticate("pozoriste.1234@outlook.com", "pozoriste123");
                    client.Send(message);

                    client.Disconnect(true);
                }
                return RedirectToAction("Prikazi");
            }
        }
       
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Rezervacija u = db.Rezervacija.Where(x => x.RezervacijaID == id).Include(x=>x.Prikazivanje).Include(x => x.Kupac).FirstOrDefault();

            RezervacijaUrediVM model = new RezervacijaUrediVM()
            {
                RezervacijaID= id,
                Kupac = db.Kupac.Select(x => new SelectListItem()
                {
                    Value = x.KupacID.ToString(),
                    Text = x.Ime+" "+x.Prezime
                }).ToList(),
                Prikazivanje = db.Prikazivanje.Select(x => new SelectListItem()
                {
                    Value = x.PrikazivanjeID.ToString(),
                    Text = x.Predstava.Naziv + " / " + x.DatumPrikazivanja.ToShortDateString()
                }).ToList(),
                kupacid = u.KupacID,
                prikazivanjeId=u.PrikazivanjeID,
                Odobrena=u.Odobrena,
                datumIst=u.DatumIsteka,
                datumRez=u.DatumRezervacije
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult UrediSnimi(RezervacijaUrediVM model)
        {
            MyContext db = new MyContext();
            Rezervacija u = db.Rezervacija.Where(x => x.RezervacijaID== model.RezervacijaID).Include(x=>x.Prikazivanje).Include(x => x.Kupac).FirstOrDefault();

            u.RezervacijaID = model.RezervacijaID;
            u.KupacID = model.kupacid;
            u.PrikazivanjeID = model.prikazivanjeId;
            u.Odobrena = model.Odobrena;
            u.DatumRezervacije= model.datumRez;
            u.DatumIsteka= model.datumIst;

            List<SelectListItem> kupac = db.Kupac.Select(x => new SelectListItem()
            {
                Value = x.KupacID.ToString(),
                Text = x.Ime+" "+x.Prezime
            }).ToList();
            kupac = model.Kupac;

            List<SelectListItem> prikazivanje = db.Prikazivanje.Select(x => new SelectListItem()
            {
                Value = x.PrikazivanjeID.ToString(),
                Text = x.Predstava.Naziv + " / " + x.DatumPrikazivanja.ToShortDateString()
            }).ToList();
            prikazivanje = model.Prikazivanje;

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi/" + model.RezervacijaID);
        }
    }
}