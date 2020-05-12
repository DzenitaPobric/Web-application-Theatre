using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class KupacNagradnaIgraDodajVM
    {
        public KupacNagradnaIgra KupacNagradnaIgra { get; set; }


        public List<SelectListItem> NagradnaIgra { get; set; }
        public int nagradnaIgraId { get; set; }

        public List<SelectListItem> Kupac { get; set; }
        public int kupacId { get; set; }

    }
}
