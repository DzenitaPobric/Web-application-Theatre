using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class ZanrPrikaziVM
    {
        public List<Row> lista { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
        }
    }
}
