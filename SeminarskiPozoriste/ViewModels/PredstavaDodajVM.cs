using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class PredstavaDodajVM
    {
        public Predstava Predstava { get; set; }
        public List<SelectListItem> Zanr { get; set; }
       
    }
}
