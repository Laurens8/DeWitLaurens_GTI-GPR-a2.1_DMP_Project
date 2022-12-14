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
        public IEnumerable<TennisVlaanderen_Models.SpelerClubTornooi> OphalenSpelerClubTornooi()
        {
            string sql = @"SELECT * 
                           FROM TennisVlaanderen.SpelerClubTornooi SCT
                           JOIN TennisVlaanderen.Club C ON SCT.clubID = C.id
                           JOIN TennisVlaanderen.Speler S ON SCT.spelerID = S.id
                           JOIN TennisVlaanderen.Tornooi T ON SCT.tornooiID = T.id";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TennisVlaanderen_Models.SpelerClubTornooi>(sql);
            }
        }
    }
}
