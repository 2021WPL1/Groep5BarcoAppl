using BarcoApplicatie.viewModels;
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
    /// Interaction logic for AcceptJobrequest.xaml
    /// </summary>
    public partial class AcceptJobrequest : Window
    {
        public AcceptJobrequest()
        {
            InitializeComponent();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;
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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MainViewModel();
            this.Close();
            /*
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
            */
        }

        private void btnRefuseJobrequest_Click(object sender, RoutedEventArgs e)
        {
            


        }
    }
}
