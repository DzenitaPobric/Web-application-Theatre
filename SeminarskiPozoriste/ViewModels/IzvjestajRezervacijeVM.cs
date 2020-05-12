using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class IzvjestajRezervacijeVM
    {
       
       
        public List<Row> lista { get; set; }

        public double UkupnaZarada { get; set; }

        public class Row
        {
            public string Zanr { get; set; }
            public string Predstava { get; set; }
            public int BrojRezervacija { get; set; }
            public decimal Zarada { get; set; }

        }
    } 
}
