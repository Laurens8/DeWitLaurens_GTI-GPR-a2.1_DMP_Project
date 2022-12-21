using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL
{
    public partial class Abonnement
    {
        public override string ToString()
        {
            return Lessen + " " + Stages;
        }
    }
}
