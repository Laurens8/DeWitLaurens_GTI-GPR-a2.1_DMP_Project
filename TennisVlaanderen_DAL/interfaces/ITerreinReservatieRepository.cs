using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface ITerreinReservatieRepository
    {
        IEnumerable<TerreinReservatie> OphalenTerreinReservatie();
        List<TerreinReservatie> OphalenterreinGravel(string TypeOndergrond);
        List<TerreinReservatie> OphalenterreinGras(string TypeOndergrond);
        List<TerreinReservatie> OphalenReservatie(int id);

        bool TerreinReservatieToevoegen(TerreinReservatie terrein);
        bool TerreinReservatieUpdate(TerreinReservatie terrein);
        bool TerreinReservatieDelete(string terreinReservatieID);
    }
}
