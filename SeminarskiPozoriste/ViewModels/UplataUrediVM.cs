using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class UplataUrediVM
    {
        public string Naziv { get; set; }
        public float Iznos{ get; set; }
        public string Svrha{ get; set; }
        public List<SelectListItem> Sponzor { get; set; }
        public int sponzorID { get; set; }
        public int UplataID { get; set; }
    }
}
