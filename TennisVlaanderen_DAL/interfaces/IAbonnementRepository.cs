using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface IAbonnementRepository
    {
        IEnumerable<Abonnement> OphalenAbonnement(string clubNaam);

        List<Abonnement> OphalenSpelerAbonnement(int id);

        bool AbonnementToevoegen(Abonnement abonnement);
        bool AbonnementUpdate(Abonnement abonnement);
        bool AbonnementDelete(string abonnementID);
    }
}
