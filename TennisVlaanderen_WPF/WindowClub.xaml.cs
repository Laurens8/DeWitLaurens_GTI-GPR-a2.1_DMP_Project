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
            //OphalenDataLessen();
        }

//        public static string LessenPlusStages { get; set; }      

//        private ITarievenRepository tarievenRepository = new TarievenRepository();
//        private IClubRepository clubRepository = new ClubRepository();

//        private void OphalenDataLessen()
//        {
//            List<Club> clubDB = (List<Club>)clubRepository.OphalenClubNaam();
//            List<Tarieven> tarieven = new List<Tarieven>();
//            List<Club> club = new List<Club>();

//            foreach (var item in clubDB)
//            {
//                club.Add(item);
//            }

//            cbClub.ItemsSource = club;
//        }

//        private void RbTennis_Checked(object sender, RoutedEventArgs e)
//        {

//        }

//        private void RbPadel_Checked(object sender, RoutedEventArgs e)
//        {

//        }

//        private void RbTennisPadel_Checked(object sender, RoutedEventArgs e)
//        {
//        }

//        private void RbTennis_Click(object sender, RoutedEventArgs e)
//        {
//            string clubNaam = cbClub.SelectedItem.ToString().Substring(3, 4); ;
//            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTypeTennis(clubNaam);
//            List<Tarieven> tarieven = new List<Tarieven>();
//            if (rbTennis.IsChecked == true)
//            {
//                cbAanbod.ItemsSource = tarievenDB;
//            }
//        }

//        private void RbPadel_Click(object sender, RoutedEventArgs e)
//        {
//            string clubNaam = cbClub.SelectedItem.ToString().Substring(3, 4); ;
//            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTypePadel(clubNaam);
//            List<Tarieven> tarieven = new List<Tarieven>();
//            if (rbPadel.IsChecked == true)
//            {
//                cbAanbod.ItemsSource = tarievenDB;
//            }
//        }

//        private void RbTennisPadel_Click(object sender, RoutedEventArgs e)
//        {
//            string clubNaam = cbClub.SelectedItem.ToString().Substring(3, 4); ;
//            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTypeTennisPlusPadel(clubNaam);
//            List<Tarieven> tarieven = new List<Tarieven>();
//            if (rbTennisPadel.IsChecked == true)
//            {
//                cbAanbod.ItemsSource = tarievenDB;
//            }
//        }

//        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
//        {
//            LessenPlusStages = cbAanbod.Text.ToString();
//            WindowHomePagina homePagina = new WindowHomePagina();
//            homePagina.Show();
//            this.Close();
//        }

//        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
//        {
//            WindowHomePagina homePagina = new WindowHomePagina();
//            homePagina.Show();
//            this.Close();
//        }
//    }
//}
    }
}
