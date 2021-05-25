using BarcoApplicatie.BibModels;
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
using System.Windows.Threading;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        private BarcoApplicationDataService _dataService;


        ViewAcceptJobrequest ViewAcceptJobrequest = new ViewAcceptJobrequest();
        ViewJobrequest ViewJobrequest = new ViewJobrequest();
        readonly Email email = new Email();

        public HomeScreen()
        {
            InitializeComponent();
            ActivateEmail();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;
        }

        //tijdelijk
        public void ActivateEmail()
        {
            _dataService = BarcoApplicationDataService.Instance();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        //tijdelijk
        void timer_Tick(object sender, EventArgs e)
        {
            //Date kan aangepast worden naar keuze
            DateTime emailSendTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 45, 0); //18pm,0min,0sec
            DateTime dateNow = DateTime.Now;

            List<RqRequest> listAllRequests = _dataService.getAllRequests();

            //if (listAllRequests != null)
            //{
            if (emailSendTime == DateTime.Now)
            {
                MessageBox.Show("EMAIL SEND" + Environment.NewLine + emailSendTime + Environment.NewLine + dateNow);
                //SendMail();
            }

            if (emailSendTime < DateTime.Now)
            {
                if (listAllRequests == null)
                {
                    txtBoxTest.Text = "to late" + Environment.NewLine + emailSendTime + Environment.NewLine + dateNow;
                }
                else
                {
                }
            }

            if (emailSendTime > DateTime.Now)
            {
                txtBoxTest.Text = "to soon" + Environment.NewLine + emailSendTime + Environment.NewLine + dateNow;
            }   
            //}
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
