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
    /// Interaction logic for WindowHomePagina.xaml
    /// </summary>
    public partial class WindowHomePagina : Window
    {
        public WindowHomePagina()
        {
            InitializeComponent();
            DataSpeler();
        }

        private ISpelerRepository spelers = new SpelerRepository();

        private void DataSpeler()
        {
            List<Speler> spelersDB = spelers.OphalenSpeler();

            foreach (var item in spelersDB)
            {
                lblDashbord.Content = item.ToString();          
            }
        }

        private void BtnTornooi_Click(object sender, RoutedEventArgs e)
        {
            WindowTornooi tornooi= new WindowTornooi();
            tornooi.Show();
        }

        private void BtnClub_Click(object sender, RoutedEventArgs e)
        {
            WindowClub club = new WindowClub();
            club.Show();
        }

        private void BtnLessen_Click(object sender, RoutedEventArgs e)
        {
            WindowLessen lessen = new WindowLessen();
            lessen.Show();
        }

        private void BtnTerrein_Click(object sender, RoutedEventArgs e)
        {
            WindowTerreinReserveren terrein = new WindowTerreinReserveren();
            terrein.Show();
        }
    }
}
