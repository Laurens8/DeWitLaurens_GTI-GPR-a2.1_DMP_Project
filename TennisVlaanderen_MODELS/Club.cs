using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_Models
{
    public class Club
    {
        public int id { get; set; }
        public string naam { get; set; }
        public string adres { get; set; }
        public string telefoon { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string kwaliteitLabel { get; set; }
        public string clubaanbod { get; set; }

        public Club() { }

        public Club(int id, string naam, string adres, string telefoon, string email, string website, string kwaliteitLabel, string clubaanbod) 
        {
            this.id = id;
            this.naam = naam;
            this.adres = adres;
            this.telefoon = telefoon;
            this.email = email;
            this.website = website;
            this.kwaliteitLabel = kwaliteitLabel;
            this.clubaanbod = clubaanbod;
        }      

        public override string ToString()
        {
            return naam;
        }
    }
}
