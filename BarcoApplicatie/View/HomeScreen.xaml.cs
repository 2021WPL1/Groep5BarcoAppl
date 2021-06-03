using BarcoApplicatie.viewModels;
using BarcoApplication.Data;
using Microsoft.Win32;
using System;
using System.Windows;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        private MainViewModel viewModel;

        public HomeScreen()
        {
            InitializeComponent();
            viewModel = new MainViewModel(BarcoApplicationDataService.Instance());
            DataContext = viewModel;

            registryName();

        }
        public void registryName()
        {
            //Robbe
            //De registry ophalen en de knoppen tonen adhv wie er op welke dingen mag
            RegistryKey request = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\BarRequest");
            string userName = "";

            if (request != null)
            {
                userName = Convert.ToString(request.GetValue("Name"));
            }
            if (userName == "Robbe Delsoir")
            {
                btnSendJob1_Copy.IsEnabled = true;
            }
            if (userName == "Nikki Noppe")
            {
                btnSendJob1_Copy1.IsEnabled = true;
            }
        }
    }
}