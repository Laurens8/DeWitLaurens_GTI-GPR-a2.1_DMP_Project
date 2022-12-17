using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_Models
{
    public class Speler : Basisklasse
    {       
        public int id { get; set; }
        public string naam { get; set; }
        public string voornaam { get; set; }
        public string klassement { get; set; }
        public string geslacht { get; set; }
        public System.DateTime geboorteDatum { get; set; }
        public string nationaliteit { get; set; }
        public string adres { get; set; }
        public string land { get; set; }
        public string telefoon { get; set; }
        public string email { get; set; }
        public string rijksNummer { get; set; }

        public Speler() { }

        public Speler(int id, string naam, string voornaam, string klassement, string geslacht, DateTime geboorteDatum, string nationaliteit, string adres, string land, string telefoon, string email, string rijksNummer)
        {
            this.id = id;
            this.naam = naam;
            this.voornaam = voornaam;
            this.klassement = klassement;
            this.geslacht = geslacht;
            this.geboorteDatum = geboorteDatum;
            this.nationaliteit = nationaliteit;
            this.adres = adres;
            this.land = land;
            this.telefoon = telefoon;
            this.email = email;
            this.rijksNummer = rijksNummer;
        }

        public override string ToString()
        {
            return naam + " " + voornaam + Environment.NewLine + geslacht + Environment.NewLine + geboorteDatum.ToShortDateString() + Environment.NewLine + land + Environment.NewLine + klassement;
        }

        public override int GetHashCode()
        {
            return -434485196 + EqualityComparer<string>.Default.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Speler speler && id == speler.id;                 
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "naam" && string.IsNullOrWhiteSpace(naam))
                {
                    return "Naam is een verplicht in te vullen veld!";
                }

                else if (columnName == "voornaam" && string.IsNullOrWhiteSpace(voornaam))
                {
                    return "Voornaam is een verplicht in te vullen veld!";
                }

                else if (columnName == "geslacht" && string.IsNullOrWhiteSpace(geslacht))
                {
                    return "Geslacht is een verplicht in te vullen veld!";
                }

                else if (columnName == "nationaliteit" && string.IsNullOrWhiteSpace(nationaliteit))
                {
                    return "Nationaliteit is een verplicht in te vullen veld!";
                }

                else if (columnName == "adres" && string.IsNullOrWhiteSpace(adres))
                {
                    return "Adres is een verplicht in te vullen veld!";
                }

                else if (columnName == "land" && string.IsNullOrWhiteSpace(land))
                {
                    return "Land is een verplicht in te vullen veld!";
                }

                else if (columnName == "telefoon" && string.IsNullOrWhiteSpace(telefoon))
                {
                    return "Telefoon is een verplicht in te vullen veld!";
                }

                else if (columnName == "email" && string.IsNullOrWhiteSpace(email))
                {
                    return "Email is een verplicht in te vullen veld!";
                }

                else if (columnName == "rijksNummer" && string.IsNullOrWhiteSpace(rijksNummer))
                {
                    return "RijksNummer is een verplicht in te vullen veld!";
                }

                else if (columnName == "geboorteDatum" && geboorteDatum > DateTime.Now)
                {
                    return "Vul een geldig geboortedatum in!";
                }

                return "";
            }
        }
    }
    }
