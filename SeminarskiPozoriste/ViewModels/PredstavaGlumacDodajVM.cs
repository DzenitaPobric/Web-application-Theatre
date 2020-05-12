using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class PredstavaGlumacDodajVM
    {
        public GlumacPredstava GlumacPredstava { get; set; }
        public List<SelectListItem> Glumac { get; set; }
        public List<SelectListItem> Predstava { get; set; }
    }
}
