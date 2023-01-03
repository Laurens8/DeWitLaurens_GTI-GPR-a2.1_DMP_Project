using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisVlaanderen_DAL.interfaces;
using Dapper;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_DAL.repositories
{
    public class ClubRepository : BaseRepository, IClubRepository
    {
        public IEnumerable<Club> OphalenClubNaam()
        {
            string sql = @"SELECT * FROM TennisVlaanderen.CLUB C WHERE C.Id > 1";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Club>(sql);
            }
        }

        public IEnumerable<Club> OphalenClubSpeler(int id)
        {
            string sql = $@"SELECT * FROM TennisVlaanderen.CLUB C
                            WHERE C.Id = {id}";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Club>(sql);
            }
        }

        public bool ClubToevoegen(Club club)
        {
            string sql = @"INSERT INTO TennisVlaanderen.Club (ClubNaam, Adres, Telefoon, Email, Website, KwaliteitLabel, Clubaanbod)
                          VALUES (@Naam, @Adres, @Telefoon, @Email, @Website, @KwaliteitLabel, @Clubaanbod)";

            var parameter = new
            {
                @Naam = club.ClubNaam,
                @Adres = club.Adres,
                @Telefoon = club.Telefoon,
                @Email = club.Email,
                @Website = club.Website,
                @KwaliteitLabel = club.KwaliteitLabel,
                @Clubaanbod = club.Clubaanbod,
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


        public bool ClubDelete(string clubID)
        {
            string sql = @"DELETE FROM TennisVlaanderen.Club
                           WHERE Id = @Id";

            var parameter = new
            {
                Id = clubID
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

        public bool ClubUpdate(Club club)
        {
            string sql = @"UPDATE TennisVlaanderen.Club SET                        
                        Naam = @Naam,    
                        Adres = @Adres,
                        Telefoon = @Telefoon,
                        Email = @Email,
                        Website = @Website,
                        KwaliteitLabel = @KwaliteitLabel,
                        Clubaanbod = @Clubaanbod
    &                   WHERE Id = @Id";

            var parameter = new
            {
                @Id = club.Id,
                @Naam = club.ClubNaam,
                @Adres = club.Adres,
                @Telefoon = club.Telefoon,
                @Email = club.Email,
                @Website = club.Website,
                @KwaliteitLabel = club.KwaliteitLabel,
                @Clubaanbod = club.Clubaanbod,
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
