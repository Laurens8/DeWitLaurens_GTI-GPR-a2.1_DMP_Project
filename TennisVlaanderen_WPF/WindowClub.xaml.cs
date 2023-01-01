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
    /// Interaction logic for WindowClub.xaml
    /// </summary>
    public partial class WindowClub : Window
    {
        public WindowClub()
        {
            InitializeComponent();
            OphalenDataClub();
        }        

        Club nieuwClub = new Club();
        Speler speler = new Speler();

        private ITarievenRepository tarievenRepository = new TarievenRepository();
        private IClubRepository clubRepository = new ClubRepository();
        private ISpelerRepository spelerRepository = new SpelerRepository();

        private void OphalenDataClub()
        {
            List<Club> clubDB = (List<Club>)clubRepository.OphalenClubNaam();            
            cbClub.ItemsSource = clubDB;
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbClub.SelectedItem != null && cbAanbod.SelectedItem != null)
            {
                try
                {
                    nieuwClub = (Club)cbClub.SelectedItem;
                    Tarieven leeftijdvaliedatie = (Tarieven)cbAanbod.SelectedItem;
                    List<Speler> spelersDB = spelerRepository.OphalenSpeler(speler.Email = MainWindow.Email);

                    foreach (var item in spelersDB)
                    {
                        Club club = new Club()
                        {
                            Id = nieuwClub.Id,
                            ClubNaam = nieuwClub.ClubNaam,
                            Adres = nieuwClub.Adres,
                            Telefoon = nieuwClub.Telefoon,
                            Email = nieuwClub.Email,
                            Website = nieuwClub.Website,
                            KwaliteitLabel = nieuwClub.KwaliteitLabel,
                            Clubaanbod = nieuwClub.Clubaanbod,
                        };
                        item.ClubID = club.Id;
                        speler = item;
                        spelerRepository.SpelerUpdate(speler);

                        if (leeftijdvaliedatie.Leeftijdgraad == "jeugd" && speler.GeboorteDatum.Year <= 2005)
                        {
                            MessageBox.Show("de jeugd tarief is aleen maar voor personen onder de 18 jaar");                           
                        }
                        else if (leeftijdvaliedatie.Leeftijdgraad == "senioren" && speler.GeboorteDatum.Year >= 1958)
                        {
                            MessageBox.Show("de senioren tarief is aleen maar voor personen over de 65 jaar");
                        }
                        else 
                        {
                            WindowHomePagina homePagina = new WindowHomePagina();
                            homePagina.Show();
                            this.Close();
                        }                                             
                    }
                }
                catch (Exception ex) { FileOperations.FoutLoggen(ex); }               
            }
            else
            {
                MessageBox.Show("Selecteer eerst een club en abonnement");
            }            
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }

        private void CbClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            string clubNaam = cbClub.SelectedItem.ToString().Substring(3, 4);
            List<Tarieven> tarievenDB = (List<Tarieven>)tarievenRepository.OphalenTarieven(clubNaam);
            cbAanbod.ItemsSource = tarievenDB;
            nieuwClub = (Club)cbClub.SelectedValue;
            
            lblNaam.Content = nieuwClub.ClubNaam;
            lblAdres.Content = nieuwClub.Adres;
            lblEmail.Content = nieuwClub.Email;
            lblTelefoon.Content = nieuwClub.Telefoon;
            lblWebsite.Content = nieuwClub.Website;
        }
    }
}