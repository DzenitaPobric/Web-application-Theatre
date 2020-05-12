using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class AutorizacijskiToken
    {
        public int Id { get; set; }
        public string Vrijednost { get; set; }
        [ForeignKey("KorisnickiNalog")]
        public int KorisnickiNalogID { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string IpAdresa { get; set; }
    }
}
