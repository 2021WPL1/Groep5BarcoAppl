﻿using BarcoApplication.Data;
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
using BarcoApplicatie.viewModels;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for AcceptJobrequest.xaml
    /// </summary>
    public partial class AcceptJobrequest : Window
    {
        private static AcceptJRViewModel _viewModel = AcceptJRViewModel.Instance();

        public AcceptJobrequest()
        {
            InitializeComponent();
            DataContext = _viewModel;

            //need to add binding acceptJobrequest (btnSendJob)
        }

        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Checkbox_Yes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Checkbox_No_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}
