using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL
{
    public class FileOperations
    {
        
            public static List<string> WachtwoordLezen()
            {
                List<string> lijst = new List<string>();

                try
                {
                    using (StreamReader reader = new StreamReader("wachtwoord.txt"))
                        while (!reader.EndOfStream)
                        {
                            string record = reader.ReadLine();
                            lijst.Add(record);
                        }                   
                }
                catch (Exception ex)
                {

                    FoutLoggen(ex);
                }
                return lijst;
            }       

        public static void WachtwoordOpslaan(string wachtwoord)
        {
            using (StreamWriter writer = new StreamWriter("wachtwoord.txt", true))
            {             
                writer.WriteLine(wachtwoord);
            }
        }

        public static void FoutLoggen(Exception fout)
        {
            using (StreamWriter writer = new StreamWriter("foutenbestand.txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                writer.WriteLine(fout.GetType().Name);
                writer.WriteLine(fout.Message);
                writer.WriteLine(fout.StackTrace);
                writer.WriteLine(new string('-', 80));
                writer.WriteLine();
            }
        }
    }
}
