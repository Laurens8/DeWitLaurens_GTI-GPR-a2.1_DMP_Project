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
        public IEnumerable<Abonnement> OphalenAbonnement()
        {
            string sql = "SELECT * FROM TennisVlaanderen.Abonnement";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Abonnement>(sql);
            }
        }
    }
}
