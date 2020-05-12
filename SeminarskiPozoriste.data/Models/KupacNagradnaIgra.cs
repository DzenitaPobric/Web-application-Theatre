using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class KupacNagradnaIgra
    {
        [Key]
        public int KupacNagradnaIgraID { get; set; }
       
        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }

        [ForeignKey("NagradnaIgra")]
        public int NagradnaIgraID { get; set; }
        public NagradnaIgra NagradnaIgra { get; set; }
    }
}
