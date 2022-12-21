using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL
{
    public partial class Tarieven
    {
        public override string ToString()
        {
            return Leeftijdgraad + " " + ((double?)Prijs) + "€" + " " + TypeTennis;
        }
    }
}
