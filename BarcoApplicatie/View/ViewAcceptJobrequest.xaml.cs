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

        private static AcceptJRViewModel _viewModel = AcceptJRViewModel.Instance();

        public ViewAcceptJobrequest()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }        
    }
}
