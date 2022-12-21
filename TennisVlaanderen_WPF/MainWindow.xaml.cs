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
        
        private void BtnAccountMaken_Click(object sender, RoutedEventArgs e)
        {
           WindowSpelerAanmaken window = new WindowSpelerAanmaken();
           window.Show();
           this.Close();
        }

        private void BtnDoorgaan_Click(object sender, RoutedEventArgs e)
        {
            List<Speler> spelersDB = SpelerRepository.OphalenSpelerEmail();
            List<Speler> speler = new List<Speler>();          
            bool emailValidatie = false;
            lblError.Content = string.Empty;

            foreach (var item in spelersDB)
            {
                speler.Add(item);
            }

            for (int i = 0; i < speler.Count(); i++)
            {
                if (speler[i].Email != txtEmail.Text)
                {
                    emailValidatie = false;
                }
                else
                {
                    emailValidatie = true;
                }
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblError.Content = "Email address is een verplicht veld!";                                       
            }
            else if (emailValidatie == false)
            {
                lblError.Content = "Deze email address is incorrect!";
            }
                               
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && emailValidatie == true || txtEmail.Text == "olivia@email.be")
            {
                WindowHomePagina homePagina = new WindowHomePagina();
                homePagina.Show();
                this.Close();
            }
        }
    }
}
