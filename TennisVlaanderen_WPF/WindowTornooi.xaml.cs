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
        private ISpelerRepository spelerRepository = new SpelerRepository();
        private ISpelerClubTornooiRepository spelerClubTornooiRepository = new SpelerClubTornooiRepository();
        Tornooi tornooi = new Tornooi();     
        Speler speler = new Speler();

        public WindowTornooi()
        {
            InitializeComponent();
            OphalenData();
        }

        private void OphalenData()
        {
            //Haalt de data op van de DB en vult de combobox met items
            List<Tornooi> tornooiDB = (List<Tornooi>)TornooiRepository.OphalenTornooi();
            List<Tornooi> circuitDB = (List<Tornooi>)TornooiRepository.OphalenCircuitNaam();            
            cbTornooi.ItemsSource = tornooiDB;
            cbCircuit.ItemsSource = circuitDB;          
        }

        private void CbCircuit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Filter de tornooi combobox met de circuit dat de speler zich wilt bij inschrijven
            string circuitNaam = cbCircuit.SelectedItem.ToString();
            List<Tornooi> circuitDB = (List<Tornooi>)TornooiRepository.OphalenTornooiNaam(circuitNaam);
            cbTornooi.ItemsSource = circuitDB;           
        }

        private void CbTornooi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Vult de labels met de geselecteerde tornooi info
            if (cbTornooi.SelectedItem is Tornooi)
            {
                tornooi = (Tornooi)cbTornooi.SelectedItem;
                lblTornooi.Content = tornooi.NaamTornooi;
                lblCircuit.Content = tornooi.Circuit;
                lblDatum.Content = tornooi.Datum;
                lblTypeCompetitie.Content = tornooi.TypeCompetitie;
            }
            else
            {
                //Heb ik er bij moeten zetten zo dat als de circuit combobox item verandert geen "Null exception object not found" veroorzaakt
                tornooi = null;
                lblTornooi.Content = "";
                lblCircuit.Content = "";
                lblDatum.Content = "";
                lblTypeCompetitie.Content = "";
            }
            
        }

        //Update de tornooi waar de speler is ingeschreven
        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            //Valideert of de speler een item geselecteerd heeft uit beiden comboboxen
            if (cbCircuit.SelectedItem != null && cbTornooi.SelectedItem != null)
            {
                try
                {            
                    //tornooi krijgt de geselecteerde item id mee
                    tornooi = cbTornooi.SelectedItem as Tornooi;
                    //Speler wordt op gehaald via de MainWindow property Eamil
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
                    foreach (var item in spelersDB)
                    {
                        //Tornooi id wordt opgehaald via query
                        List<SpelerClubTornooi> spelerClubTornooiDB = (List<SpelerClubTornooi>)spelerClubTornooiRepository.OphalenTornooi(tornooi.Id);
                        
                        //Speler wordt ingeschreven bij de geslecteerde tornooi
                        foreach (var tornooiId in spelerClubTornooiDB)
                        {
                            SpelerClubTornooi nieuwSpelerClubTornooi = new SpelerClubTornooi()
                            {
                                Id = tornooiId.Id,
                                ClubID = 1,
                                SpelerID = item.Id,
                                TornooiID = tornooi.Id,
                            };
                            spelerClubTornooiRepository.SpelerClubTornooiUpdate(nieuwSpelerClubTornooi);
                        }                                              
                    }
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }

                //Opent de window HomePagina en sluit deze window af
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
            //Sluit window Lessen af en opent de window HomePagina
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }
    }
}
