using BarcoApplication.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BarcoApplication.Data.BibModels;
using Prism.Commands;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BarcoApplicatie.viewModels
{

    /// <summary>
    /// Koen
    /// </summary>
    class AcceptJRViewModel : ViewModelBase
    {
        public ImageSource ImageBarco
        {
            get { return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png")); }
        }

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
        public ICommand HomeCommand { get; set; }

        public AcceptJRViewModel(BarcoApplicationDataService barcoApplicationDataService)
        {
            _dataservice = barcoApplicationDataService;

            Requests = new ObservableCollection<RqRequest>();

            RefuseJobRequestCommand = new RelayCommand<Window>(RefuseJobRequest);
            RemoveJrCommand = new DelegateCommand(RemoveJobRequest);
            OpenAcceptJrWindow = new RelayCommand<Window>(OpenAcceptWindow);
            HomeCommand = new RelayCommand<Window>(ShowHome);
        }

        private RqRequest _selectedRequest;
        private string _initialen;
        private string _emcEUT;
        private string _envEUT;
        private string _relEUT;
        private string _safEUT;
        private string _pckEUT;
        private string _ecoEUT;


        private string _division;
        private string _jobNature;
        private string _projectNumber;
        private string _projectName;
        private string _partNumber;
        private string _netWeight;
        private string _grossWeight;
        private DateTime? _expectedEndDate;
        private bool _batteries_Yes;
        private string _testPlan;
        private string _specialRemarks;
        private bool _EMC;
        private bool _ENV;
        private bool _REL;
        private bool _SAF;
        private bool _PCK;
        private bool _ECO;

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

        public string SpecialRemarks
        {
            get
            {
                return _specialRemarks;
            }
            set
            {
                _specialRemarks = value;
                OnPropertyChanged();
            }
        }
        public string EmcEUT
        {
            get
            {
                return _emcEUT;
            }
            set
            {
                _emcEUT = value;
                OnPropertyChanged();
            }
        }
        public string EnvEUT
        {
            get
            {
                return _envEUT;
            }
            set
            {
                _envEUT = value;
                OnPropertyChanged();
            }
        }
        public string RelEUT
        {
            get
            {
                return _relEUT;
            }
            set
            {
                _relEUT = value;
                OnPropertyChanged();
            }
        }
        public string SafEUT
        {
            get
            {
                return _safEUT;
            }
            set
            {
                _safEUT = value;
                OnPropertyChanged();
            }
        }
        public string PckEUT
        {
            get
            {
                return _pckEUT;
            }
            set
            {
                _pckEUT = value;
                OnPropertyChanged();
            }
        }
        public string EcoEUT
        {
            get
            {
                return _ecoEUT;
            }
            set
            {
                _ecoEUT = value;
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

        public bool EMC
        {
            get
            {
                return _EMC;
            }
            set
            {
                _EMC = value;
                OnPropertyChanged();
            }
        }
        public bool ENV
        {
            get
            {
                return _ENV;
            }
            set
            {
                _ENV = value;
                OnPropertyChanged();
            }
        }
        public bool REL
        {
            get
            {
                return _REL;
            }
            set
            {
                _REL = value;
                OnPropertyChanged();
            }
        }
        public bool SAF
        {
            get
            {
                return _SAF;
            }
            set
            {
                _SAF = value;
                OnPropertyChanged();
            }
        }
        public bool PCK
        {
            get
            {
                return _PCK;
            }
            set
            {
                _PCK = value;
                OnPropertyChanged();
            }
        }
        public bool ECO
        {
            get
            {
                return _ECO;
            }
            set
            {
                _ECO = value;
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

                    var optional = _dataservice.GetOptionals(SelectedRequest.IdRequest);
                    if (optional != null)
                    {
                        TestPlan = optional.Link;
                        SpecialRemarks = optional.Remarks;
                    }

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

                    var detail = _dataservice.GetRequestDetail(SelectedRequest.IdRequest);

                    var eut = _dataservice.GetEuts(detail.IdRqDetail);

                    if (detail.Testdivisie == "EMC")
                    {
                        EMC = true;
                        EmcEUT = eut.OmschrijvingEut;
                    }
                    if (detail.Testdivisie == "ENV")
                    {
                        ENV = true;
                        EnvEUT = eut.OmschrijvingEut;
                    }
                    if (detail.Testdivisie == "REL")
                    {
                        REL = true;
                        RelEUT = eut.OmschrijvingEut;
                    }
                    if (detail.Testdivisie == "SAF")
                    {
                        SAF = true;
                        SafEUT = eut.OmschrijvingEut;
                    }
                    if (detail.Testdivisie == "PCK")
                    {
                        PCK = true;
                        PckEUT = eut.OmschrijvingEut;
                    }
                    if (detail.Testdivisie == "ECO")
                    {
                        ECO = true;
                        EcoEUT = eut.OmschrijvingEut;
                    }
                }
                OnPropertyChanged();
            }
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

        //public void OpenAcceptWindow()
        //{
        //    AcceptJobrequest acceptJobrequest = new AcceptJobrequest();
        //    acceptJobrequest.Show();
        //}

        //public void OpenHomeWindow()
        //{
        //    HomeScreen homeScreen = new HomeScreen();
        //    homeScreen.Show();
        //}

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

        private void RefuseJobRequest(Window window)
        {
            _dataservice.removeJobRequest(SelectedRequest.IdRequest);
            LoadJRIntoListbox();
            ViewJobrequest viewJobrequest = new ViewJobrequest();
            viewJobrequest.Show();
            if (window != null)
            {
                window.Close();
            }
        }
        public void OpenAcceptWindow(Window window)
        {
            AcceptJobrequest acceptJobrequest = new AcceptJobrequest();
            acceptJobrequest.Show();
            if (window != null)
            {
                window.Close();
            }
        }
        public void ShowHome(Window window)
        {
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Show();
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
