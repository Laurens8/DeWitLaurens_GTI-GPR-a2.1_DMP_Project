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
            return this.Naam + " " + this.Voornaam + Environment.NewLine + Geslacht + Environment.NewLine + GeboorteDatum.ToShortDateString() + Environment.NewLine + Land + Environment.NewLine + Klassement;
        }

        public override int GetHashCode()
        {
            return -434485196 + EqualityComparer<string>.Default.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Speler speler && Id == speler.Id;
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam is een verplicht in te vullen veld!";
                }

                else if (columnName == "voornaam" && string.IsNullOrWhiteSpace(Voornaam))
                {
                    return "Voornaam is een verplicht in te vullen veld!";
                }

                else if (columnName == "geslacht" && string.IsNullOrWhiteSpace(Geslacht))
                {
                    return "Geslacht is een verplicht in te vullen veld!";
                }

                else if (columnName == "nationaliteit" && string.IsNullOrWhiteSpace(Nationaliteit))
                {
                    return "Nationaliteit is een verplicht in te vullen veld!";
                }

                else if (columnName == "adres" && string.IsNullOrWhiteSpace(Adres))
                {
                    return "Adres is een verplicht in te vullen veld!";
                }

                else if (columnName == "land" && string.IsNullOrWhiteSpace(Land))
                {
                    return "Land is een verplicht in te vullen veld!";
                }

                else if (columnName == "telefoon" && string.IsNullOrWhiteSpace(Telefoon))
                {
                    return "Telefoon is een verplicht in te vullen veld!";
                }

                else if (columnName == "email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Email is een verplicht in te vullen veld!";
                }

                else if (columnName == "rijksNummer" && string.IsNullOrWhiteSpace(RijksNummer))
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
