using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class IzvjestajUplataVM
    {
        public List<Row> lista { get; set; }
        public double UkupnaZarada { get; set; }


        public class Row
        {
            public string nazivSponzora { get; set; }
            public int UplataId { get; set; }
            public int brojUplata { get; set; }
            public double zarada { get; set; }

        }
    }
}
