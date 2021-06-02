using BarcoApplicatie.viewModels;
using BarcoApplication.Data;
using System.Windows;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for DetailJobrequest.xaml
    /// </summary>
    public partial class DetailJobrequest : Window
    {
        private MainViewModel viewModel;

        public DetailJobrequest()
        {
            InitializeComponent();
            viewModel = new MainViewModel(BarcoApplicationDataService.Instance());
            DataContext = viewModel;
        }
    }
}
