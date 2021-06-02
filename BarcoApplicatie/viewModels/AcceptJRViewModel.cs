using BarcoApplication.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using BarcoApplication.Data.BibModels;
using Prism.Commands;

namespace BarcoApplicatie.viewModels
{
    class AcceptJRViewModel : ViewModelBase
    {
        private static readonly AcceptJRViewModel _acceptJrViewModel = new AcceptJRViewModel(BarcoApplicationDataService.Instance());

        public static AcceptJRViewModel Instance()
        {
            return _acceptJrViewModel;
        }

        private BarcoApplicationDataService _dataservice;

        public ObservableCollection<RqRequest> Requests { get; set; }

        public ICommand OpenAcceptJrWindow { get; set; }
        public ICommand RefuseJobRequestCommand { get; set; }
        public ICommand RemoveJrCommand { get; set; }

        public AcceptJRViewModel(BarcoApplicationDataService barcoApplicationDataService)
        {
            _dataservice = barcoApplicationDataService;

            Requests = new ObservableCollection<RqRequest>();

            RefuseJobRequestCommand = new DelegateCommand(RefuseJobRequest);
            RemoveJrCommand = new DelegateCommand(RemoveJobRequest);
            OpenAcceptJrWindow = new DelegateCommand(OpenAcceptWindow);
        }

        private RqRequest _selectedRequest;
        private string _initialen;
        private string _division;
        private string _jobNature;
        private string _projectNumber;
        private string _projectName;
        private string _partNumber;
        private string _netWeight;
        private string _grossWeight;
        private DateTime? _expectedEndDate;
        private bool _batteries_Yes;
        private bool _batteries_No;
        private string _testPlan;

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
        public string Division
        {
            get
            {
                return _division;
            }
            set
            {
                _division = value;
                OnPropertyChanged();
            }
        }
        public string JobNature
        {
            get
            {
                return _jobNature;
            }
            set
            {
                _jobNature = value;
                OnPropertyChanged();
            }
        }
        public string ProjectNumber
        {
            get
            {
                return _projectNumber;
            }
            set
            {
                _projectNumber = value;
                OnPropertyChanged();
            }
        }
        public string ProjectName
        {
            get
            {
                return _projectName;
            }
            set
            {
                _projectName = value;
                OnPropertyChanged();
            }
        }
        public string PartNumber
        {
            get
            {
                return _partNumber;
            }
            set
            {
                _partNumber = value;
                OnPropertyChanged();
            }
        }
        public string NetWeight
        {
            get
            {
                return _netWeight;
            }
            set
            {
                _netWeight = value;
                OnPropertyChanged();
            }
        }
        public string GrossWeight
        {
            get
            {
                return _grossWeight;
            }
            set
            {
                _grossWeight = value;
                OnPropertyChanged();
            }
        }
        public DateTime? ExpectedEndDate
        {
            get
            {
                return _expectedEndDate;
            }
            set
            {
                _expectedEndDate = value;
                OnPropertyChanged();
            }
        }
        public bool Batteries_Yes
        {
            get
            {
                return _batteries_Yes;
            }
            set
            {
                _batteries_Yes = value;
                OnPropertyChanged();
            }
        }

        public bool Batteries_No
        {
            get
            {
                return _batteries_No;
            }
            set
            {
                _batteries_No = value;
                OnPropertyChanged();
            }
        }

        public string TestPlan
        {
            get
            {
                return _testPlan;
            }
            set
            {
                _testPlan = value;
                OnPropertyChanged();
            }
        }

        public RqRequest SelectedRequest
        {
            get { return _selectedRequest; }
            set
            {
                _selectedRequest = value;

                if (value != null)
                {
                    Initialen = value.Requester;
                    Division = value.BarcoDivision;
                    JobNature = value.JobNature;
                    ProjectNumber = value.HydraProjectNr;
                    ProjectName = value.EutProjectname;
                    PartNumber = value.EutPartnumbers;
                    NetWeight = value.NetWeight;
                    GrossWeight = value.GrossWeight;
                    ExpectedEndDate = value.ExpectedEnddate;
                    Batteries_Yes = value.Battery;
                    Batteries_No = value.Battery;
                }
                OnPropertyChanged();
            }
        }

        private void RefuseJobRequest()
        {
            _dataservice.removeJobRequest(SelectedRequest.IdRequest);
        }

        private void RemoveJobRequest()
        {
            _dataservice.removeJobRequest(SelectedRequest.IdRequest);
            LoadJRIntoListbox();
        }

        public void LoadJRIntoListbox()
        {
            var requests = _dataservice.getAllRequests();
            Requests.Clear();
            foreach (var request in requests)
            { 
                Requests.Add(request);
            }
        }

        public void OpenAcceptWindow()
        {
            AcceptJobrequest acceptJobrequest = new AcceptJobrequest();
            acceptJobrequest.Show();
        }

        public void RqDate()
        {
            string dateTimeToday = DateTime.Now.ToString("yyyyMMdd");
            //Console.WriteLine(dateTimeString);
            //20210527
        }
        public void JrNumber()
        {
            //counter komt uit database
            int counter = 1;
            //als database leeg is komt counter op 1
            if (counter == 0)
            {
                counter = 1;
            }
            else
            {
                counter++;
            }
            //je counter met automatisch 4 cijfers
            string sCounter = String.Format("{0:D4}", counter);
            //0001
        }
    }
}
