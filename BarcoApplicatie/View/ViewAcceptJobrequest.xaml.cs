using BarcoApplicatie.viewModels;
using BarcoApplication.Data;
using System.Windows;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for ViewAcceptJobrequest.xaml
    /// </summary>
    public partial class ViewAcceptJobrequest : Window
    {
        private MainViewModel viewModel;

        public ViewAcceptJobrequest()
        {
            InitializeComponent();
            viewModel = new MainViewModel(BarcoApplicationDataService.Instance());
            DataContext = viewModel;
        }        
    }
}
