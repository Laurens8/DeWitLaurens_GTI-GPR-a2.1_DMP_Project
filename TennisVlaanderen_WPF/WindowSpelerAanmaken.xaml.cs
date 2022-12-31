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
using TennisVlaanderen_DAL;

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

        private ISpelerRepository spelerRepository = new SpelerRepository();
        Speler Nieuwspeler = new Speler();

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblError.Content = string.Empty;

                if (Nieuwspeler.IsGeldig())
                {
                    if (!string.IsNullOrEmpty(txtGeboortedatum.Text))
                    {
                        Nieuwspeler.GeboorteDatum = DateTime.Parse(txtGeboortedatum.Text);
                    }
                    else
                    {
                        lblError.Content = "Geboortedatum is een verplicht in te vullen veld";
                    }

                    if (rbMan.IsChecked == false && rbVrouw.IsChecked == false)
                    {
                        lblError.Content = "Selecteer een geslacht";

                        if (rbMan.IsChecked == true)
                        {
                            Nieuwspeler.Geslacht = "Man";
                        }
                        else
                        {
                            Nieuwspeler.Geslacht = "Vrouw";
                        }
                    }

                    Nieuwspeler.Naam = txtNaam.Text;
                    Nieuwspeler.Voornaam = txtVoornaam.Text;
                    Nieuwspeler.Klassement = "3";
                    Nieuwspeler.Geslacht = Nieuwspeler.Geslacht;
                    Nieuwspeler.GeboorteDatum = DateTime.Parse(txtGeboortedatum.Text);
                    Nieuwspeler.Nationaliteit = txtNationaliteit.Text;
                    Nieuwspeler.Adres = txtAdres.Text;
                    Nieuwspeler.Land = txtLand.Text;
                    Nieuwspeler.Telefoon = txtTelefoon.Text;
                    Nieuwspeler.Email = txtEmail.Text;
                    Nieuwspeler.RijksNummer = txtRijksNummer.Text;                                                        
                }
                else
                {
                    lblError.Content = Nieuwspeler.Error;
                }

                spelerRepository.SpelerToevoegen(Nieuwspeler);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex) { FileOperations.FoutLoggen(ex); }
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }     
    }
};
