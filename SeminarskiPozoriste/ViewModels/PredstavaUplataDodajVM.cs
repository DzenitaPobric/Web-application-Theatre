using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class PredstavaUplataDodajVM
    {
        public PredstavaUplata PredstavaUplata { get; set; }
        public List<SelectListItem> Uplata { get; set; }
        public List<SelectListItem> Predstava { get; set; }
    }
}
