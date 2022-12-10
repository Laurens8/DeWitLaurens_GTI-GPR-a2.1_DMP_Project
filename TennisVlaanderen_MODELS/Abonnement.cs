using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_Models
{
    public class Abonnement
    {
        public int id { get; set; }
        public int spelerID { get; set; }
        public int clubID { get; set; }
        public string lessen { get; set; }
        public string stages { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
