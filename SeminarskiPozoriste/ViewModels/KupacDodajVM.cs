using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class KupacDodajVM
    {
        public Kupac Kupac { get; set; }
        public int brojTokena { get; set; }
        public List<SelectListItem> grad { get; set; }
    }
}
