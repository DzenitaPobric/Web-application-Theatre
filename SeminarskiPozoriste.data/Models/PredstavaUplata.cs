using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class PredstavaUplata
    {
        [Key]
        public int PredstavaUplataID{ get; set; }

        public DateTime DatumUplate { get; set; }

        [ForeignKey("Predstava")]
        public int PredstavaID { get; set; }
        public Predstava Predstava { get; set; }
   


        [ForeignKey("Uplata")]
        public int UplataID { get; set; }
        public Uplata Uplata { get; set; }

    }
}
