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
