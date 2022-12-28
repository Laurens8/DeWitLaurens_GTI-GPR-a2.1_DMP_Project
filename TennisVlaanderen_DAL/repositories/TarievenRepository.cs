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
        public IEnumerable<Tarieven> OphalenTarieven(string clubNaam)
        {
            string sql = $@"SELECT leeftijdgraad, prijs, typeTennis 
                            FROM TennisVlaanderen.Tarieven T
                            JOIN TennisVlaanderen.Club C ON T.ClubID = C.Id 
                            WHERE C.Naam LIKE '%{clubNaam}%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql);
            }
        }      

        public List<Tarieven> OphalenLeeftijdGraad()
        {
            string sql = "SELECT leeftijdgraad FROM TennisVlaanderen.Tarieven";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql).ToList();
            }
        }

        public List<Tarieven> OphalenTypeTennis(string clubNaam)
        {
            string sql = $@"SELECT leeftijdgraad, prijs, typeTennis 
                            FROM TennisVlaanderen.Tarieven T
                            JOIN TennisVlaanderen.Club C ON T.ClubID = C.Id 
                            WHERE T.typeTennis LIKE '%tennis' AND C.Naam LIKE '%{clubNaam}%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql).ToList();
            }
        }

        public List<Tarieven> OphalenTypePadel(string clubNaam)
        {
            string sql = $@"SELECT leeftijdgraad, prijs, typeTennis 
                            FROM TennisVlaanderen.Tarieven T
                            JOIN TennisVlaanderen.Club C ON T.ClubID = C.Id 
                            WHERE T.typeTennis LIKE 'paddel%' AND C.Naam LIKE '%{clubNaam}%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql).ToList();
            }
        }

        public List<Tarieven> OphalenTypeTennisPlusPadel(string clubNaam)
        {
            string sql = $@"SELECT leeftijdgraad, prijs, typeTennis 
                            FROM TennisVlaanderen.Tarieven T
                            JOIN TennisVlaanderen.Club C ON T.ClubID = C.Id 
                            WHERE T.typeTennis LIKE '%+%' AND C.Naam LIKE '%{clubNaam}%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql).ToList();
            }
        }

        public List<Tarieven> OphalenPrijs()
        {
            string sql = "SELECT prijs FROM TennisVlaanderen.Tarieven";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql).ToList();
            }
        }

        public bool TarievenDelete(string tarievenID)
        {
            string sql = @"
                           DELETE FROM TennisVlaanderen.Tarieven
                           WHERE Id = @Id";

            var parameter = new
            {
                Id = tarievenID
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

        public bool TarievenUpdate(Tarieven tarieven)
        {
            string sql = @"UPDATE TennisVlaanderen.Tarieven 
                        ClubID = @ClubID,
                        Leeftijdgraad = @Leeftijdgraad,                        
                        TypeTennis = @TypeTennis,
                        Prijs = @Prijs
                        WHERE Id = @Id";

            var parameter = new
            {
                @Id = tarieven.Id,
                @ClubID = tarieven.ClubID,
                @Leeftijdgraad = tarieven.Leeftijdgraad,
                @TypeTennis = tarieven.TypeTennis,
                @Prijs = @tarieven.Prijs,
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
