using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TennisVlaanderen_DAL
{
    public static class DatabaseConnectie
    {
        public static string Connectionstring(string name)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
            }
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
