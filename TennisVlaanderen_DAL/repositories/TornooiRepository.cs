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
            string sql = $@"SELECT DISTINCT * 
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

        public bool TornooiDelete(string tornooiID)
        {
            string sql = @"
                           DELETE FROM TennisVlaanderen.Tornooi
                           WHERE Id = @Id";

            var parameter = new
            {
                Id = tornooiID
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

        public bool TornooiUpdate(Tornooi tornooi)
        {
            string sql = @"UPDATE TennisVlaanderen.Tornooi SET
                        NaamTornooi = @NaamTornooi,
                        Datum = @Datum,
                        Circuit = @ Circuit,
                        TypeCompetitie = @TypeCompetitie
                        WHERE Id = @Id";

            var parameter = new
            {
                @Id = tornooi.Id,
                @NaamTornooi = tornooi.NaamTornooi,
                @Datum = tornooi.Datum,
                @Circuit = tornooi.Circuit,
                @TypeCompetitie = tornooi.TypeCompetitie,               
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
