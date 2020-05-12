using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class GlumacPrikaziVM
    {
        public List<Row> lista { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Ime{ get; set; }        
            public string Prezime{ get; set; }        
            public string BrojUgovora { get; set; }
            public string Email { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string adresaaSlike { get; set; }
        }
    }
}
