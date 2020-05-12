using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class Uplata
    {
        [Key]
        public int UplataID { get; set; }

        public string Naziv { get; set; }

        public string Svrha { get; set; }

        public float Iznos{ get; set; }

        [ForeignKey("Sponzor")]
        public int SponzorID { get; set; }
        public Sponzor Sponzor { get; set; }
    }
}
