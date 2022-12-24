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
        public static string NaamTornooi { get; set; }

        private ITornooiRepository TornooiRepository = new TornooiRepository();

        public WindowTornooi()
        {
            InitializeComponent();
            OphalenData();
        }

        private void OphalenData()
        {
            List<Tornooi> tornooiDB = (List<Tornooi>)TornooiRepository.OphalenTornooi();
            List<Tornooi> circuitDB = (List<Tornooi>)TornooiRepository.OphalenCircuitNaam();
            List<Tornooi> tornooiLijst = new List<Tornooi>();
            List<Tornooi> circuitLijst = new List<Tornooi>();
            Tornooi tornooi = new Tornooi();

            foreach (var item in tornooiDB)
            {               
                //tornooi.NaamTornooi = item.NaamTornooi;
                tornooiLijst.Add(item);
            }
            foreach (var item in circuitDB)
            {                
                //tornooi.Circuit = item.Circuit;
                circuitLijst.Add(item);
            }

            cbTornooi.ItemsSource = tornooiLijst;
            cbCircuit.ItemsSource = circuitLijst;
        }

        private void CbCircuit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string circuitNaam = cbCircuit.SelectedItem.ToString();
            List<Tornooi> circuitDB = (List<Tornooi>)TornooiRepository.OphalenTornooiNaam(circuitNaam);
            cbTornooi.ItemsSource = circuitDB;
        }

        private void CbTornooi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbCircuit.SelectedItem != null && cbTornooi.SelectedItem != null)
            {
                NaamTornooi = cbTornooi.SelectedItem.ToString();
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
