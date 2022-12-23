using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TennisVlaanderen_DAL.interfaces;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_DAL.repositories
{
    public class SpelerRepository : BaseRepository, ISpelerRepository
    {        
        public List<Speler> OphalenSpelerEmail()
        {            
            string sql = "SELECT Email FROM TennisVlaanderen.Speler";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Speler>(sql).ToList();
            }
        }

        public List<Speler> OphalenSpeler(string email)
        {
            string sql = $"SELECT * FROM TennisVlaanderen.Speler S WHERE S.Email LIKE '%{email}%'";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Speler>(sql).ToList();
            }
        }

        public bool SpelerDelete(string spelerID)
        {
            string sql = @"DELETE FROM TennisVlaanderen.Speler
                           WHERE Id = @Id";

            var parameter = new
            {
                SpelerID = spelerID
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

        public bool SpelerToevoegen(Speler speler)
        {
            string sql = @"INSERT INTO TennisVlaanderen.Speler (Naam, Voornaam, Klassement, Geslacht, GeboorteDatum, Nationaliteit, Adres, Land, Telefoon, Email, RijksNummer)
                          VALUES (@Naam, @Voornaam, @Klassement, @Geslacht, @GeboorteDatum, @Nationaliteit, @Adres, @Land, @Telefoon, @Email, @RijksNummer)";

            var parameter = new
            {
                @Naam = speler.Naam,
                @Voornaam = speler.Voornaam,
                @Klassement = speler.Klassement,
                @Geslacht = speler.Geslacht,
                @GeboorteDatum = speler.GeboorteDatum,
                @Nationaliteit = speler.Nationaliteit,
                @Adres = speler.Adres,
                @Land = speler.Land,
                @Telefoon = speler.Telefoon,
                @Email = speler.Email,
                @RijksNummer = speler.RijksNummer,
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

        public bool SpelerUpdate(Speler speler) 
        {
            string sql = @"UPDATE TennisVlaanderen.Speler Naam = @Naam,
                        Voornaam = @Voornaam,
                        Klassement = @Klassement,
                        Geslacht =@Geslacht,
                        GeboorteDatum = @GeboorteDatum, 
                        Nationaliteit = @Nationaliteit,
                        Adres = @Adres,
                        Land = @Land,
                        Telefoon = @Telefoon,
                        Email = @Email,
                        RijksNummer = @RijksNummer
                        WHERE Id = @Id";

            var parameter = new
            {
                @Id = speler.Id,
                @Naam = speler.Naam,
                @Voornaam = speler.Voornaam,
                @Klassement = speler.Klassement,
                @Geslacht = speler.Geslacht,
                @GeboorteDatum = speler.GeboorteDatum,
                @Nationaliteit = speler.Nationaliteit,
                @Adres = speler.Adres,
                @Land = speler.Land,
                @Telefoon = speler.Telefoon,
                @Email = speler.Email,
                @RijksNummer = speler.RijksNummer,
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
