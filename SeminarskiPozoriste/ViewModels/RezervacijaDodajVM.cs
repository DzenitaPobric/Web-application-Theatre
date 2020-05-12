using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class RezervacijaDodajVM
    {

        public Rezervacija Rezervacija { get; set; }

        public List<SelectListItem> Kupci { get; set; }
        public List<SelectListItem> Prikazivanja { get; set; }


    }
}
