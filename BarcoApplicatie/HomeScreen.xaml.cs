using BarcoApplicatie.viewModels;
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
        /*
        ViewAcceptJobrequest ViewAcceptJobrequest = new ViewAcceptJobrequest();
        ViewJobrequest ViewJobrequest = new ViewJobrequest();
        */
        public HomeScreen()
        {
            InitializeComponent();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;
            btnSendJob1.DataContext = new MainViewModel();
            btnSendJob1_Copy.DataContext = new MainViewModel(); 
            btnSendJob1_Copy1.DataContext = new MainViewModel(); 
        } 
        /*
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
        */
    }
}
