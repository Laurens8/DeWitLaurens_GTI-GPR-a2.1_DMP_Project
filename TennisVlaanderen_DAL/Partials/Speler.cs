using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_DAL
{
    public partial class Speler : Basisklasse
    {
        Speler(string email)
        {
            this.Email = email;
        }

        public override string ToString()
        {
            return this.Naam + " " + this.Voornaam + Environment.NewLine + GeboorteDatum.ToShortDateString() + Environment.NewLine + Land + Environment.NewLine + Klassement;
        }

        public override int GetHashCode()
        {
            return -434485196 + EqualityComparer<string>.Default.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Speler speler && Id == speler.Id;
        }

    
        /////////////////////////////////////////////////
        // Dit gedeelte komt uit oefening 4 van canvas //
        /////////////////////////////////////////////////
        public static bool IsNummeriek(string input)
        {
            if (!int.TryParse(input, out int output)) return false;
            return true;
        }

        public static bool IsRijksregisternummerGeldig(string rijksnummer)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rijksnummer) || !IsNummeriek(rijksnummer))
                    return false;

                if (rijksnummer.Length == 11)
                {
                    int rijksnummerlengthe = int.Parse(rijksnummer.Substring(0, 9));
                    int rijksnummerlengthe2 = int.Parse(rijksnummer.Substring(9, 2));
                    if ((97 - (rijksnummerlengthe % 97)) == rijksnummerlengthe2)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return false;
            }
            return false;
        }       
        ///////////////////////////////////////////////////////
     
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "ClubID" &&  ClubID == null)
                {
                    return "";
                }

                if (columnName == "naam" && string.IsNullOrWhiteSpace(Naam) && IsNummeriek(Naam))
                {
                    return "Naam is een verplicht in te vullen veld!";
                }

                else if (columnName == "voornaam" && string.IsNullOrWhiteSpace(Voornaam) && IsNummeriek(Voornaam))
                {
                    return "Voornaam is een verplicht in te vullen veld!";
                }

                else if (columnName == "geslacht" && string.IsNullOrWhiteSpace(Geslacht))
                {
                    return "Geslacht is een verplicht in te vullen veld!";
                }

                else if (columnName == "nationaliteit" && string.IsNullOrWhiteSpace(Nationaliteit) && IsNummeriek(Nationaliteit))
                {
                    return "Nationaliteit is een verplicht in te vullen veld!";
                }

                else if (columnName == "adres" && string.IsNullOrWhiteSpace(Adres))
                {
                    return "Adres is een verplicht in te vullen veld!";
                }

                else if (columnName == "land" && string.IsNullOrWhiteSpace(Land) && IsNummeriek(Land))
                {
                    return "Land is een verplicht in te vullen veld!";
                }

                else if (columnName == "telefoon" && string.IsNullOrWhiteSpace(Telefoon) && !IsNummeriek(Telefoon))
                {
                    return "Telefoon is een verplicht in te vullen veld!";
                }

                else if (columnName == "email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Email is een verplicht in te vullen veld!";
                }

                else if (columnName == "rijksNummer" && string.IsNullOrWhiteSpace(RijksNummer) && !IsRijksregisternummerGeldig(RijksNummer))
                {                   
                    return "RijksNummer is een verplicht in te vullen veld!";
                }

                else if (columnName == "geboorteDatum" && GeboorteDatum > DateTime.Now)
                {
                    return "Vul een geldig geboortedatum in!";
                }

                return "";
            }
        }
    }
}
