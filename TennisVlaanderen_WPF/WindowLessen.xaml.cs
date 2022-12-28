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

        public WindowLessen()
        {
            InitializeComponent();
            OphalenDataClub();
        }

        private IAbonnementRepository AbonnenmentRepository = new AbonnementRepository();
        private IClubRepository clubRepository = new ClubRepository();
        private ISpelerRepository spelerItems = new SpelerRepository();

        private void OphalenDataClub()
        {
            List<Club> clubDB = (List<Club>)clubRepository.OphalenClubNaam();
            cbClub.ItemsSource = clubDB;
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbClub.SelectedItem != null && cbAanbod.SelectedItem != null)
            {
                List<Speler> spelersDB = spelerItems.OphalenSpeler(speler.Email = MainWindow.Email);
                speler.Abonnement = (ICollection<Abonnement>)cbAanbod.SelectedItem;
                spelerItems.SpelerUpdate(speler);
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
                string clubNaam = cbClub.SelectedItem.ToString().Substring(3, 4);
                List<Abonnement> AbonnementDB = (List<Abonnement>)AbonnenmentRepository.OphalenAbonnement(clubNaam);
                cbAanbod.ItemsSource = AbonnementDB;          
        }
    }
}
