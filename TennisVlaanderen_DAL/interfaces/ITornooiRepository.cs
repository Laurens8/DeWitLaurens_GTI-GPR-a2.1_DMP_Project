using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface ITornooiRepository
    {
        IEnumerable<Tornooi> OphalenTornooi();

        List<Tornooi> OphalenTornooiNaam(string circuitNaam);
        List<Tornooi> OphalenCircuitNaam();
        List<Tornooi> OphalenDatum();
        List<Tornooi> OphalenTypeCompetitie();

        bool TornooiUpdate(Tornooi tornooi);
        bool TornooiDelete(string tornooiID);
    }
}
