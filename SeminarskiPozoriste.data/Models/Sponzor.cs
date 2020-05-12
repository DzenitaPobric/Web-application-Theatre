using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class Sponzor
    {
        [Key]
        public int SponzorID { get; set; }

        public string Naziv { get; set; }

        [RegularExpression(@"\d{3}\-\d{3}\-\d{3}", ErrorMessage ="Broj nije u pravilnom formatu (xxx-xxx-xxx)")]
        public string BrojTelefona { get; set; }
    }
}
