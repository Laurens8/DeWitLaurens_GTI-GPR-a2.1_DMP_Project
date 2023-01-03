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

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Speler wordt aangemaakt met de value van de input fields
                Speler Nieuwspeler = new Speler();
                DateTime input;

                Nieuwspeler.ClubID = 1;
                Nieuwspeler.Naam = txtNaam.Text;
                Nieuwspeler.Voornaam = txtVoornaam.Text;
                Nieuwspeler.Klassement = "3";
                //Extra validatie met short if. Geslacht veld wordt geselecteerd met de gebruik van radiobuttons
                Nieuwspeler.Geslacht = (rbMan.IsChecked == true) ? Nieuwspeler.Geslacht = "Man" : Nieuwspeler.Geslacht = "Vrouw";
                Nieuwspeler.GeboorteDatum = ((DateTime)(DateTime.TryParse(txtGeboortedatum.Text, out input) ? Nieuwspeler.GeboorteDatum = DateTime.Parse(txtGeboortedatum.Text) : lblError.Content = "Vul een geldig geboortedatum in!" + Environment.NewLine + "(Voorbeeld 01/01/2000)"));
                //******************************
                Nieuwspeler.Nationaliteit = txtNationaliteit.Text;
                Nieuwspeler.Adres = txtAdres.Text;
                Nieuwspeler.Land = txtLand.Text;
                Nieuwspeler.Telefoon = txtTelefoon.Text;
                Nieuwspeler.Email = txtEmail.Text;
                Nieuwspeler.RijksNummer = txtRijksNummer.Text;
                
                //Valideert de input fields met BasisKlassen
                if (Nieuwspeler.IsGeldig())
                {
                    //Valideert of de radiobuttons gecheckt zijn
                    if (rbMan.IsChecked == false && rbVrouw.IsChecked == false)
                    {
                        lblError.Content = "Selecteer een geslacht";
                    }

                    //Valideerd of de opgegeven e-mailadres al is gebruikt
                    bool emailValidatie = false;
                    List<Speler> emailLijst = spelerRepository.OphalenSpelerEmail();
                    for (int i = 0; i < emailLijst.Count(); i++)
                    {
                        if (emailLijst[i].Email == txtEmail.Text)
                        {
                            emailValidatie = true;

                            if (emailValidatie == true)
                            {
                                lblError.Content = "Deze e-mailadres is al ingebruik";
                            }                           
                        }                        
                    }
                    if (emailValidatie == false)
                    {
                        //Opent de window HomePagina en voegt de nieuwspeler toe
                        spelerRepository.SpelerToevoegen(Nieuwspeler);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }                   
                }
                else
                {
                    lblError.Content = Nieuwspeler.Error;
                }
            }
            catch (Exception ex) { FileOperations.FoutLoggen(ex); }
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            //Sluit de window SpelerAanmaken en gaat terug naar de MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }     
    }
};
