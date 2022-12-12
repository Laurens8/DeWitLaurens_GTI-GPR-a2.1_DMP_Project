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
    public class TerreinReservatieRepository : BaseRepository, ITerreinReservatieRepository
    {
        public IEnumerable<TennisVlaanderen_Models.TerreinReservatie> OphalenTerreinReservatie()
        {
            string sql = "SELECT * FROM TennisVlaanderen.TerreinReservatie";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TennisVlaanderen_Models.TerreinReservatie>(sql);
            }
        }
    }
}
