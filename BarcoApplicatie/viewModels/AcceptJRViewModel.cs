using System.Collections.ObjectModel;
using BarcoApplication.Data;
using System.Windows.Input;
using BarcoApplication.Data.BibModels;
using Prism.Commands;


namespace BarcoApplicatie.viewModels
{
    public class AcceptJRViewModel : ViewModelBase
    {
        public ICommand OpenAcceptJRCommand { get; set; }

        public ObservableCollection<RqRequest> Requests { get; set; }

        private BarcoApplicationDataService _dataservice;

        public AcceptJRViewModel(BarcoApplicationDataService barcoApplicationDataService)
        {
            _dataservice = barcoApplicationDataService;

            Requests = new ObservableCollection<RqRequest>();
            OpenAcceptJRCommand = new DelegateCommand(OpenAcceptJRWindow);
        }

        private RqRequest _selectedRequest;
        private string _initialen;

        public RqRequest SelectedRequest
        {
            get { return _selectedRequest; }
            set
            {
                _selectedRequest = value;

                if (value != null)
                {
                    Initialen = value.Requester;
                }
                OnPropertyChanged();
            }
        }

        public string Initialen
        {
            get
            {
                return _initialen;
            }
            set
            {
                _initialen = value;
                OnPropertyChanged();
            }
        }

        private void OpenAcceptJRWindow()
        {
            AcceptJobrequest acceptJobrequest = new AcceptJobrequest();
            acceptJobrequest.Show();
        }
    }
}
