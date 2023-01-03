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
using TennisVlaanderen_DAL;
using TennisVlaanderen_DAL.interfaces;
using TennisVlaanderen_DAL.repositories;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_WPF
{
    /// <summary>
    /// Interaction logic for WindowLessen.xaml
    /// </summary>
    public partial class WindowLessen : Window
    {
        Speler speler = new Speler();
        Abonnement abonnementen = new Abonnement();

        public WindowLessen()
        {
            InitializeComponent();
            OphalenData();
        }

        private IAbonnementRepository AbonnenmentRepository = new AbonnementRepository();
        private IClubRepository clubRepository = new ClubRepository();
        private ISpelerRepository spelerRepository = new SpelerRepository();     

        private void OphalenData()
        {
            try
            {                
                List<Club> clublijst = new List<Club>();
                //De ingelogde speler wordt opgehaald
                List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
                foreach (var item in spelersDB)
                {
                    //Data can de club wordt opgehaald van waarde speler is ingeschreven 
                    clublijst = (List<Club>)clubRepository.OphalenClubSpeler((int)item.ClubID);
                    foreach (var item2 in clublijst)
                    {
                        //Combobox wordt gevuld met de (lessen en stages) die de ingeschreven club aanbied
                        lblClub.Content = item2;
                        string clubNaam = item2.ToString().Substring(3, 5);
                        List<Abonnement> AbonnementDB = (List<Abonnement>)AbonnenmentRepository.OphalenAbonnement(clubNaam);
                        cbAanbod.ItemsSource = AbonnementDB;
                    }
                }
            }
            catch (Exception ex) { FileOperations.FoutLoggen(ex); }
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            //Valideert of de speler een item geselecteerd heeft uit de combobox
            if (cbAanbod.SelectedItem != null)
            {
                try
                {                 
                    //abonnement krijgt de geselecteerde item zijn values
                    abonnementen = cbAanbod.SelectedItem as Abonnement;
                    //De ingelogde speler wordt opgehaald
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
                    //De speler wordt ingeschreven voor de geselecteerde lessen en stages
                    foreach (var item in spelersDB)
                    {
                        abonnementen.SpelerID = item.Id;                    
                        AbonnenmentRepository.AbonnementUpdate(abonnementen);
                    }
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }

                //Sluit deze window af en opent de window HomePagina
                WindowHomePagina homePagina = new WindowHomePagina();
                homePagina.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een club en lessenpakket!");
            }
        }

        //Sluit deze window af en opent de window HomePagina
        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }
    }
}
