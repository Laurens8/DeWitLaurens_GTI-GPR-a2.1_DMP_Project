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
        List<Tarieven> OphalenTypeTennis();
        List<Tarieven> OphalenTypePadel();
        List<Tarieven> OphalenTypeTennisPlusPadel();
        List<Tarieven> OphalenPrijs();     
    }
}
