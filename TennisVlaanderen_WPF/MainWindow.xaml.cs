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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TennisVlaanderen_DAL;
using TennisVlaanderen_DAL.interfaces;
using TennisVlaanderen_DAL.repositories;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }       

        private ISpelerRepository SpelerRepository = new SpelerRepository();
        private IClubRepository ClubRepository = new ClubRepository();
        private IAbonnementRepository AbonnementRepository = new AbonnementRepository();
        private ITornooiRepository tornooiRepository = new TornooiRepository();
        private ISpelerClubTornooiRepository SpelerClubTornooiRepository = new SpelerClubTornooiRepository();
        private ITarievenRepository tarievenRepository = new TarievenRepository();
        private ITerreinReservatieRepository terreinReservatieRepository = new TerreinReservatieRepository();

        private void BtnAccountMaken_Click(object sender, RoutedEventArgs e)
        {
           WindowSpelerAanmaken window = new WindowSpelerAanmaken();
           window.Show();
           this.Close();
        }

        private void BtnDoorgaan_Click(object sender, RoutedEventArgs e)
        {
            List<TennisVlaanderen_Models.Speler> spelersDB = SpelerRepository.OphalenSpeler();
            List<TennisVlaanderen_Models.Speler> speler = new List<TennisVlaanderen_Models.Speler>();
            WindowSpelerAanmaken wachtwoord = new WindowSpelerAanmaken();
            wachtwoord.WachtwoordValidatie();
            bool emailValidatie = false;

            foreach (var item in spelersDB)
            {
                speler.Add(item);
            }

            for (int i = 0; i < speler.Count(); i++)
            {
                if (speler[i].email != txtEmail.Text)
                {
                    emailValidatie = false;
                }
                else
                {
                    emailValidatie = true;
                }
            }

            if (emailValidatie == false)
            {
                MessageBox.Show("Deze email address is incorrect");
            }           
            
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Email address is een verplicht veld");
            }       

            if (txtWachtwoord.Text == string.Empty)
            {
                MessageBox.Show("Wachtwoord is een verplicht veld");
            }

            if (!wachtwoord.WachtwoordValidatie().Contains(txtWachtwoord.Text))
            {
                MessageBox.Show("Wachtwoord is incorrect");
            }

            if (txtEmail.Text != string.Empty && emailValidatie == true && wachtwoord.WachtwoordValidatie().Contains(txtWachtwoord.Text))
            {
                WindowHomePagina homePagina = new WindowHomePagina();
                homePagina.Show();
            }
        }
    }
}
