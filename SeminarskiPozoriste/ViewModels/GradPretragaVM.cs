using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class GradPretragaVM
    {
        public IQueryable<Grad> Grad { get; set; }
        public string Pretraga { get; set; }
    }
}
