using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL
{
    public partial class TerreinReservatie
    {
        public override string ToString()
        {
            return TerreinNummer + " " + TypeOndergrond;
        }
    }
}
