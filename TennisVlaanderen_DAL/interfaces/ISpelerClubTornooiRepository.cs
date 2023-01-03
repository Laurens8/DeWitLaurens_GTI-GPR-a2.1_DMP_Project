using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface ISpelerClubTornooiRepository
    {
        IEnumerable<SpelerClubTornooi> OphalenSpelerClubTornooi(int id);
        List<SpelerClubTornooi> OphalenTornooi(int id);

        bool SpelerClubTornooiToevoegen(SpelerClubTornooi spelerClubTornooi);
        bool SpelerClubTornooiUpdate(SpelerClubTornooi spelerClubTornooi);
        bool SpelerClubTornooiDelete(string spelerClubTornooiID);
    }
}
