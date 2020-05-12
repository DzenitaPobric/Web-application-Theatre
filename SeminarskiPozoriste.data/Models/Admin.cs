using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Ime { get; set; }
        public string Prezime{ get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public int KorisnickiNalogID { get; set; }
    }

  
}
