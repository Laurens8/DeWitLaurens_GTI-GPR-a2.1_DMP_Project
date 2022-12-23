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
        public IEnumerable<Tarieven> OphalenTarieven()
        {
            string sql = @"SELECT * FROM TennisVlaanderen.Tarieven";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql);
            }
        }

        public List<Tarieven> OphalenClubNaam()
        {
            string sql = @"SELECT Naam FROM TennisVlaanderen.Club C
                          JOIN TennisVlaanderen.Tarieven T ON T.ClubID = C.Naam";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql).ToList();
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
    }
}
