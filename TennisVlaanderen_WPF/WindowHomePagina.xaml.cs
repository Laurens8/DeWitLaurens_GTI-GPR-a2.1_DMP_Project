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
    /// Interaction logic for WindowHomePagina.xaml
    /// </summary>
    public partial class WindowHomePagina : Window
    {
        public WindowHomePagina()
        {
            InitializeComponent();
            DataSpeler();
        }       

        private ISpelerRepository spelerRepository = new SpelerRepository();
        private ISpelerClubTornooiRepository spelerClubTornooiRepository = new SpelerClubTornooiRepository();
        private ITerreinReservatieRepository terreinReserveren = new TerreinReservatieRepository();
        private IAbonnementRepository abonnementRepository = new AbonnementRepository();
        private IClubRepository clubRepository = new ClubRepository();
        Speler speler = new Speler();

        private void DataSpeler()
        {
            try
            {
                List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
                List<SpelerClubTornooi> sptlijst = new List<SpelerClubTornooi>();
                List<TerreinReservatie> terreinlijst = new List<TerreinReservatie>();
                List<Abonnement> abonnement = new List<Abonnement>();
                List<Club> clublijst = new List<Club>();

                foreach (var item in spelersDB)
                {
                    sptlijst = (List<SpelerClubTornooi>)spelerClubTornooiRepository.OphalenSpelerClubTornooi(item.Id);
                    terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie(item.Id);
                    abonnement = (List<Abonnement>)abonnementRepository.OphalenSpelerabonnement(item.Id);
                    clublijst = (List<Club>)clubRepository.OphalenClubSpeler((int)item.ClubID);
                    lblSpeler.Content = item.ToString();
                    speler = item;
                }
                foreach (var item in clublijst)
                {
                    if (item.Id == 1)
                    {
                        lblClub.Content = "Niet ingeschreven in een club";
                    }
                    else
                    {
                        lblClub.Content = item;
                    }                   
                }
                foreach (var item in sptlijst)
                {
                    lblTornooi.Content = item;
                }
                foreach (var item in terreinlijst)
                {
                    lblTerrein.Content = item;
                }
                foreach (var item in abonnement)
                {
                    lblLessen.Content = item;
                }
            }
            catch (Exception ex) { FileOperations.FoutLoggen(ex); }
        }

        private void BtnTornooi_Click(object sender, RoutedEventArgs e)
        {
            if (lblTornooi.Content == "Niet ingeschreven voor een tornooi")
            {
                WindowTornooi tornooi = new WindowTornooi();
                tornooi.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("je bent al ingeschreven in een tornooi");
            }
            
        }

        private void BtnClub_Click(object sender, RoutedEventArgs e)
        {
            if (lblClub.Content == "Niet ingeschreven in een club")
            {
                WindowClub club = new WindowClub();
                club.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("je bent al ingeschreven in een club");
            }
                 
        }

        private void BtnLessen_Click(object sender, RoutedEventArgs e)
        {
            if (lblLessen.Content == "Niet ingeschreven voor lessen of stages")
            {
                WindowLessen lessen = new WindowLessen();
                lessen.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Je bent al ingeschreven voor lessen en stages");
            }
                     
        }

        private void BtnTerrein_Click(object sender, RoutedEventArgs e)
        {
            if (lblTerrein.Content == "Geen veld gereserveerd")
            {
                WindowTerreinReserveren terrein = new WindowTerreinReserveren();
                terrein.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Je hebt al een reservatie");
            }
                 
        }

        private void btnUitschrijvenAccount_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ben je zeker dat je uw account wil verwijderen?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
                    foreach (var item in spelersDB)
                    {
                        spelerRepository.SpelerDelete(Convert.ToString(item.Id));
                    }
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Show();
                    this.Close();
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }
            }
        }

        private void BtnUitschrijvenClub_Click(object sender, RoutedEventArgs e)
        {       
             if (MessageBox.Show("Ben je zeker dat je u wil uitscrijven bij deze club?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
             {
                try
                {
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
                    foreach (var item in spelersDB)
                    {
                        item.ClubID = 1;
                        spelerRepository.SpelerUpdate(item);
                    }                    
                    lblClub.Content = "Niet ingeschreven in een club";
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }
             }
        }

        private void BtnUitschrijvenLessen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ben je zeker dat je u will uitschrijven voor de lessen en stages?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    List<Abonnement> abonnement = (List<Abonnement>)abonnementRepository.OphalenSpelerabonnement(speler.Id);
                foreach (var item in abonnement)
                {                   
                    speler.Abonnement.Clear();
                }
                    lblLessen.Content = "Niet ingeschreven voor lessen of stages";

                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }
            }
        }

        private void BtenUitschrijvenVeld_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Benje zeker dat je uw reservatie wil af zeggen?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    List<TerreinReservatie> terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie(speler.Id);                                         
                    foreach (var item in terreinlijst)
                    {
                          terreinReserveren.TerreinReservatieDelete(Convert.ToString(item.Id));
                    }                    
                    lblTerrein.Content = "Geen veld gereserveerd";
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }
            }
        }

        private void BtnUitschrijvenTornooi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ben je zeker dat je u wil uitschrijven in de tornooi?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    List<SpelerClubTornooi> sptlijst = (List<SpelerClubTornooi>)spelerClubTornooiRepository.OphalenSpelerClubTornooi(speler.Id);
                    foreach (var item in sptlijst)
                    {
                        spelerClubTornooiRepository.SpelerClubTornooiDelete(Convert.ToString(item.Id));                                                                          
                    }
                    lblTornooi.Content = "Niet ingeschreven voor een tornooi";
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }
            }           
        } 
    }
}
