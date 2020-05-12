using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class UplataPrikaziVM
    {
        public List<Row> lista { get; set; }
        public class Row
        {
            public int UplataID { get; set; }
            public string Naziv { get; set; }
            public string Svrha { get; set; }
            public float Iznos { get; set; }
            public string NazivSponzora { get; set; }
        }
    }
}