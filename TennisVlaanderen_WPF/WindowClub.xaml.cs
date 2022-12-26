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
    /// Interaction logic for WindowClub.xaml
    /// </summary>
    public partial class WindowClub : Window
    {
        public WindowClub()
        {
            InitializeComponent();
            OphalenDataClub();
        }        

        public static string Club { get; set; }
        Club nieuwClub = new Club();

        private ITarievenRepository tarievenRepository = new TarievenRepository();
        private IClubRepository clubRepository = new ClubRepository();

        private void OphalenDataClub()
        {
            List<Club> clubDB = (List<Club>)clubRepository.OphalenClubNaam();            
            cbClub.ItemsSource = clubDB;
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbClub.SelectedItem != null && cbAanbod.SelectedItem != null)
            {
                Club = cbClub.Text.ToString();
                WindowHomePagina homePagina = new WindowHomePagina();
                homePagina.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een club en abonnement");
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
            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTarieven(clubNaam);
            cbAanbod.ItemsSource = tarievenDB;
            nieuwClub = (Club)cbClub.SelectedValue;
            
            lblNaam.Content = nieuwClub.Naam;
            lblAdres.Content = nieuwClub.Adres;
            lblEmail.Content = nieuwClub.Email;
            lblTelefoon.Content = nieuwClub.Telefoon;
            lblWebsite.Content = nieuwClub.Website;
        }
    }
}