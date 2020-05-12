using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiPozoriste.data.Models
{
    public class Rezervacija
    {
        [Key]
        public int RezervacijaID{ get; set; }

        public DateTime DatumRezervacije { get; set; }

        public DateTime DatumIsteka { get; set; }

        public bool Odobrena { get; set; }

        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }

        [ForeignKey("Prikazivanje")]
        public int PrikazivanjeID { get; set; }
        public Prikazivanje Prikazivanje { get; set; }
    }
}
