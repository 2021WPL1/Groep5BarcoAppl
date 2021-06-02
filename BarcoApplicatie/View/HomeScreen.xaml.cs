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
using System.Windows.Threading;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        ViewAcceptJobrequest ViewAcceptJobrequest = new ViewAcceptJobrequest();
        ViewJobrequest ViewJobrequest = new ViewJobrequest();
        readonly Email email = new Email();

        public HomeScreen()
        {
            InitializeComponent();
            email.ActivateEmail();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;

            //Robbe
            //De registry ophalen en de knoppen tonen adhv wie er op welke dingen mag
            RegistryKey request = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\BarRequest");

            string userName = Convert.ToString(request.GetValue("Name"));


            if (userName == "Robbe Delsoir")
            {
                btnSendJob1_Copy.IsEnabled = true;
            }

            if (userName == "Nikki Noppe")
            {
                btnSendJob1_Copy1.IsEnabled = true;
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            MainWindow MainWindow = new MainWindow();
            MainWindow.Closed += (s, args) => this.Close();
            MainWindow.Show();
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            ViewAcceptJobrequest.Closed += (s, args) => this.Close();
            ViewAcceptJobrequest.Show();
            this.Close();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            ViewJobrequest.Closed += (s, args) => this.Close();
            ViewJobrequest.Show();
            this.Close();
        }
    }
}