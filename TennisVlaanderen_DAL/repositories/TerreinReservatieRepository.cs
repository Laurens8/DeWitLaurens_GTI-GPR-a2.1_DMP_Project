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
        public IEnumerable<TerreinReservatie> OphalenTerreinReservatie()
        {
            string sql = "SELECT * FROM TennisVlaanderen.TerreinReservatie";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TerreinReservatie>(sql);
            }
        }

        public List<TerreinReservatie> OphalenterreinGras(string TypeOndergrond)
        {
            string sql = $"SELECT TerreinNummer, TypeOndergrond FROM TennisVlaanderen.TerreinReservatie T WHERE T.TypeOndergrond LIKE '%{TypeOndergrond}%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TerreinReservatie>(sql).ToList();
            }
        }

        public List<TerreinReservatie> OphalenterreinGravel(string TypeOndergrond)
        {
            string sql = $"SELECT TerreinNummer, TypeOndergrond FROM TennisVlaanderen.TerreinReservatie T WHERE T.TypeOndergrond LIKE '%{TypeOndergrond}%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TerreinReservatie>(sql).ToList();
            }
        }

        public IEnumerable<TerreinReservatie> OphalenReservatie(int id)
        {
            string sql = $@"SELECT * 
                           FROM TennisVlaanderen.TerreinReservatie T
                           JOIN TennisVlaanderen.Speler S ON T.SpelerID = S.Id
                           WHERE S.Id = {id}";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TerreinReservatie>(sql).ToList();
            }
        }

        public bool TerreinReservatieToevoegen(TerreinReservatie terrein)
        {
            string sql = @"INSERT INTO TennisVlaanderen.TerreinReservatie (SpelerID, TerreinNummer, TypeOndergrond, TypeTennis)
                          VALUES (@SpelerID, @TerreinNummer, @TypeOndergrond, @TypeTennis)";

            var parameter = new
            {
                @SpelerID = terrein.SpelerID,
                @TerreinNummer = terrein.TerreinNummer,
                @TypeOndergrond = terrein.TypeOndergrond,
                @TypeTennis = terrein.TypeTennis,
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

        public bool TerreinReservatieDelete(string terreinReservatieID)
        {
            string sql = @"DELETE FROM TennisVlaanderen.TerreinReservatie
                           WHERE Id = @Id";

            var parameter = new
            {
                Id = terreinReservatieID
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

        public bool TerreinReservatieUpdate(TerreinReservatie terrein)
        {
            string sql = @"UPDATE TennisVlaanderen.TerreinReservatie 
                        SpelerId = @SpelerId,
                        TerreinNummer = @TerreinNummer,
                        TypeOndergrond = @ TypeOndergrond,
                        TypeTennis = @TypeTennis
                        WHERE Id = @Id";

            var parameter = new
            {
                @Id = terrein.Id,
                @SpelerId = terrein.SpelerID,
                @TerreinNummer = terrein.TerreinNummer,
                @TypeOndergrond = terrein.TypeOndergrond,
                @TypeTennis = terrein.TypeTennis,               
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
