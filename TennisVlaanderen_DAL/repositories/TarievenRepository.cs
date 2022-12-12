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
    public class TarievenRepository : BaseRepository, ITarievenRepository
    {
        public IEnumerable<TennisVlaanderen_Models.Tarieven> OphalenTarieven()
        {
            string sql = "SELECT * FROM TennisVlaanderen.Tarieven";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TennisVlaanderen_Models.Tarieven>(sql);
            }
        }
    }
}
