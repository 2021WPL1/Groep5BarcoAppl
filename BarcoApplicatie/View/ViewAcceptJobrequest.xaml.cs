﻿using BarcoApplicatie.viewModels;
using BarcoApplication.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for ViewAcceptJobrequest.xaml
    /// </summary>
    public partial class ViewAcceptJobrequest : Window
    {
        private MainViewModel viewModel;

        public ViewAcceptJobrequest()
        {
            InitializeComponent();
            viewModel = new MainViewModel(BarcoApplicationDataService.Instance());
            DataContext = viewModel;

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;
        }
        //private void btnHome_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Hide();
        //    HomeScreen HomeScreen = new HomeScreen();
        //    HomeScreen.Closed += (s, args) => this.Close();
        //    HomeScreen.Show();
        //    this.Close();
        //}
        
    }
}
