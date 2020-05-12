using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class PredstavaKupacDodajVM
    {
        public PredstavaKupac PredstavaKupac { get; set; }
        public string predstava { get; set; }
        public int predstavaId { get; set; }
    }
}
