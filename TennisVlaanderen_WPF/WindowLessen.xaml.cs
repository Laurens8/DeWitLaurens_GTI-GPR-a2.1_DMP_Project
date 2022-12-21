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
using TennisVlaanderen_Models;

namespace TennisVlaanderen_WPF
{
    /// <summary>
    /// Interaction logic for WindowLessen.xaml
    /// </summary>
    public partial class WindowLessen : Window
    {
        public WindowLessen()
        {
            InitializeComponent();
            OphalenDataLessen();
        }

        private ITarievenRepository tarievenRepository = new TarievenRepository();
        private IClubRepository clubRepository = new ClubRepository();

        private void OphalenDataLessen()
        {
            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTarieven();
            List<Club> clubDB = (List<Club>)clubRepository.OphalenClubNaam();
            List<Tarieven> tarieven = new List<Tarieven>();
            List<Club> club = new List<Club>();
                    
            foreach (var item in clubDB)
            {
                club.Add(item);
            }

            cbAanbod.ItemsSource = tarieven;
            cbClub.ItemsSource = club;
        }

        private void rbTennis_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbPadel_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbTennisPadel_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbTennis_Click(object sender, RoutedEventArgs e)
        {          
            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTarieven();
            List<Tarieven> tarieven = new List<Tarieven>();           
            if (rbTennis.IsChecked == true)
            {
                tarievenDB = tarievenRepository.OphalenTypeTennis();
                foreach (var item in tarievenDB)
                {                  
                    tarieven.Add(item);
                }
            }
            cbAanbod.ItemsSource = tarieven;
        }

        private void rbPadel_Click(object sender, RoutedEventArgs e)
        {
            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTarieven();
            List<Tarieven> tarieven = new List<Tarieven>();
            if (rbTennis.IsChecked == true)
            {
                tarievenDB = tarievenRepository.OphalenTypePadel();
                foreach (var item in tarievenDB)
                {
                    tarieven.Add(item);
                }
            }
            cbAanbod.ItemsSource = tarieven;
        }

        private void rbTennisPadel_Click(object sender, RoutedEventArgs e)
        {
            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTarieven();
            List<Tarieven> tarieven = new List<Tarieven>();
            if (rbTennis.IsChecked == true)
            {
                tarievenDB = tarievenRepository.OphalenTypeTennisPlusPadel();
                foreach (var item in tarievenDB)
                {
                    tarieven.Add(item);
                }
            }
            cbAanbod.ItemsSource = tarieven;
        }
    }
}
