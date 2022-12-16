using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface ISpelerRepository
    {
        List<TennisVlaanderen_Models.Speler> OphalenSpelerEmail();

        List<TennisVlaanderen_Models.Speler> OphalenSpeler();

        bool SpelerToevoegen(TennisVlaanderen_Models.Speler speler);
        bool SpelerUpdate(TennisVlaanderen_Models.Speler speler);
        bool SpelerDelete(string spelerID);
    }
}
