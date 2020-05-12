using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class NovostiPrikazVM
    {
        public List<Row> lista { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public string Tekst { get; set; }
            public string KratkiSadrzaj { get; set; }

            public DateTime DatumVrijemeObjave { get; set; }
            public string adresaaSlike { get; set; }
        }
    }
}
