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
        public IEnumerable<SpelerClubTornooi> OphalenSpelerClubTornooi(int id)
        {
            string sql = $@"SELECT *
                           FROM TennisVlaanderen.SpelerClubTornooi SCT
                           JOIN TennisVlaanderen.Club C ON SCT.ClubID = C.Id
                           JOIN TennisVlaanderen.Speler S ON SCT.SpelerID = S.Id
                           JOIN TennisVlaanderen.Tornooi T ON SCT.TornooiID = T.Id
                           WHERE S.Id = {id}";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<SpelerClubTornooi>(sql);
            }
        }

        public bool SpelerClubTornooiDelete(string spelerClubTornooiID)
        {
            string sql = @"
                           DELETE FROM TennisVlaanderen.SpelerClubTornooi
                           WHERE Id = @Id";

            var parameter = new
            {
                Id = spelerClubTornooiID
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var affectedRows = db.Execute(sql, parameter);
                if (affectedRows >= 1)
                {
                    return true;
                }
            }

            return false;
        }

        public bool SpelerClubTornooiToevoegen(SpelerClubTornooi spelerClubTornooi)
        {
            string sql = @"INSERT INTO TennisVlaanderen.SpelerClubTornooi (ClubID, SpelerID, TornooiID)
                          VALUES (@ClubID, @SpelerID, @TornooiID)";

            var parameter = new
            {
                @ClubID = spelerClubTornooi.ClubID,
                @SpelerID = spelerClubTornooi.SpelerID,
                @TornooiID = spelerClubTornooi.TornooiID,               
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var affectedRows = db.Execute(sql, parameter);
                if (affectedRows == 1)
                {
                    return true;
                }
            }

            return false;
        }

        public bool SpelerClubTornooiUpdate(SpelerClubTornooi spelerClubTornooi)
        {
            string sql = @"UPDATE TennisVlaanderen.SpelerClubTornooi SET
                        ClubID = @ClubID,
                        SpelerID = @SpelerID,                        
                        TornooiID = @TornooiID                      
                        WHERE Id = @Id";

            var parameter = new
            {
                @Id = spelerClubTornooi.Id,
                @ClubID = spelerClubTornooi.ClubID,
                SpelerID = spelerClubTornooi.SpelerID,
                TornooiID = spelerClubTornooi.TornooiID,
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var affectedRows = db.Execute(sql, parameter);
                if (affectedRows == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
