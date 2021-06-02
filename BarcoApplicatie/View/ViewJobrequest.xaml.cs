using System.Windows;
using BarcoApplicatie.viewModels;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for ViewJobrequest.xaml
    /// </summary>
    public partial class ViewJobrequest : Window
    {
        //private BarcoApplicationDataService _dataService = BarcoApplicationDataService.Instance();
        private static AcceptJRViewModel _viewModel = AcceptJRViewModel.Instance();

        public ViewJobrequest()
        {
            InitializeComponent();
            //_dataService 
            DataContext = _viewModel;
            _viewModel.LoadJRIntoListbox();
        }
    }
}
