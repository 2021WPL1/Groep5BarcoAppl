using System;
using System.Windows;
using System.Windows.Media.Imaging;
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
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
        }

        private void btnRefuseJobrequest_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
