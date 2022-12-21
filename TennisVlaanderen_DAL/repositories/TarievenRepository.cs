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
            string sql = @"SELECT naam FROM TennisVlaanderen.Club C
                          JOIN TennisVlaanderen.Tarieven T ON T.clubID = C.naam";
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

        public List<Tarieven> OphalenTypeTennis()
        {
            string sql = "SELECT leeftijdgraad, prijs, typeTennis FROM TennisVlaanderen.Tarieven T WHERE T.typeTennis LIKE '%tennis%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql).ToList();
            }
        }

        public List<Tarieven> OphalenTypePadel()
        {
            string sql = "SELECT leeftijdgraad, prijs, typeTennis FROM TennisVlaanderen.Tarieven T WHERE T.typeTennis LIKE '%paddel%'";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tarieven>(sql).ToList();
            }
        }

        public List<Tarieven> OphalenTypeTennisPlusPadel()
        {
            string sql = "SELECT leeftijdgraad, prijs, typeTennis FROM TennisVlaanderen.Tarieven T WHERE T.typeTennis LIKE '%+%'";
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
