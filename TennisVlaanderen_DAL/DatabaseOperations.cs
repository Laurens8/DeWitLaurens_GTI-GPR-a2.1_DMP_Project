using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_DAL
{
    public class DatabaseOperations
    {
        private static DatabaseConnectie _db;

        private static void Start()
        {
            _db = new DatabaseConnectie();
            _db.Open();
        }            

        public static List<TennisVlaanderen_Models.Speler> OphalenSpelers(string naam)
        {
            Start();

            var result = _db.Connectie.Query<TennisVlaanderen_Models.Speler>("SELECT * FROM TennisVlaanderen.Speler;", param: new { naam = naam }).ToList();  
            
            _db.Close();

            return result;
        }       
    }
}
