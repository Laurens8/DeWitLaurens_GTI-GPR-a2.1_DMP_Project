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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
