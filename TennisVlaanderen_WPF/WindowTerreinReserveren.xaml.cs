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
        private ITerreinReservatieRepository terreinReserverenRepository = new TerreinReservatieRepository();
        private IClubRepository clubRepository = new ClubRepository();
        private ISpelerRepository spelerRepository = new SpelerRepository();       

        Speler speler = new Speler();
        TerreinReservatie terreinSelected = new TerreinReservatie();

        public WindowTerreinReserveren()
        {
            InitializeComponent();
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbVeld.SelectedItem != null)
            {
                try
                {
                    terreinSelected = (TerreinReservatie)cbVeld.SelectedItem;
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);
                    foreach (var item in spelersDB)
                    {                       
                            TerreinReservatie terrein = new TerreinReservatie()
                            {
                                Id = terreinSelected.Id,
                                SpelerID = item.Id,
                                TerreinNummer = terreinSelected.TerreinNummer,
                                TypeOndergrond = terreinSelected.TypeOndergrond,
                                TypeTennis = "",
                            };
                        item.TerreinReservatie.Add(terrein);
                        speler = item;
                        spelerRepository.SpelerUpdate(speler);
                        terreinReserverenRepository.TerreinReservatieToevoegen(terrein);                        
                    }
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }

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
            string TypeOndergrond = "Gravel";
            List<TerreinReservatie> veldenDB = (List<TerreinReservatie>)terreinReserverenRepository.OphalenterreinGravel(TypeOndergrond);
            cbVeld.ItemsSource = veldenDB;
            veldImg.Source = new BitmapImage(new Uri("img/tennis-veld-bovenaanzicht-vectorillustratie-162718725.jpg", UriKind.Relative));
        }

        private void RbGras_Checked(object sender, RoutedEventArgs e)
        {
            string TypeOndergrond = "Gras";
            List<TerreinReservatie> veldenDB = (List<TerreinReservatie>)terreinReserverenRepository.OphalenterreinGras(TypeOndergrond);
            cbVeld.ItemsSource = veldenDB;
            veldImg.Source = new BitmapImage(new Uri("img/2634903-vecteur-court-de-tennis-vue-de-dessus-illustration-vectoriel.jpg", UriKind.Relative));
        }
    }
}
