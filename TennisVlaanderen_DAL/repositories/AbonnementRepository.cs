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
                            WHERE C.ClubNaam LIKE '%{clubNaam}%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Abonnement>(sql);
            }
        }

        public List<Abonnement> OphalenSpelerabonnement(int id)
        {
            string sql = $@"SELECT * 
                            FROM TennisVlaanderen.Abonnement A
                            JOIN TennisVlaanderen.Speler S ON A.SpelerID = S.Id
                            WHERE S.Id = {id}";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Abonnement>(sql).ToList();
            }
        }

        public bool AbonnementToevoegen(Abonnement abonnement)
        {
            string sql = @"INSERT INTO TennisVlaanderen.Abonnement (SpelerID, ClubID, Lessen, Stages)
                          VALUES (@SpelerID, @ClubID, @Lessen, @Stages)";

            var parameter = new
            {
                @SpelerID = abonnement.SpelerID,
                ClubID = abonnement.ClubID,
                Lessen = abonnement.Lessen,
                Stages = abonnement.Stages,
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
   

        public bool AbonnementDelete(string abonnementID)
        {
            string sql = @"DELETE FROM TennisVlaanderen.Abonnement
                           WHERE Id = @Id";

            var parameter = new
            {
                Id = abonnementID
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

        public bool AbonnementUpdate(Abonnement abonnement)
        {
            string sql = @"UPDATE TennisVlaanderen.Abonnement                         
                        SpelerID = @SpelerID,    
                        ClubID = @ClubID,
                        Lessen = @Lessen,
                        Stages = @Stages
                        WHERE Id = @Id";

            var parameter = new
            {
                @Id = abonnement.Id,               
                SpelerID = abonnement.SpelerID,
                @ClubID = abonnement.ClubID,
                @Lessen = abonnement.Lessen,
                @Stages = abonnement.Stages,
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
