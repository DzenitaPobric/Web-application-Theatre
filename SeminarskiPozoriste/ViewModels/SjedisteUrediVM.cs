using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class SjedisteUrediVM
    {
        public int Id { get; set; }
        public int Red { get; set; }
        public int Kolona { get; set; }
        public List<SelectListItem> Sala { get; set; }
        public int salaId { get; set; }
    }
}
