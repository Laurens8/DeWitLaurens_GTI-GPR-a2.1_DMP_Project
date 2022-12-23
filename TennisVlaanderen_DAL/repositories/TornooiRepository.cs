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
    public class TornooiRepository : BaseRepository, ITornooiRepository
    {
        public IEnumerable<Tornooi> OphalenTornooi()
        {
            string sql = "SELECT * FROM TennisVlaanderen.Tornooi";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tornooi>(sql);
            }
        }

        public List<Tornooi> OphalenTornooiNaam(string circuitNaam)
        {
            string sql = $@"SELECT DISTINCT NaamTornooi 
                           FROM TennisVlaanderen.Tornooi T
                           WHERE T.Circuit LIKE '%{circuitNaam}%'";                           

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tornooi>(sql).ToList();
            }
        }

        public List<Tornooi> OphalenCircuitNaam()
        {
            string sql = @"SELECT DISTINCT Circuit 
                           FROM TennisVlaanderen.Tornooi";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tornooi>(sql).ToList();
            }
        }

        public List<Tornooi> OphalenDatum()
        {
            string sql = @"SELECT Datum 
                           FROM TennisVlaanderen.Tornooi";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tornooi>(sql).ToList();
            }
        }

        public List<Tornooi> OphalenTypeCompetitie()
        {
            string sql = @"SELECT TypeCompetitie 
                           FROM TennisVlaanderen.Tornooi";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Tornooi>(sql).ToList();
            }
        }
    }
}
