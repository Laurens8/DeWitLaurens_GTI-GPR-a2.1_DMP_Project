using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TennisVlaanderen_DAL.interfaces;
using TennisVlaanderen_DAL.repositories;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_WPF
{
    /// <summary>
    /// Interaction logic for WindowSpelerAanmaken.xaml
    /// </summary>
    public partial class WindowSpelerAanmaken : Window
    {
        public WindowSpelerAanmaken()
        {
            InitializeComponent();
        }

        Speler nieuwSpeler = new Speler();

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            
            List<Speler> spelers = new List<Speler>();         

            if (nieuwSpeler.IsGeldig())
            {
                nieuwSpeler.naam = txtNaam.Text;
                nieuwSpeler.voornaam = txtVoornaam.Text;

                if (!string.IsNullOrEmpty(txtGeboortedatum.Text))
                {
                    nieuwSpeler.geboorteDatum = DateTime.Parse(txtGeboortedatum.Text);
                }
                else
                {
                    lblError.Content = "Geboortedatum is een verplicht in te vullen veld";
                }

                nieuwSpeler.email = txtEmail.Text;
                nieuwSpeler.adres = txtAdres.Text;
                nieuwSpeler.land = txtLand.Text;
                nieuwSpeler.nationaliteit = txtNationaliteit.Text;
                nieuwSpeler.telefoon = txtTelefoon.Text;
                nieuwSpeler.rijksNummer = txtRijksNummer.Text;
                lblError.Content = string.Empty;
                Toevoegen(true);
            }
            else
            {
                lblError.Content = nieuwSpeler.Error;
            }                    
                    
            if (rbMan.IsChecked == false && rbVrouw.IsChecked == false)
            {
                lblError.Content = "Selecteer een geslacht";

                if (rbMan.IsChecked == true)
                {
                    nieuwSpeler.geslacht = "Man";
                }
                else
                {
                    nieuwSpeler.geslacht = "Vrouw";
                }
            }

            spelers.Add(nieuwSpeler);
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public List<string> WachtwoordValidatie()
        {
            List<string> wachtwoordenLijst = new List<string>();

            if (!string.IsNullOrWhiteSpace(txtWachtwoord.Text))
            {
                string wachtwoordtext = txtWachtwoord.Text.ToLower();
                wachtwoordenLijst.Add(wachtwoordtext);
            }
            else
            {
                lblError.Content = "Wachtwoord is een verplichte veld!";
            }
             
            return wachtwoordenLijst;
        }

        private void RbVrouw_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbMan_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Toevoegen(bool isToevoeg)
        {
            ISpelerRepository SpelerRepository = new SpelerRepository();

            if (rbMan.IsChecked == true)
            {
                nieuwSpeler.geslacht = "Man";
            }
            else
            {
                nieuwSpeler.geslacht = "Vrouw";
            }

            Speler speler = new Speler()
            {
                id = 21,
                naam = txtNaam.Text,
                voornaam = txtVoornaam.Text,
                klassement = "3",
                geslacht = nieuwSpeler.geslacht,
                geboorteDatum = DateTime.Parse(txtGeboortedatum.Text),
                nationaliteit = txtNationaliteit.Text,
                adres = txtAdres.Text,
                land = txtLand.Text,
                telefoon = txtTelefoon.Text,
                email = txtEmail.Text,
                rijksNummer = txtRijksNummer.Text
            };

            if (isToevoeg)
            {
                SpelerRepository.SpelerToevoegen(speler);
            }
            //else kan ik beter een button voorzien bij homepage ???
            //{
            //    SpelerRepository.SpelerUpdate(speler);
            //}
        }      
    };
}
