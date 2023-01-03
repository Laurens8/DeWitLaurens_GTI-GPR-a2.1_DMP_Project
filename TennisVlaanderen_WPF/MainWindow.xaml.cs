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
        //Property om de speler zijn gegevens te kunnen meegeven aan de andere windows
        public static string Email { get; set;}     
        
        public MainWindow()
        {               
        InitializeComponent();
        }      

        private ISpelerRepository SpelerRepository = new SpelerRepository();
        
        //Opent de window SpelerAanmaken
        private void BtnAccountMaken_Click(object sender, RoutedEventArgs e)
        {
           WindowSpelerAanmaken window = new WindowSpelerAanmaken();
           window.Show();
           this.Close();
        }

        //Opent de window HomePagina
        private void BtnDoorgaan_Click(object sender, RoutedEventArgs e)
        {           
            List<Speler> spelersDB = SpelerRepository.OphalenSpelerEmail();            
            lblError.Content = string.Empty;
            bool emailValidatie = false;
           
            //Validatie of de emailadres correct is, en dat de emailadres bestaat in de DB
            for (int i = 0; i < spelersDB.Count(); i++)
            {               
                if (spelersDB[i].Email != txtEmail.Text)
                {
                    emailValidatie = false;

                    if (emailValidatie == false)
                    {
                        lblError.Content = "Deze email address is incorrect of bestaat niet!";
                    }
                }
                else
                {
                    emailValidatie = true;                    
                    //filtert de eerste 4 letters van de opgegeven emailadres zodat de query de correcte records mee geeft 
                    Email = txtEmail.Text.Substring(0, 4);

                    if (!string.IsNullOrWhiteSpace(txtEmail.Text) && emailValidatie == true)
                    {
                        WindowHomePagina homePagina = new WindowHomePagina();
                        homePagina.Show();
                        this.Close();
                    }
                }
            }                                                                
        }
    }
}
