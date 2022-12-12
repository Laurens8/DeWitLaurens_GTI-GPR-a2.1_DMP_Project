using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisVlaanderen_DAL.interfaces;
using Dapper;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_DAL.repositories
{
    public class ClubRepository : BaseRepository, IClubRepository
    {
        public IEnumerable<TennisVlaanderen_Models.Club> OphalenClub()
        {
            string sql = @"SELECT C.* FROM TennisVlaanderen.CLUB AS C";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TennisVlaanderen_Models.Club>(sql);
            }
        }
    }
}
