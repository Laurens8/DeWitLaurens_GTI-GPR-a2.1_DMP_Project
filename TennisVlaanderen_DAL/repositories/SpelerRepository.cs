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
        public List<TennisVlaanderen_Models.Speler> OphalenSpelerEmail()
        {            
            string sql = "SELECT email FROM TennisVlaanderen.Speler";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TennisVlaanderen_Models.Speler>(sql).ToList();
            }
        }

        public List<TennisVlaanderen_Models.Speler> OphalenSpeler()
        {
            string sql = "SELECT * FROM TennisVlaanderen.Speler";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TennisVlaanderen_Models.Speler>(sql).ToList();
            }
        }

        public bool SpelerDelete(string spelerID)
        {
            string sql = @"DELETE FROM TennisVlaanderen.Speler
                           WHERE id = @id";

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

        public bool SpelerToevoegen(TennisVlaanderen_Models.Speler speler)
        {
            string sql = @"INSERT INTO TennisVlaanderen.Speler (id, naam, voornaam, klassement, geslacht, geboorteDatum, nationaliteit, adres, land, telefoon, email, rijksNummer)
                          VALUES (@id, @naam, @voornaam, @klassement, @geslacht, @geboorteDatum, @nationaliteit, @adres, @land, @telefoon, @email, @rijksNummer)";

            var parameter = new
            {
                @id = speler.id,
                @naam = speler.naam,
                @voornaam = speler.voornaam,
                @klassement = speler.klassement,
                @geslacht = speler.geslacht,
                @geboorteDatum = speler.geboorteDatum,
                @nationaliteit = speler.nationaliteit,
                @adres = speler.adres,
                @land = speler.land,
                @telefoon = speler.telefoon,
                @email = speler.email,
                @rijksNummer = speler.rijksNummer,
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

        public bool SpelerUpdate(TennisVlaanderen_Models.Speler speler) 
        {
            string sql = @"UPDATE TennisVlaanderen.Speler naam = @naam,
                        voornaam = @voornaam,
                        klassement = @klassement,
                        geslacht =@geslacht,
                        geboorteDatum = @geboorteDatum, 
                        nationaliteit = @nationaliteit,
                        adres = @adres,
                        land = @land,
                        telefoon = @telefoon,
                        email = @email,
                        rijksNummer = @rijksNummer
                        WHERE id = @id";

            var parameter = new
            {
                @id = speler.id,
                @naam = speler.naam,
                @voornaam = speler.voornaam,
                @klassement = speler.klassement,
                @geslacht = speler.geslacht,
                @geboorteDatum = speler.geboorteDatum,
                @nationaliteit = speler.nationaliteit,
                @adres = speler.adres,
                @land = speler.land,
                @telefoon = speler.telefoon,
                @email = speler.email,
                @rijksNummer = speler.rijksNummer,
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
