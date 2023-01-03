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
    /// Interaction logic for WindowTerreinReserveren.xaml
    /// </summary>
    public partial class WindowTerreinReserveren : Window
    {
        //TerreinId property geeft de geselecteerde item zijn id mee voor de window HomePagina zo dat de speler zijn reservatie afzegt de correcte id verwijdert wordt  
        public static int TerreinId { get; set; }

        private ITerreinReservatieRepository terreinReserverenRepository = new TerreinReservatieRepository();
        private IClubRepository clubRepository = new ClubRepository();
        private ISpelerRepository spelerRepository = new SpelerRepository();       

        Speler speler = new Speler();
        TerreinReservatie terreinSelected = new TerreinReservatie();

        public WindowTerreinReserveren()
        {
            InitializeComponent();
        }

        //Sluit deze window af en opent HomePagina
        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            //Validatie of de speler een item geselecteerd heeft in de combobox
            if (cbVeld.SelectedItem != null)
            {
                try
                {
                    //terreinSelected krijgt de selected item values mee
                    terreinSelected = (TerreinReservatie)cbVeld.SelectedItem;
                    //Geeft de property TerreinId de correcte item id voor de window HomePagina
                    TerreinId = terreinSelected.Id;

                    //Haalt de speler op die ingelogt is
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);    
                    //Speler veld reservatie wordt geupdate
                    foreach (var item in spelersDB)
                    {                                              
                        terreinSelected.Id = terreinSelected.Id;
                        terreinSelected.SpelerID = item.Id;
                        terreinSelected.TerreinNummer = terreinSelected.TerreinNummer;
                        terreinSelected.TypeOndergrond = terreinSelected.TypeOndergrond;
                        terreinSelected.TypeTennis = terreinSelected.TypeTennis;
                        terreinReserverenRepository.TerreinReservatieToevoegen(terreinSelected);
                    }

                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }

                //sluit deze window af en opent window HomePagina
                WindowHomePagina homePagina = new WindowHomePagina();
                homePagina.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een veld!");
            }
        }

        private void RbGravel_Checked(object sender, RoutedEventArgs e)
        {
            //filtert de combobox met de geselecteerde radiobutton
            string TypeOndergrond = "Gravel";
            List<TerreinReservatie> veldenDB = (List<TerreinReservatie>)terreinReserverenRepository.OphalenterreinGravel(TypeOndergrond);
            cbVeld.ItemsSource = veldenDB;
            //Verandert de image van de soort veld geselecteerd is
            veldImg.Source = new BitmapImage(new Uri("img/tennis-veld-bovenaanzicht-vectorillustratie-162718725.jpg", UriKind.Relative));
        }

        private void RbGras_Checked(object sender, RoutedEventArgs e)
        {
            //filtert de combobox met de geselecteerde radiobutton
            string TypeOndergrond = "Gras";
            List<TerreinReservatie> veldenDB = (List<TerreinReservatie>)terreinReserverenRepository.OphalenterreinGras(TypeOndergrond);
            cbVeld.ItemsSource = veldenDB;
            //Verandert de image van de soort veld geselecteerd is
            veldImg.Source = new BitmapImage(new Uri("img/2634903-vecteur-court-de-tennis-vue-de-dessus-illustration-vectoriel.jpg", UriKind.Relative));
        }
    }
}
