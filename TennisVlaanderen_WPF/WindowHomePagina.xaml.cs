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

        public static int TerreinIdSpeler { get; set; }
        private ISpelerRepository spelerRepository = new SpelerRepository();
        private ISpelerClubTornooiRepository spelerClubTornooiRepository = new SpelerClubTornooiRepository();
        private ITerreinReservatieRepository terreinReserveren = new TerreinReservatieRepository();
        private IAbonnementRepository abonnementRepository = new AbonnementRepository();
        private IClubRepository clubRepository = new ClubRepository();
        List<SpelerClubTornooi> sctlijst = new List<SpelerClubTornooi>();
        List<TerreinReservatie> terreinlijst = new List<TerreinReservatie>();
        List<Abonnement> abonnement = new List<Abonnement>();
        List<Club> clublijst = new List<Club>();
        Speler speler = new Speler();

        private void DataSpeler()
        {
            try
            {
                //Ingelogde speler wordt opgehaald
                List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);

                foreach (var item in spelersDB)
                {
                    //Data van de ingelogde speler wordt opgehaald
                    sctlijst = (List<SpelerClubTornooi>)spelerClubTornooiRepository.OphalenSpelerClubTornooi(item.Id); //sct staat voor spelerClubTornooi
                    terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie(item.Id);
                    abonnement = (List<Abonnement>)abonnementRepository.OphalenSpelerAbonnement(item.Id);
                    clublijst = (List<Club>)clubRepository.OphalenClubSpeler((int)item.ClubID);
                    lblSpeler.Content = item.ToString();
                    speler = item;
                }

                //de labels worden opgevuld met de speler data
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

                foreach (var item in sctlijst)
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
            //Valideerd of de speler is ingechreven in een club
            if (speler.ClubID == 1)
            {
                MessageBox.Show("Schrijf je eerst in bij een club");
            }
            List<SpelerClubTornooi> sctlijst = (List<SpelerClubTornooi>)spelerClubTornooiRepository.OphalenSpelerClubTornooi(speler.Id);
            //Valideerd of de speler is ingechreven in een tornooi
            if (speler.ClubID > 1)
            {
                if (sctlijst.Count() == 0)
                {
                    WindowTornooi tornooi = new WindowTornooi();
                    tornooi.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Je bent al ingeschreven voor een Tornooi!");
                }
            }                                 
        }

        private void BtnClub_Click(object sender, RoutedEventArgs e)
        {
            //Valideerd of de speler is ingechreven in een club
            if (speler.ClubID == 1)
            {
                WindowClub club = new WindowClub();
                club.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("je bent al ingeschreven in een club!");
            }                
        }

        private void BtnLessen_Click(object sender, RoutedEventArgs e)
        {
            //Valideerd of de speler is ingechreven in een club
            if (speler.ClubID == 1)
            {
                MessageBox.Show("Schrijf je eerst in bij een club");
            }
            List<Abonnement> abonnement = (List<Abonnement>)abonnementRepository.OphalenSpelerAbonnement(speler.Id);
            //Valideerd of de speler is ingechreven in een abonnement
            if (speler.ClubID > 1)
            {
                if (abonnement.Count() == 0)
                {
                    WindowLessen lessen = new WindowLessen();
                    lessen.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Je bent al ingeschreven voor lessen en stages!");
                }
            }             
        }

        private void BtnTerrein_Click(object sender, RoutedEventArgs e)
        {
            //Valideerd of de speler is ingechreven in een club
            if (speler.ClubID == 1)
            {
                MessageBox.Show("Schrijf je eerst in bij een club");
            }
            List<TerreinReservatie> terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie(speler.Id);
            //Valideerd of de speler een veld heeft gereserveerd
            if (speler.ClubID > 1)
            {
                if (lblTerrein.Content == "Geen veld gereserveerd" || terreinlijst.Count == 0)
                {
                    WindowTerreinReserveren terrein = new WindowTerreinReserveren();
                    terrein.Show();
                    this.Close();
                }             
                else
                {
                    MessageBox.Show("Je hebt al een veld gereserveerd!");
                }                                             
            }                       
        }

        //Verwijdert de speler account
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

                    //Sluit deze window en opent de MainWindow
                    MainWindow mainWindow= new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }
            }
        }

        //Schrijft speler uit bij de club, en schrijft de speler uit bij lessen en stages, tornooi en annuleert veld reservatie
        private void BtnUitschrijvenClub_Click(object sender, RoutedEventArgs e)
        {       
             if (MessageBox.Show("Ben je zeker dat je u wil uitscrijven bij deze club?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
             {
                try
                {
                    //Uitschrijven club
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
                    foreach (var item in spelersDB)
                    {
                        item.ClubID = 1;
                        spelerRepository.SpelerUpdate(item);
                    }

                    //Uitschrijven lessen en stages
                    List<Abonnement> abonnement = (List<Abonnement>)abonnementRepository.OphalenSpelerAbonnement(speler.Id);
                    foreach (var item in abonnement)
                    {
                        item.SpelerID = 0;
                        abonnementRepository.AbonnementUpdate(item);
                    }

                    //Annuleert veld reservatie
                    List<TerreinReservatie> IdTerrein = (List<TerreinReservatie>)terreinReserveren.OphalenTerreinId(WindowTerreinReserveren.TerreinId);
                    foreach (var item2 in IdTerrein)
                    {
                        List<TerreinReservatie> terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie(speler.Id);
                        foreach (var item in terreinlijst)
                        {
                            item.Id = item2.Id;
                            item.SpelerID = 0;
                            item.TerreinNummer = item2.TerreinNummer;
                            item.TypeOndergrond = item2.TypeOndergrond;
                            item2.TypeTennis = item2.TypeTennis;
                            terreinReserveren.TerreinReservatieDelete(Convert.ToString(item.Id));
                        }
                    }

                    //Uitschrijven tornooi
                    List<SpelerClubTornooi> sctlijst = (List<SpelerClubTornooi>)spelerClubTornooiRepository.OphalenSpelerClubTornooi(speler.Id);
                    foreach (var item in sctlijst)
                    {
                        item.Id = item.Id;
                        item.SpelerID = 0;
                        spelerClubTornooiRepository.SpelerClubTornooiUpdate(item);
                    }

                    //labels worden aangepast
                    lblLessen.Content = "Niet ingeschreven voor lessen of stages";
                    lblClub.Content = "Niet ingeschreven in een club";
                    lblTornooi.Content = "Niet ingeschreven voor een tornooi";
                    lblTerrein.Content = "Geen veld gereserveerd";
                    lblLessen.Content = "Niet ingeschreven voor lessen of stages";

                    WindowHomePagina homePagina = new WindowHomePagina();
                    homePagina.Show();
                    this.Close();
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
                    //Uitschrijven lessen en stages
                    List<Abonnement> abonnement = (List<Abonnement>)abonnementRepository.OphalenSpelerAbonnement(speler.Id);
                     foreach (var item in abonnement)
                     {
                         item.SpelerID = 0;
                         abonnementRepository.AbonnementUpdate(item);
                     }
                    //label worden aangepast
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
                    //Annuleert veld reservatie
                    List<TerreinReservatie> terreinId = (List<TerreinReservatie>)terreinReserveren.OphalenTerreinId(WindowTerreinReserveren.TerreinId); //TerreinId is een property die uit de window TerreinReserveren wordt meegeven
                    foreach (var item2 in terreinId)
                    {
                        List<TerreinReservatie> terreinlijst = (List<TerreinReservatie>)terreinReserveren.OphalenReservatie(speler.Id);
                        foreach (var item in terreinlijst)
                        {
                            item.Id = item2.Id;
                            item.SpelerID = 0;
                            item.TerreinNummer = item2.TerreinNummer;
                            item.TypeOndergrond = item2.TypeOndergrond;
                            item.TypeTennis = item2.TypeTennis;
                            terreinReserveren.TerreinReservatieDelete(Convert.ToString(item.Id));
                        }
                    }
                    //label worden aangepast
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
                    //Uitschrijven tornooi
                    List<SpelerClubTornooi> sctlijst = (List<SpelerClubTornooi>)spelerClubTornooiRepository.OphalenSpelerClubTornooi(speler.Id);
                    foreach (var item in sctlijst)
                    {
                        item.Id = item.Id;
                        item.SpelerID = 0;                       
                        spelerClubTornooiRepository.SpelerClubTornooiUpdate(item);
                    }
                    //label worden aangepast
                    lblTornooi.Content = "Niet ingeschreven voor een tornooi";
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }
            }           
        } 
    }
}
