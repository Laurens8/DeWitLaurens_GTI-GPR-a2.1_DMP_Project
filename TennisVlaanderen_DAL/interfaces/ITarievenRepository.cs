using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface ITarievenRepository
    {
        IEnumerable<TennisVlaanderen_Models.Tarieven> OphalenTarieven();
        List<TennisVlaanderen_Models.Tarieven> OphalenClubNaam();
        List<TennisVlaanderen_Models.Tarieven> OphalenLeeftijdGraad();
        List<TennisVlaanderen_Models.Tarieven> OphalenTypeTennis();
        List<TennisVlaanderen_Models.Tarieven> OphalenTypePadel();
        List<TennisVlaanderen_Models.Tarieven> OphalenTypeTennisPlusPadel();
        List<TennisVlaanderen_Models.Tarieven> OphalenPrijs();     
    }
}
