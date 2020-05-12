using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class Sala
    {
        [Key]
        public int SalaID { get; set; }

        [Required(ErrorMessage = "Naziv je obavezno polje")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Kapacitet je obavezno polje")]
        [Range(40, 500,ErrorMessage ="Kapacitet treba biti u opsegu 40-500")]
        public int Kapacitet { get; set; }

        public bool Klimatizacija { get; set; }

     
    }
}
