using Microsoft.AspNetCore.Http;
using SeminarskiPozoriste.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiPozoriste.web.ViewModels
{
    public class NovostiDodajVM
    {
        public Novosti Novosti { get; set; }
        public IFormFile Photo { get; set; }
    }
}
