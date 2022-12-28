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

        private ISpelerRepository spelerItems = new SpelerRepository();
        private ISpelerClubTornooiRepository SCT = new SpelerClubTornooiRepository();
        private ITerreinReservatieRepository terreinReserveren = new TerreinReservatieRepository();
        private IAbonnementRepository abonnementRepository = new AbonnementRepository();
        private IClubRepository clubRepository = new ClubRepository();
        Speler speler = new Speler();

        private void DataSpeler()
        {                               
            List<Speler> spelersDB = spelerItems.OphalenSpeler(speler.Email = MainWindow.Email);
            List<SpelerClubTornooi> sptlijst = new List<SpelerClubTornooi>();
            List<TerreinReservatie> terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie(speler.Id);
            List<Abonnement> abonnement = (List<Abonnement>)abonnementRepository.OphalenSpelerabonnement(speler.Id);

            foreach (var item in spelersDB)
            {
                sptlijst = (List<SpelerClubTornooi>)SCT.OphalenSpelerClubTornooi(item.Id);                     
                terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie(item.Id);
                abonnement = (List<Abonnement>)abonnementRepository.OphalenSpelerabonnement(item.Id);

                speler = item;
                lblSpeler.Content = item.ToString();
                lblClub.Content = item.Naam.ToString();                       
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

        private void BtnTornooi_Click(object sender, RoutedEventArgs e)
        {
            WindowTornooi tornooi= new WindowTornooi();
            tornooi.Show();
            this.Close();
        }

        private void BtnClub_Click(object sender, RoutedEventArgs e)
        {
            WindowClub club = new WindowClub();
            club.Show();
            this.Close();
        }

        private void BtnLessen_Click(object sender, RoutedEventArgs e)
        {
            WindowLessen lessen = new WindowLessen();
            lessen.Show();
            this.Close();
        }

        private void BtnTerrein_Click(object sender, RoutedEventArgs e)
        {
            WindowTerreinReserveren terrein = new WindowTerreinReserveren();
            terrein.Show();
            this.Close();
        }

        private void btnUitschrijvenAccount_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Benje zeker dat je uw account wil verwijderen?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                List<Speler> spelersDB = spelerItems.OphalenSpeler(speler.Email = MainWindow.Email);
                foreach (var item in spelersDB)
                {
                    spelerItems.SpelerDelete(Convert.ToString(speler.Id));
                }              
            }
            DataSpeler();
        }

        private void BtnUitschrijvenClub_Click(object sender, RoutedEventArgs e)
        {       
             if (MessageBox.Show("Ben je zeker dat je u wil uitscrijven mij deze club?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
             {
                List<Speler> spelersDB = spelerItems.OphalenSpeler(speler.Email = MainWindow.Email);
                foreach (var item in spelersDB)
                {
                    clubRepository.ClubDelete(Convert.ToString(speler.ClubID));
                }                  
             }
            DataSpeler();
        }

        private void BtnUitschrijvenLessen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ben je zeker dat je u will uitschrijven voor de lessen en stages?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                List<Abonnement> abonnement = (List<Abonnement>)abonnementRepository.OphalenSpelerabonnement(speler.Id);
                foreach (var item in abonnement)
                {
                    abonnementRepository.AbonnementDelete(Convert.ToString(item.Id));
                }               
            }
            DataSpeler();
        }

        private void BtenUitschrijvenVeld_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Benje zeker dat je uw reservatie wil af zeggen?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                List<TerreinReservatie> terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie(speler.Id);
                foreach (var item in terreinlijst)
                {
                    terreinReserveren.TerreinReservatieDelete(Convert.ToString(item.Id));
                }              
            }
            DataSpeler();
        }

        private void BtnUitschrijvenTornooi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ben je zeker dat je u wil uitschrijven in de tornooi?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {                
                List<SpelerClubTornooi> sptlijst = (List<SpelerClubTornooi>)SCT.OphalenSpelerClubTornooi(speler.Id);
                foreach (var item in sptlijst)
                {
                    SCT.SpelerClubTornooiDelete(Convert.ToString(item.Id));
                    DataSpeler();
                }              
            }           
        } 
    }
}
