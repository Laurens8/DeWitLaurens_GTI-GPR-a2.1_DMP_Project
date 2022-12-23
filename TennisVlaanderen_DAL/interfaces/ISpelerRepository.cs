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
        List<Speler> OphalenSpelerEmail();

        List<Speler> OphalenSpeler(string email);

        bool SpelerToevoegen(Speler speler);
        bool SpelerUpdate(Speler speler);
        bool SpelerDelete(string spelerID);
    }
}
