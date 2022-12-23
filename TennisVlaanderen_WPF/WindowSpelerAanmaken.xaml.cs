﻿using System;
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
    /// Interaction logic for WindowSpelerAanmaken.xaml
    /// </summary>
    public partial class WindowSpelerAanmaken : Window
    {
        public WindowSpelerAanmaken()
        {
            InitializeComponent();
        }

        Speler nieuwSpeler = new Speler();

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = string.Empty;
            List<Speler> spelers = new List<Speler>();         
                        
                if (!string.IsNullOrEmpty(txtGeboortedatum.Text))
                {
                    nieuwSpeler.GeboorteDatum = DateTime.Parse(txtGeboortedatum.Text);
                }
                else
                {
                    lblError.Content = "Geboortedatum is een verplicht in te vullen veld";
                }

                if (nieuwSpeler.IsGeldig())
                {
                    nieuwSpeler.Naam = txtNaam.Text;
                    nieuwSpeler.Voornaam = txtVoornaam.Text;
                    nieuwSpeler.Email = txtEmail.Text;
                    nieuwSpeler.Adres = txtAdres.Text;
                    nieuwSpeler.Land = txtLand.Text;
                    nieuwSpeler.Nationaliteit = txtNationaliteit.Text;
                    nieuwSpeler.Telefoon = txtTelefoon.Text;
                    nieuwSpeler.RijksNummer = txtRijksNummer.Text;
                    lblError.Content = string.Empty;
                    Toevoegen(true);
                }
                else
                {
                    lblError.Content = nieuwSpeler.Error;
                }

            if (rbMan.IsChecked == false && rbVrouw.IsChecked == false)
            {
                lblError.Content = "Selecteer een geslacht";

                if (rbMan.IsChecked == true)
                {
                    nieuwSpeler.Geslacht = "Man";
                }
                else
                {
                    nieuwSpeler.Geslacht = "Vrouw";
                }
            }

            
                spelers.Add(nieuwSpeler);
                WindowHomePagina homepage = new WindowHomePagina();
                homepage.Show();
                this.Close();                                  
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        
        private void RbVrouw_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbMan_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Toevoegen(bool isToevoeg)
        {
            ISpelerRepository SpelerRepository = new SpelerRepository();

            if (rbMan.IsChecked == true)
            {
                nieuwSpeler.Geslacht = "Man";
            }
            else
            {
                nieuwSpeler.Geslacht = "Vrouw";
            }

            Speler speler = new Speler()
            {
                Id = 21,
                Naam = txtNaam.Text,
                Voornaam = txtVoornaam.Text,
                Klassement = "3",
                Geslacht = nieuwSpeler.Geslacht,
                GeboorteDatum = DateTime.Parse(txtGeboortedatum.Text),
                Nationaliteit = txtNationaliteit.Text,
                Adres = txtAdres.Text,
                Land = txtLand.Text,
                Telefoon = txtTelefoon.Text,
                Email = txtEmail.Text,
                RijksNummer = txtRijksNummer.Text
            };

            if (isToevoeg)
            {
                SpelerRepository.SpelerToevoegen(speler);
            }
            //else kan ik beter een button voorzien bij homepage ???
            //{
            //    SpelerRepository.SpelerUpdate(speler);
            //}
        }      
    };
}
