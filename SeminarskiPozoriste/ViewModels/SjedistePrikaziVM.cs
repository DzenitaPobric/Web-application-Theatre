using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class SjedistePrikaziVM
    {
        public List<Row> lista { get; set; }
        public class Row
        {
            public int SjedisteID { get; set; }
            public int Red { get; set; }
            public int Kolona { get; set; }
            public string NazivSale { get; set; }
        }
    }
}
