using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_Models
{
    public class Speler
    {
        public int id { get; set; }
        public string naam { get; set; }
        public string voornaam { get; set; }
        public string klassement { get; set; }
        public string geslacht { get; set; }
        public System.DateTime geboorteDatum { get; set; }
        public string nationaliteit { get; set; }
        public string adres { get; set; }
        public string land { get; set; }
        public string telefoon { get; set; }
        public string email { get; set; }
        public string rijksNummer { get; set; }

        public override string ToString()
        {
            return naam;
        }
    }
}
