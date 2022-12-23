using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisVlaanderen_DAL.interfaces;
using Dapper;

namespace TennisVlaanderen_DAL.repositories
{
    public class AbonnementRepository : BaseRepository, IAbonnementRepository
    {
        public IEnumerable<Abonnement> OphalenAbonnement(string clubNaam)
        {
            string sql = $@"SELECT * 
                            FROM TennisVlaanderen.Abonnement A
                            JOIN TennisVlaanderen.Club C ON A.ClubID = C.Id 
                            WHERE C.Naam LIKE '%{clubNaam}%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Abonnement>(sql);
            }
        }
    }
}
