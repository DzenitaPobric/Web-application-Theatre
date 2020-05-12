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
    public class AjaxUplateController : Controller
    {
        public IActionResult Index(int id)
        {
            MyContext db = new MyContext();
            AjaxUplateIndexVM model = new AjaxUplateIndexVM()
            {
                SponzorId = id,
                lista = db.Uplata.Where(x => x.SponzorID == id).Select(x => new AjaxUplateIndexVM.Row
                    {
                        Iznos = x.Iznos,
                        Naziv = x.Naziv,
                        NazivSponzora = x.Sponzor.Naziv,
                        Svrha = x.Svrha,
                        UplataID = x.UplataID
                    }).ToList()
            };
            return PartialView(model);
        }        
    }
}