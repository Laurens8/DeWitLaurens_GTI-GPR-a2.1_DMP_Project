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

        public bool EmailValidatie(string email)
        {
            if (Email.Contains('@') && Email.Contains('.')) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        /////////////////////////////////////////////////
        // Dit gedeelte komt uit oefening 4 van canvas //
        /////////////////////////////////////////////////
        public static bool IsNummeriek(string input)
        {
            if (!int.TryParse(input, out int output)) return false;
            return true;
        }

        public static bool RijksregisternummerIsGeldig(string rijksnummer)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rijksnummer) || !IsNummeriek(rijksnummer))
                    return false;

                if (rijksnummer.Length == 11)
                {
                    int rijksnummers = int.Parse(rijksnummer.Substring(0, 9));
                    int rijksnummers2 = int.Parse(rijksnummer.Substring(9, 2));
                    if ((97 - (rijksnummers % 97)) == rijksnummers2)
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
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam) && IsNummeriek(Naam))
                {
                    return "Naam is een verplicht in te vullen veld!";
                }

                else if (columnName == "Naam" && IsNummeriek(Naam))
                {
                    return "Naam mag niet nummeriek zijn!";
                }

                else if (columnName == "Voornaam" && string.IsNullOrWhiteSpace(Voornaam) && IsNummeriek(Voornaam))
                {
                    return "Voornaam is een verplicht in te vullen veld!";
                }

                else if (columnName == "Voornaam" && IsNummeriek(Voornaam))
                {
                    return "Voornaam mag niet nummeriek zijn!";
                }

                else if (columnName == "Geslacht" && string.IsNullOrWhiteSpace(Geslacht) && IsNummeriek(Geslacht))
                {
                    return "Geslacht is een verplicht in te vullen veld!";
                }

                else if (columnName == "Geslacht" && IsNummeriek(Geslacht))
                {
                    return "Geslacht mag niet nummeriek zijn!";
                }

                else if (columnName == "Nationaliteit" && string.IsNullOrWhiteSpace(Nationaliteit) && IsNummeriek(Nationaliteit))
                {
                    return "Nationaliteit is een verplicht in te vullen veld!";
                }

                else if (columnName == "Nationaliteit" && IsNummeriek(Nationaliteit))
                {
                    return "Nationaliteit mag niet nummeriek zijn!";
                }

                else if (columnName == "Adres" && string.IsNullOrWhiteSpace(Adres))
                {
                    return "Adres is een verplicht in te vullen veld!";
                }

                else if (columnName == "Land" && string.IsNullOrWhiteSpace(Land) && IsNummeriek(Land))
                {
                    return "Land is een verplicht in te vullen veld!";
                }

                else if (columnName == "Land" && IsNummeriek(Land))
                {
                    return "Land mag niet nummeriek zijn!";
                }

                else if (columnName == "Telefoon" && string.IsNullOrWhiteSpace(Telefoon) && !IsNummeriek(Telefoon))
                {
                    return "Telefoon is een verplicht in te vullen veld!";
                }

                else if (columnName == "Telefoon" && !IsNummeriek(Telefoon))
                {
                    return "Telefoon nummer moet nummeriek zijn!";
                }

                else if (columnName == "Email" && string.IsNullOrWhiteSpace(Email) && EmailValidatie(Email))
                {
                    return "Email is een verplicht in te vullen veld!";
                }

                else if (columnName == "Email" && EmailValidatie(Email))
                {
                    return "Emailaddres moet een '@' en '.' bevatten";
                }

                else if (columnName == "RijksNummer" && string.IsNullOrWhiteSpace(RijksNummer) && RijksregisternummerIsGeldig(RijksNummer))
                {                   
                    return "RijksNummer is een verplicht in te vullen veld!";
                }

                else if (columnName == "RijksNummer" &&  RijksregisternummerIsGeldig(RijksNummer))
                {
                    return "RijksNummer moet 11 nummers bevatten";
                }

                else if (columnName == "GeboorteDatum" && GeboorteDatum > DateTime.Now)
                {
                    return "Vul een geldig geboortedatum in!";
                }

                return "";
            }
        }
    }
}
