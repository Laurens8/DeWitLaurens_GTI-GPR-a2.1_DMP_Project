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
    public class SpelerClubTornooiRepository : BaseRepository, ISpelerClubTornooiRepository
    {
        public IEnumerable<SpelerClubTornooi> OphalenSpelerClubTornooi()
        {
            string sql = @"SELECT * 
                           FROM TennisVlaanderen.SpelerClubTornooi SCT
                           JOIN TennisVlaanderen.Club C ON SCT.ClubID = C.Id
                           JOIN TennisVlaanderen.Speler S ON SCT.SpelerID = S.Id
                           JOIN TennisVlaanderen.Tornooi T ON SCT.TornooiID = T.Id";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<SpelerClubTornooi>(sql);
            }
        }
    }
}
