using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class GlumacPredstava
    {
        [Key]
        public int GlumacPredstavaID{ get; set; }

        [ForeignKey("Glumac")]
        public int GlumacID{ get; set; }
        public Glumac Glumac { get; set; }

        [ForeignKey("Predstava")]
        public int PredstavaID { get; set; }
        public Predstava Predstava { get; set; }


    }
}
