using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_Models
{
    public class Tarieven
    {
        public int id { get; set; }
        public int clubID { get; set; }
        public string leeftijdgraad { get; set; }
        public string typeTennis { get; set; }
        public Nullable<decimal> prijs { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
