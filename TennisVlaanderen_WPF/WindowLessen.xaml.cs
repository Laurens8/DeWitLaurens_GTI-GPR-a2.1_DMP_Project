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
            List<TennisVlaanderen_Models.Tarieven> tarievenDB = (List<TennisVlaanderen_Models.Tarieven>)tarievenRepository.OphalenTarieven();
            List<TennisVlaanderen_Models.Club> clubDB = (List<TennisVlaanderen_Models.Club>)clubRepository.OphalenClubNaam();
            List<TennisVlaanderen_Models.Tarieven> tarieven = new List<TennisVlaanderen_Models.Tarieven>();
            List<TennisVlaanderen_Models.Club> club = new List<TennisVlaanderen_Models.Club>();
                    
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
            List<TennisVlaanderen_Models.Tarieven> tarievenDB = (List<TennisVlaanderen_Models.Tarieven>)tarievenRepository.OphalenTarieven();
            List<TennisVlaanderen_Models.Tarieven> tarieven = new List<TennisVlaanderen_Models.Tarieven>();           
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
            List<TennisVlaanderen_Models.Tarieven> tarievenDB = (List<TennisVlaanderen_Models.Tarieven>)tarievenRepository.OphalenTarieven();
            List<TennisVlaanderen_Models.Tarieven> tarieven = new List<TennisVlaanderen_Models.Tarieven>();
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
            List<TennisVlaanderen_Models.Tarieven> tarievenDB = (List<TennisVlaanderen_Models.Tarieven>)tarievenRepository.OphalenTarieven();
            List<TennisVlaanderen_Models.Tarieven> tarieven = new List<TennisVlaanderen_Models.Tarieven>();
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
