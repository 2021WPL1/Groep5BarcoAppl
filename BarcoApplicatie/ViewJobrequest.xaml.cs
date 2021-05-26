using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
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

        public ViewJobrequest()
        {
            InitializeComponent();

            _dataService = BarcoApplicationDataService.Instance();

            loadAllRequest();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
        }

        //Koen
        private void updateListBox(ListBox listBox, string display, string value, IEnumerable source)
        {
            listBox.DisplayMemberPath = display;
            listBox.SelectedValuePath = value;
            listBox.ItemsSource = source;
        }

        //Koen
        private void loadAllRequest()
        {
            List<RqRequest> requests = _dataService.getAllRequests();
            updateListBox(lbViewRequest, "ExpectedEnddate", "IdRequest", requests);
        }

        //Koen
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _dataService.removeJobRequest(Convert.ToInt32(lbViewRequest.SelectedValue));
            loadAllRequest();
        }

        //Koen
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AcceptJobrequest acceptJobrequest = new AcceptJobrequest();
            acceptJobrequest.Closed += (s, args) => this.Close();
            acceptJobrequest.Show();
        }
    }
}
