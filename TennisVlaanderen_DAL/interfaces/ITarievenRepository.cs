using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface ITarievenRepository
    {
        IEnumerable<Tarieven> OphalenTarieven();
        List<Tarieven> OphalenClubNaam();
        List<Tarieven> OphalenLeeftijdGraad();
        List<Tarieven> OphalenTypeTennis(string clubNaam);
        List<Tarieven> OphalenTypePadel(string clubNaam);
        List<Tarieven> OphalenTypeTennisPlusPadel(string clubNaam);
        List<Tarieven> OphalenPrijs();     
    }
}
