using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_Models
{
    public class SpelerClubTornooi
    {
        public int id { get; set; }
        public int clubID { get; set; }
        public int spelerID { get; set; }
        public int tornooiID { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
