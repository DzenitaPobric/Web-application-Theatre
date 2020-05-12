using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class PrikazivanjeUrediVM
    {
        public List<SelectListItem> Sala { get; set; }
        public int salaid { get; set; }
        public List<SelectListItem> Predstava { get; set; }
        public int predstavaid { get; set; }
        public int PrikazivanjeID { get; set; }
        public DateTime datumPrikazivanja { get; set; }
        public decimal Cijena { get; set; }
    }
}
