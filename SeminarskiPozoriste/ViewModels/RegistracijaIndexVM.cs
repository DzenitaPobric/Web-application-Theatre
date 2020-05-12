using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class RegistracijaIndexVM
    {
        //podaci za tabelu KorisnickiNalog
        public KorisnickiNalog KorisnickiNalog { get; set; }

        //podaci za tabelu Klijent
        //public string Ime{ get; set; }
        //public string Prezime{ get; set; }
        //public string brTelefona{ get; set; }
        public Kupac Kupac{ get; set; }

        public List<SelectListItem> gradovi{ get; set; }
    }
}
