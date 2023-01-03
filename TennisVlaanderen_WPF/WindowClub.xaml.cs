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

        Club nieuwClub = new Club();
        Speler speler = new Speler();

        private ITarievenRepository tarievenRepository = new TarievenRepository();
        private IClubRepository clubRepository = new ClubRepository();
        private ISpelerRepository spelerRepository = new SpelerRepository();

        private void OphalenDataClub()
        {
            //De combobox wordt gevuld met al de clubs in de DB
            List<Club> clubDB = (List<Club>)clubRepository.OphalenClubNaam();            
            cbClub.ItemsSource = clubDB;
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbClub.SelectedItem != null && cbAanbod.SelectedItem != null)
            {
                try
                {
                    //nieuwClub krijgt de geselecteerde item zijn values
                    nieuwClub = (Club)cbClub.SelectedItem;
                    //leeftijdvaliedatie krijgt de geselecteerde item zijn values dit wordt gedaan voor leeftijds validatie
                    Tarieven leeftijdvaliedatie = (Tarieven)cbAanbod.SelectedItem;
                    //De ingelogde speler wordt opgehaald
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);

                    //Speler wordt ingeschreven bij de geselecteerde club
                    foreach (var item in spelersDB)
                    {
                        Club club = new Club()
                        {
                            Id = nieuwClub.Id,
                            ClubNaam = nieuwClub.ClubNaam,
                            Adres = nieuwClub.Adres,
                            Telefoon = nieuwClub.Telefoon,
                            Email = nieuwClub.Email,
                            Website = nieuwClub.Website,
                            KwaliteitLabel = nieuwClub.KwaliteitLabel,
                            Clubaanbod = nieuwClub.Clubaanbod,
                        };
                        item.ClubID = club.Id;
                        spelerRepository.SpelerUpdate(item);

                        //de speler zijn leeftijd wordt gevalideerd zo dat de speler zich niet kan inschrijven bij de verkeerde leeftijdsgroep
                        if (leeftijdvaliedatie.Leeftijdgraad == "jeugd" && speler.GeboorteDatum.Year <= 2005)
                        {
                            MessageBox.Show("de jeugd tarief is aleen maar voor personen onder de 18 jaar");                           
                        }
                        else if (leeftijdvaliedatie.Leeftijdgraad == "senioren" && speler.GeboorteDatum.Year >= 1958)
                        {
                            MessageBox.Show("de senioren tarief is aleen maar voor personen over de 65 jaar");
                        }
                        else 
                        {
                            //Sluit deze window af en opent de window HomePagina
                            WindowHomePagina homePagina = new WindowHomePagina();
                            homePagina.Show();
                            this.Close();
                        }                                             
                    }
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }               
            }
            else
            {
                MessageBox.Show("Selecteer eerst een club en abonnement");
            }            
        }

        //Sluit deze window af en opent de window HomePagina
        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }

        private void CbClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {         
            //De combobox van de club tarieven wordt opgevuld met de geselecteerde club zijn aanbiedingen
            string clubNaam = cbClub.SelectedItem.ToString().Substring(3, 4);
            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTarieven(clubNaam);
            cbAanbod.ItemsSource = tarievenDB;
            nieuwClub = (Club)cbClub.SelectedValue;
            
            //De labels met de geselecteerde club info wordt opgevuld
            lblNaam.Content = nieuwClub.ClubNaam;
            lblAdres.Content = nieuwClub.Adres;
            lblEmail.Content = nieuwClub.Email;
            lblTelefoon.Content = nieuwClub.Telefoon;
            lblWebsite.Content = nieuwClub.Website;
        }
    }
}