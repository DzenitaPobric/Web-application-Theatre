using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class PrikazivanjeDodajVM
    {
        public Prikazivanje Prikazivanje { get; set; }

        public List<SelectListItem> Predstavae { get; set; }
        
        public List<SelectListItem>Sale { get; set; }


    }
}
