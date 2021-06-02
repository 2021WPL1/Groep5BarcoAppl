using BarcoApplicatie.viewModels;
using BarcoApplication.Data;
using Microsoft.Win32;
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
    public partial class Login : Window
    {

        private MainViewModel viewModel;

        public Login()
        {
            viewModel = new MainViewModel(BarcoApplicationDataService.Instance());
            DataContext = viewModel;
            viewModel.insertDivisionIntoComboBox();

            RegistryKey request = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\BarRequest");

            if (request != null)
            {

                HomeScreen HomeScreen = new HomeScreen();
                HomeScreen.Show();
                this.Close();
            }
        }

        //Robbe
        //De registry aanpassen met de dingen die je ingeeft
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string Name = txtNaam.Text;
            string Functie = txtFunctie.Text;
            string Division = this.cmbDivision.Text;

            RegistryKey request = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\BarRequest");

            if (request != null)
            {
                request.SetValue("Name", Name);
                request.SetValue("Functie", Functie);
                request.SetValue("Division", Division);
                request.Close();
            }

            RegistryKey control = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\BarControl");
            if (control != null)
            {
                control.SetValue("Name", Name);
                control.SetValue("Functie", Functie);
                control.SetValue("Division", Division);
                control.Close();
            }

            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
            this.Close();
        }

    }

}