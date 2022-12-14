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
using TennisVlaanderen_Models;

namespace TennisVlaanderen_WPF
{
    /// <summary>
    /// Interaction logic for WindowSpelerAanmaken.xaml
    /// </summary>
    public partial class WindowSpelerAanmaken : Window
    {
        public WindowSpelerAanmaken()
        {
            InitializeComponent();
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            Speler nieuwSpeler= new Speler();
            List<Speler> spelers= new List<Speler>();

            nieuwSpeler.naam = txtNaam.Text;
            nieuwSpeler.voornaam= txtVoornaam.Text;
            nieuwSpeler.geboorteDatum = DateTime.Parse(txtGeboortedatum.Text);
            nieuwSpeler.email= txtEmail.Text;
            nieuwSpeler.adres= txtAdres.Text;
            nieuwSpeler.land= txtLand.Text;
            nieuwSpeler.nationaliteit= txtNationaliteit.Text;
            nieuwSpeler.telefoon= txtTelefoon.Text;
            nieuwSpeler.rijksNummer= txtRijksNummer.Text;
          
            if (rbMan.IsChecked == false && rbVrouw.IsChecked == false)
            {
                MessageBox.Show("Selecteer een geslacht");

                if (rbMan.IsChecked == true)
                {
                    nieuwSpeler.geslacht = "Man";
                }
                else
                {
                    nieuwSpeler.geslacht = "Vrouw";
                }
            }
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public List<string> WachtwoordValidatie()
        {
            List<string> wachtwoordenLijst = new List<string>();
            string wachtwoordtext = txtWachtwoord.Text;
            wachtwoordenLijst.Add(wachtwoordtext);
            return wachtwoordenLijst;
        }

        private void RbVrouw_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbMan_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
