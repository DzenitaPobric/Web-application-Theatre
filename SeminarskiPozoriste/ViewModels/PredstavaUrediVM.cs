using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class PredstavaUrediVM
    {
        public int PredstavaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Reziser { get; set; }
        public int Trajanje { get; set; }


        public List<SelectListItem> Zanr { get; set; }
        public int zanrId { get; set; }
    }
}
