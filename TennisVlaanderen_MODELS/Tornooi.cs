using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_Models
{
    public class Tornooi
    {
        public int id { get; set; }
        public string naamTornooi { get; set; }
        public System.DateTime datum { get; set; }
        public string circuit { get; set; }
        public string typeCompetitie { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
