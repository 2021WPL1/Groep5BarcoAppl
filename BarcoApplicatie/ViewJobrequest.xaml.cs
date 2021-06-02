using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BarcoApplicatie.viewModels;
using BarcoApplication.Data;
using BarcoApplication.Data.BibModels;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for ViewJobrequest.xaml
    /// </summary>
    public partial class ViewJobrequest : Window
    {
        private BarcoApplicationDataService _dataService;

        private static AcceptJRViewModel _viewModel = AcceptJRViewModel.Instance();

        public ViewJobrequest()
        {
            InitializeComponent();

            _dataService = BarcoApplicationDataService.Instance();

            DataContext = _viewModel;
            _viewModel.LoadJRIntoListbox();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;
            getAll();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
            this.Close();
        }

        public List<RqJobNature> getAll()
        {
            Barco2021Context context = new Barco2021Context();
            var test =  context.RqJobNature.ToList();
            return test;
        }

        //Koen
        //private void btnRemove_Click(object sender, RoutedEventArgs e)
        //{
        //    _dataService.removeJobRequest(Convert.ToInt32(lbViewRequest.SelectedValue));
        //    loadAllRequest();
        //}

        //Koen
        //private void btnShow_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Hide();
        //    AcceptJobrequest acceptJobrequest = new AcceptJobrequest();
        //    acceptJobrequest.Closed += (s, args) => this.Close();
        //    acceptJobrequest.Show();
        //    this.Close();
        //}

        private void lbViewRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
