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
            List<Club> clublijst = new List<Club>();
            List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
            foreach (var item in spelersDB)
            {
                clublijst = (List<Club>)clubRepository.OphalenClubSpeler((int)item.ClubID);
                foreach (var item2 in clublijst)
                {
                    lblClub.Content = item2;
                    string clubNaam = item2.ToString().Substring(3, 5);
                    List<Abonnement> AbonnementDB = (List<Abonnement>)AbonnenmentRepository.OphalenAbonnement(clubNaam);
                    cbAanbod.ItemsSource = AbonnementDB;
                }               
            }
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbAanbod.SelectedItem != null)
            {
                try
                {                   
                    abonnementen = cbAanbod.SelectedItem as Abonnement;
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
                    foreach (var item in spelersDB)
                    {
                        Abonnement abonnement = new Abonnement()
                        {
                            Id = abonnementen.Id,
                            SpelerID = item.Id,
                            ClubID = (int)item.ClubID,
                            Lessen = abonnementen.Lessen,
                            Stages = abonnementen.Stages,
                        };                       
                        item.Abonnement.Add(abonnement);
                        AbonnenmentRepository.AbonnementToevoegen(abonnement);
                    }
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }

                WindowHomePagina homePagina = new WindowHomePagina();
                homePagina.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een club en lessenpakket!");
            }
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }

        private void CbClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
            foreach (var item in spelersDB)
            {               
                string clubNaam = item.Club.ClubNaam;
                List<Abonnement> AbonnementDB = (List<Abonnement>)AbonnenmentRepository.OphalenAbonnement(clubNaam);
                cbAanbod.ItemsSource = AbonnementDB;
            }                                        
        }
    }
}
