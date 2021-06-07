using System.Windows;
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
        }
    }
}
