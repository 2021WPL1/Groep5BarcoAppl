using BarcoApplicatie.viewModels;
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
