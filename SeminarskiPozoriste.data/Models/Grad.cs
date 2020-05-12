using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class Grad
    {
        [Key]
        public int GradID { get; set; }

        [Required(ErrorMessage ="Naziv je obavezno polje")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage ="Ime se sastoji samo od slova")]
        public String Naziv { get; set; }
    }
}
