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
            return "Naam: " + " " + this.Naam + " " + this.Voornaam + Environment.NewLine + "Geboortedatum: " + " " + GeboorteDatum.ToShortDateString() + Environment.NewLine + "Land: " + " " + Land + Environment.NewLine + "Adres: " + " " + Adres + Environment.NewLine + "Telefoonnummer: " + " "  + Telefoon + Environment.NewLine + "E-mailadres: " + " "  + Email;
        }

        public override bool Equals(object obj)
        {
            return obj is Speler speler && Email == speler.Email;
        }

        //Valideerd of de ingegeven emailadres gedig is
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

        //Valideerd of de ingegeven telefoonnummer gedig is
        private static bool TelefoonValidatie(string input)
        {
            if (input.Length == 10)
            {
                return true;
            }
            return false;
        }

        //Valideerd of de ingegeven veld een nummer is
        public static bool IsNummeriek(string input)
        {
            if (!int.TryParse(input, out int output)) return false;
            return true;
        }

        //Valideerd of de ingegeven rijksnummer geldig is
        public static bool RijksregisternummerIsGeldig(string rijksnummer)
        {
            try
            {
                if (rijksnummer.Length == 15)
                {
                    string punt1 = rijksnummer.Substring(2, 1);
                    string punt2 = rijksnummer.Substring(5, 1);
                    string streep = rijksnummer.Substring(8, 1);
                    string punt3 = rijksnummer.Substring(11, 1);
                    if (punt1 == "." && punt2 == "." && streep == "-" && punt3 == ".")
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
     
        //Validatie voor een speler aan te maken in de window SpelerAanmaken
        public override string this[string columnName]
        {
            get
            {               
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam is verplicht in te vullen!" + Environment.NewLine;
                }

                else if (columnName == "Naam" && IsNummeriek(Naam) == true)
                {
                    return "Naam mag niet nummeriek zijn!" + Environment.NewLine;
                }

                else if (columnName == "Voornaam" && string.IsNullOrWhiteSpace(Voornaam))
                {
                    return "Voornaam is verplicht in te vullen!" + Environment.NewLine;
                }

                else if (columnName == "Voornaam" && IsNummeriek(Voornaam) == true)
                {
                    return "Voornaam mag niet nummeriek zijn!" + Environment.NewLine;
                }

                else if (columnName == "Geslacht" && string.IsNullOrWhiteSpace(Geslacht))
                {
                    return "Geslacht is verplicht in te vullen!" + Environment.NewLine;
                }

                else if (columnName == "Geslacht" && IsNummeriek(Geslacht) == true)
                {
                    return "Geslacht mag niet nummeriek zijn!" + Environment.NewLine;
                }

                else if (columnName == "Nationaliteit" && string.IsNullOrWhiteSpace(Nationaliteit))
                {
                    return "Nationaliteit is verplicht in te vullen!" + Environment.NewLine;
                }

                else if (columnName == "Nationaliteit" && IsNummeriek(Nationaliteit) == true)
                {
                    return "Nationaliteit mag niet nummeriek zijn!" + Environment.NewLine;
                }

                else if (columnName == "Adres" && string.IsNullOrWhiteSpace(Adres))
                {
                    return "Adres is verplicht in te vullen!" + Environment.NewLine;
                }

                else if (columnName == "Land" && string.IsNullOrWhiteSpace(Land))
                {
                    return "Land is verplicht in te vullen!" + Environment.NewLine;
                }

                else if (columnName == "Land" && IsNummeriek(Land) == true)
                {
                    return "Land mag niet nummeriek zijn!" + Environment.NewLine;
                }

                else if (columnName == "Telefoon" && string.IsNullOrWhiteSpace(Telefoon))
                {
                    return "Telefoonnummer is verplicht in te vullen!" + Environment.NewLine;
                }

                else if (columnName == "Telefoon" && IsNummeriek(Telefoon) == false)
                {
                    return "Telefoonnummer moet nummeriek zijn!" + Environment.NewLine;
                }

                else if (columnName == "Telefoon" && TelefoonValidatie(Telefoon) == false)
                {
                    return "Telefoonnummer moet 10 nummers bevatten!" + Environment.NewLine;
                }

                else if (columnName == "Email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Email is verplicht in te vullen!" + Environment.NewLine;
                }

                else if (columnName == "Email" && EmailValidatie(Email) == false)
                {
                    return "Emailaddres moet een '@' en '.' bevatten!" + Environment.NewLine;
                }

                else if (columnName == "RijksNummer" && string.IsNullOrWhiteSpace(RijksNummer))
                {
                    return "RijksNummer is verplicht in te vullen!" + Environment.NewLine;
                }

                else if (columnName == "RijksNummer" && RijksregisternummerIsGeldig(RijksNummer) == false)
                {
                    return "RijksNummer moet 11 nummers bevatten!" + Environment.NewLine +
                           "(Voorbeeld 01.01.01-01.001)" + Environment.NewLine;
                }

                else if (columnName == "GeboorteDatum" && GeboorteDatum.Year >= 2018)
                {
                    return "Speler moet ouder zijn dan 5 jaar!" + Environment.NewLine;                          
                }

                return "";
            }
        }
    }
}
