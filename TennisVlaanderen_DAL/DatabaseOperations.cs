using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Speler> OphalenSpelers(int spelerID)
        {
            Start();

            var result = _db.Connectie.Query<Speler>("SELECT naam FROM TennisVlaanderen.Speler;", param: new { id = spelerID }).ToList();

            _db.Close();

            return result;
        }       
    }
}
