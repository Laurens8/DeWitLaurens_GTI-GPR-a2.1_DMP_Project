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

namespace TennisVlaanderen_WPF
{
    /// <summary>
    /// Interaction logic for WindowTornooi.xaml
    /// </summary>
    public partial class WindowTornooi : Window
    {
        private ITornooiRepository TornooiRepository = new TornooiRepository();
        private ISpelerRepository spelerItems = new SpelerRepository();
        private ISpelerClubTornooiRepository SCT = new SpelerClubTornooiRepository();
        Tornooi tornooi = new Tornooi();     
        Speler speler = new Speler();

        public WindowTornooi()
        {
            InitializeComponent();
            OphalenData();
        }

        private void OphalenData()
        {
            List<Tornooi> tornooiDB = (List<Tornooi>)TornooiRepository.OphalenTornooi();
            List<Tornooi> circuitDB = (List<Tornooi>)TornooiRepository.OphalenCircuitNaam();           
            cbTornooi.ItemsSource = tornooiDB;
            cbCircuit.ItemsSource = circuitDB;          
        }

        private void CbCircuit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string circuitNaam = cbCircuit.SelectedItem.ToString();
            List<Tornooi> circuitDB = (List<Tornooi>)TornooiRepository.OphalenTornooiNaam(circuitNaam);
            cbTornooi.ItemsSource = circuitDB;
        }

        private void CbTornooi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
                tornooi = (Tornooi)cbTornooi.SelectedItem;
                lblTornooi.Content = tornooi.NaamTornooi;
                lblCircuit.Content = tornooi.Circuit;
                lblDatum.Content = tornooi.Datum;
                lblTypeCompetitie.Content = tornooi.TypeCompetitie;               
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {           
            if (cbCircuit.SelectedItem != null && cbTornooi.SelectedItem != null)
            {               
                List<Speler> spelersDB = spelerItems.OphalenSpeler(speler.Email = MainWindow.Email);
                foreach (var item in spelersDB)
                {
                    SpelerClubTornooi spt = new SpelerClubTornooi()
                    {
                    ClubID = (int)item.ClubID,
                    SpelerID = item.Id,
                    TornooiID = tornooi.Id,                   
                    };

                    item.SpelerClubTornooi.Add(spt);
                    SCT.SpelerClubTornooiToevoegen(spt);                   
                }               
                WindowHomePagina homePagina = new WindowHomePagina();
                homePagina.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een circuit en tornooi!");
            }
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }
    }
}
