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
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        ViewAcceptJobrequest ViewAcceptJobrequest = new ViewAcceptJobrequest();
        ViewJobrequest ViewJobrequest = new ViewJobrequest();

        public HomeScreen()
        {
            InitializeComponent();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;

            //Robbe
            //De registry ophalen en de knoppen tonen adhv wie er op welke dingen mag
            RegistryKey request = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\BarRequest");

            string userName = Convert.ToString(request.GetValue("Name"));


            if (userName == "Robbe")
            {
                btnSendJob1_Copy.IsEnabled = true;

            }

            if (userName == "Nikki")
            {
                btnSendJob1_Copy1.IsEnabled = true;

            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow MainWindow = new MainWindow();
            MainWindow.Closed += (s, args) => this.Close();
            MainWindow.Show();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewAcceptJobrequest.Closed += (s, args) => this.Close();
            ViewAcceptJobrequest.Show();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewJobrequest.Closed += (s, args) => this.Close();
            ViewJobrequest.Show();
        }



    }
}
