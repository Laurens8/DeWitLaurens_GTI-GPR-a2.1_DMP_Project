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
using TennisVlaanderen_DAL;
using TennisVlaanderen_DAL.interfaces;
using TennisVlaanderen_DAL.repositories;

namespace TennisVlaanderen_WPF
{
    /// <summary>
    /// Interaction logic for WindowTerreinReserveren.xaml
    /// </summary>
    public partial class WindowTerreinReserveren : Window
    {
        private ITerreinReservatieRepository terreinReserverenRepository = new TerreinReservatieRepository();
        private IClubRepository clubRepository = new ClubRepository();

        public WindowTerreinReserveren()
        {
            InitializeComponent();
            DataVelden();
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            WindowHomePagina homePagina = new WindowHomePagina();
            homePagina.Show();
            this.Close();
        }

        private void RbGravel_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RbGras_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DataVelden()
        {
            if (rbGras.IsChecked == true)
            {
                string TypeOndergrond = "Gras";
                List<TerreinReservatie> veldenDB = (List<TerreinReservatie>)terreinReserverenRepository.OphalenterreinGras(TypeOndergrond);
                cbVeld.ItemsSource = veldenDB;
            }
            if (rbGravel.IsChecked == true)
            {
                string TypeOndergrond = "Gravel";
                List<TerreinReservatie> veldenDB = (List<TerreinReservatie>)terreinReserverenRepository.OphalenterreinGravel(TypeOndergrond);
                cbVeld.ItemsSource = veldenDB;
            }
                    
        }
    }
}
