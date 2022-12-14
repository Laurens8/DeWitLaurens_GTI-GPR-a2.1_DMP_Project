using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TennisVlaanderen_DAL.interfaces;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_DAL.repositories
{
    public class SpelerRepository : BaseRepository, ISpelerRepository
    {        
        public List<TennisVlaanderen_Models.Speler> OphalenSpeler()
        {            
            string sql = "SELECT email FROM TennisVlaanderen.Speler";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TennisVlaanderen_Models.Speler>(sql).ToList();
            }
        }              
    }
}
