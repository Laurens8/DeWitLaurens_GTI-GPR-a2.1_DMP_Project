using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL
{
    public interface IDatabaseConnectie
    {
        void Connecteren();
        IDbConnection Connectie { get; set; }
        void Open();
        void Close();
    }

    public class DatabaseConnectie : IDatabaseConnectie
    {
        public IDbConnection Connectie { get; set; }

        public DatabaseConnectie()
        {
            Connecteren();
        }

        public void Connecteren()
        {
            try
            {
                //Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=Publishers;Integrated Security=True;Pooling=False"].ConnectionString);
                Connectie = new SqlConnection("server=(localdb)\\mssqllocaldb;Database=Publishers;MultipleActiveResultSets=True;");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public void Open()
        {
            if (Connectie == null) Connecteren();

            Connectie.Open();
        }

        public void Close()
        {
            if (Connectie != null)
                Connectie.Close();
        }

    }
}
