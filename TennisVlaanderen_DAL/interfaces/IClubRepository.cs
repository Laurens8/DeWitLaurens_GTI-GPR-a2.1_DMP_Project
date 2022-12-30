using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface IClubRepository
    {
        IEnumerable<Club> OphalenClubNaam();
        IEnumerable<Club> OphalenClubSpeler(int id);

        bool ClubToevoegen(Club club);
        bool ClubUpdate(Club club);
        bool ClubDelete(string clubID);
    }
}
