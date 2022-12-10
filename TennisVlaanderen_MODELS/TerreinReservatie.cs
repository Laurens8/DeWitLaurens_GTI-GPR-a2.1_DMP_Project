using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_Models
{
    public class TerreinReservatie
    {
        public int id { get; set; }
        public int spelerID { get; set; }
        public string terreinNummer { get; set; }
        public string typeOndergrond { get; set; }
        public string typeTennis { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
