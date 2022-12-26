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

        public List<TerreinReservatie> OphalenReservatie()
        {
            string sql = @"SELECT * 
                           FROM TennisVlaanderen.TerreinReservatie T
                           JOIN TennisVlaanderen.Speler S ON T.SpelerId = S.Id";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TerreinReservatie>(sql).ToList();
            }
        }
    }
}
