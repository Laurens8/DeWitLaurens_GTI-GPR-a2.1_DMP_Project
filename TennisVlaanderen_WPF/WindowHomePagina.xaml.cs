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
        Speler speler = new Speler();

        private void DataSpeler()
        {                               
            List<Speler> spelersDB = spelerItems.OphalenSpeler(speler.Email = MainWindow.Email);
            List<SpelerClubTornooi> sptlijst = (List<SpelerClubTornooi>)SCT.OphalenSpelerClubTornooi();
            List<TerreinReservatie> terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie();
            List<Abonnement> abonnement= (List<Abonnement>)abonnementRepository.OphalenSpelerabonnement();
            foreach (var item in spelersDB)
            {
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
            List<Speler> spelersDB = spelerItems.OphalenSpeler(speler.Email = MainWindow.Email);
            foreach (var item in spelersDB)
            {
                spelerItems.SpelerDelete(Convert.ToString(item.Id));
            }
        }

        //private void Save(bool isInsert)
        //{
        //    speler.Id = 0;
        //    speler.Naam= null;
        //    speler.Voornaam= null;
        //    speler.Adres= null;
        //    speler.Email= null;
        //    speler.Telefoon= null;
        //    speler.Klassement= null;
        //    speler.GeboorteDatum = DateTime.Now;
        //    speler.Nationaliteit= null;
        //    speler.Geslacht= null;
        //    speler.Land= null;
        //    speler.RijksNummer= null;

        //    if (true)
        //    {

        //    }
        //}
    }
}
