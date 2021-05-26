using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using BarcoApplication.Data;
using BarcoApplication.Data.BibModels;
using Prism.Commands;

namespace BarcoApplicatie.viewModels
{

    /// <summary>
    /// Koen
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private RqRequest request = new RqRequest();
        private RqOptionel optionel = new RqOptionel();
        private RqTestDevision testDevision = new RqTestDevision();
        private RqRequestDetail requestDetail;
        private Eut eut;


        private BarcoApplicationDataService _dataservice;

        public ICommand SendJobRequestCommand { get; set; }

        public ObservableCollection<RqBarcoDivision> Divisions { get; set; }
        public ObservableCollection<RqJobNature> JobNatures { get; set; }

        private RqBarcoDivision _selectedDivision;
        private RqJobNature _selectedJobNatures;

        public RqBarcoDivision SelectedDivision
        {
            get { return _selectedDivision; }
            set
            {
                _selectedDivision = value;
                OnPropertyChanged();
            }
        }
        public RqJobNature SelectedJobNatures
        {
            get { return _selectedJobNatures; }
            set
            {
                _selectedJobNatures = value;
                OnPropertyChanged();
            }
        }

        private string _requesterInitials;

        private string _projectNumber;

        private string _projectName;

        private string _linkToTestplan;
        private string _specialRemarks;

        private string _eutPartnumber1;
        private string _eutPartnumber2;
        private string _eutPartnumber3;
        private string _eutPartnumber4;
        private string _eutPartnumber5;

        private string _netWeight1;
        private string _netWeight2;
        private string _netWeight3;
        private string _netWeight4;
        private string _netWeight5;

        private string _grossWeight1;
        private string _grossWeight2;
        private string _grossWeight3;
        private string _grossWeight4;
        private string _grossWeight5;

        private DateTime _expectedEndDate = DateTime.Now;

        private DateTime _EUT1Date = DateTime.Now;
        private DateTime _EUT2Date = DateTime.Now;
        private DateTime _EUT3Date = DateTime.Now;
        private DateTime _EUT4Date = DateTime.Now;
        private DateTime _EUT5Date = DateTime.Now;
        private DateTime _EUT6Date = DateTime.Now;
        private DateTime _PVGDate = DateTime.Now;

        private bool _batteries_Yes;

        public string EUT1Message { get; set; }
        public string EUT2Message { get; set; }
        public string EUT3Message { get; set; }
        public string EUT4Message { get; set; }
        public string EUT5Message { get; set; }
        public string EUT6Message { get; set; }

        private bool _EmcEUT1;
        private bool _EmcEUT2;
        private bool _EmcEUT3;
        private bool _EmcEUT4;
        private bool _EmcEUT5;
        private bool _EmcEUT6;

        private bool _EnvEUT1;
        private bool _EnvEUT2;
        private bool _EnvEUT3;
        private bool _EnvEUT4;
        private bool _EnvEUT5;
        private bool _EnvEUT6;

        private bool _RelEUT1;
        private bool _RelEUT2;
        private bool _RelEUT3;
        private bool _RelEUT4;
        private bool _RelEUT5;
        private bool _RelEUT6;

        private bool _SafeEUT1;
        private bool _SafeEUT2;
        private bool _SafeEUT3;
        private bool _SafeEUT4;
        private bool _SafeEUT5;
        private bool _SafeEUT6;

        private bool _PackEUT1;
        private bool _PackEUT2;
        private bool _PackEUT3;
        private bool _PackEUT4;
        private bool _PackEUT5;
        private bool _PackEUT6;

        private bool _GreenEUT1;
        private bool _GreenEUT2;
        private bool _GreenEUT3;
        private bool _GreenEUT4;
        private bool _GreenEUT5;
        private bool _GreenEUT6;

        private bool _EMC;
        public string EMCMessage { get; set; }
        private bool _ENV;
        public string ENVMessage { get; set; }
        private bool _REL;
        public string RELMessage { get; set; }
        private bool _SAFE;
        public string SAFEMessage { get; set; }
        private bool _PACK;
        public string PACKMessage { get; set; }
        private bool _GREEN;
        public string GREENMessage { get; set; }

        public string RequesterInitials
        {
            get
            {
                return _requesterInitials;
            }
            set
            {
                _requesterInitials = value;
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


        public DateTime ExpectedEndDate
        {
            get { return _expectedEndDate; }

            set
            {
                _expectedEndDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime EUT1Date
        {
            get { return _EUT1Date; }

            set
            {
                _EUT1Date = value;
                OnPropertyChanged();
            }
        }
        public DateTime EUT2Date
        {
            get { return _EUT2Date; }

            set
            {
                _EUT2Date = value;
                OnPropertyChanged();
            }
        }
        public DateTime EUT3Date
        {
            get { return _EUT3Date; }

            set
            {
                _EUT3Date = value;
                OnPropertyChanged();
            }
        }
        public DateTime EUT4Date
        {
            get { return _EUT4Date; }

            set
            {
                _EUT4Date = value;
                OnPropertyChanged();
            }
        }
        public DateTime EUT5Date
        {
            get { return _EUT5Date; }

            set
            {
                _EUT5Date = value;
                OnPropertyChanged();
            }
        }
        public DateTime EUT6Date
        {
            get { return _EUT6Date; }

            set
            {
                _EUT6Date = value;
                OnPropertyChanged();
            }
        }
        public DateTime PVGDate
        {
            get { return _PVGDate; }

            set
            {
                _PVGDate = value;
                OnPropertyChanged();
            }
        }

        public string EutPartnumber1
        {
            get
            {
                return _eutPartnumber1;
            }
            set
            {
                _eutPartnumber1 = value;
                OnPropertyChanged();
            }
        }
        public string EutPartnumber2
        {
            get
            {
                return _eutPartnumber2;
            }
            set
            {
                _eutPartnumber2 = value;
                OnPropertyChanged();
            }
        }
        public string EutPartnumber3
        {
            get
            {
                return _eutPartnumber3;
            }
            set
            {
                _eutPartnumber3 = value;
                OnPropertyChanged();
            }
        }
        public string EutPartnumber4
        {
            get
            {
                return _eutPartnumber4;
            }
            set
            {
                _eutPartnumber4 = value;
                OnPropertyChanged();
            }
        }
        public string EutPartnumber5
        {
            get
            {
                return _eutPartnumber5;
            }
            set
            {
                _eutPartnumber5 = value;
                OnPropertyChanged();
            }
        }

        public string NetWeight1
        {
            get
            {
                return _netWeight1;
            }
            set
            {
                _netWeight1 = value;
                OnPropertyChanged();
            }
        }
        public string NetWeight2
        {
            get
            {
                return _netWeight2;
            }
            set
            {
                _netWeight2 = value;
                OnPropertyChanged();
            }
        }
        public string NetWeight3
        {
            get
            {
                return _netWeight3;
            }
            set
            {
                _netWeight3 = value;
                OnPropertyChanged();
            }
        }
        public string NetWeight4
        {
            get
            {
                return _netWeight4;
            }
            set
            {
                _netWeight4 = value;
                OnPropertyChanged();
            }
        }
        public string NetWeight5
        {
            get
            {
                return _netWeight5;
            }
            set
            {
                _netWeight5 = value;
                OnPropertyChanged();
            }
        }

        public string GrossWeight1
        {
            get
            {
                return _grossWeight1;
            }
            set
            {
                _grossWeight1 = value;
                OnPropertyChanged();
            }
        }
        public string GrossWeight2
        {
            get
            {
                return _grossWeight2;
            }
            set
            {
                _grossWeight2 = value;
                OnPropertyChanged();
            }
        }
        public string GrossWeight3
        {
            get
            {
                return _grossWeight3;
            }
            set
            {
                _grossWeight3 = value;
                OnPropertyChanged();
            }
        }
        public string GrossWeight4
        {
            get
            {
                return _grossWeight4;
            }
            set
            {
                _grossWeight4 = value;
                OnPropertyChanged();
            }
        }
        public string GrossWeight5
        {
            get
            {
                return _grossWeight5;
            }
            set
            {
                _grossWeight5 = value;
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

        public bool EmcEUT1
        {
            get
            {
                return _EmcEUT1;
            }
            set
            {
                if (_EmcEUT1 == value) return;

                _EmcEUT1 = value;
                EUT1Message = _EmcEUT1 ? "EUT1" : "";

                OnPropertyChanged();
            }
        }
        public bool EmcEUT2
        {
            get
            {
                return _EmcEUT2;
            }
            set
            {
                if (_EmcEUT2 == value) return;

                _EmcEUT2 = value;
                EUT2Message = _EmcEUT2 ? "EUT2" : "";

                OnPropertyChanged();
            }
        }
        public bool EmcEUT3
        {
            get
            {
                return _EmcEUT3;
            }
            set
            {
                if (_EmcEUT3 == value) return;

                _EmcEUT3 = value;
                EUT3Message = _EmcEUT3 ? "EUT3" : "";

                OnPropertyChanged();
            }
        }
        public bool EmcEUT4
        {
            get
            {
                return _EmcEUT4;
            }
            set
            {
                if (_EmcEUT4 == value) return;

                _EmcEUT4 = value;
                EUT4Message = _EmcEUT4 ? "EUT4" : "";

                OnPropertyChanged();
            }
        }
        public bool EmcEUT5
        {
            get
            {
                return _EmcEUT5;
            }
            set
            {
                if (_EmcEUT5 == value) return;

                _EmcEUT5 = value;
                EUT5Message = _EmcEUT5 ? "EUT5" : "";

                OnPropertyChanged();
            }
        }
        public bool EmcEUT6
        {
            get
            {
                return _EmcEUT6;
            }
            set
            {
                if (_EmcEUT6 == value) return;

                _EmcEUT6 = value;
                EUT6Message = _EmcEUT6 ? "EUT6" : "";

                OnPropertyChanged();
            }
        }

        public bool EnvEUT1
        {
            get
            {
                return _EnvEUT1;
            }
            set
            {
                if (_EnvEUT1 == value) return;

                _EnvEUT1 = value;
                EUT1Message = _EnvEUT1 ? "EUT1" : "";

                OnPropertyChanged();
            }
        }
        public bool EnvEUT2
        {
            get
            {
                return _EnvEUT2;
            }
            set
            {
                if (_EnvEUT2 == value) return;

                _EnvEUT2 = value;
                EUT2Message = _EnvEUT2 ? "EUT2" : "";

                OnPropertyChanged();
            }
        }
        public bool EnvEUT3
        {
            get
            {
                return _EnvEUT3;
            }
            set
            {
                if (_EnvEUT3 == value) return;

                _EnvEUT3 = value;
                EUT3Message = _EnvEUT3 ? "EUT3" : "";

                OnPropertyChanged();
            }
        }
        public bool EnvEUT4
        {
            get
            {
                return _EnvEUT4;
            }
            set
            {
                if (_EnvEUT4 == value) return;

                _EnvEUT4 = value;
                EUT4Message = _EnvEUT4 ? "EUT4" : "";

                OnPropertyChanged();
            }
        }
        public bool EnvEUT5
        {
            get
            {
                return _EnvEUT5;
            }
            set
            {
                if (_EnvEUT5 == value) return;

                _EnvEUT5 = value;
                EUT5Message = _EnvEUT5 ? "EUT5" : "";

                OnPropertyChanged();
            }
        }
        public bool EnvEUT6
        {
            get
            {
                return _EnvEUT6;
            }
            set
            {
                if (_EnvEUT6 == value) return;

                _EnvEUT6 = value;
                EUT6Message = _EnvEUT6 ? "EUT6" : "";

                OnPropertyChanged();
            }
        }

        public bool RelEUT1
        {
            get
            {
                return _RelEUT1;
            }
            set
            {
                if (_RelEUT1 == value) return;

                _RelEUT1 = value;
                EUT1Message = _RelEUT1 ? "EUT1" : "";

                OnPropertyChanged();
            }
        }
        public bool RelEUT2
        {
            get
            {
                return _RelEUT2;
            }
            set
            {
                if (_RelEUT2 == value) return;

                _RelEUT2 = value;
                EUT2Message = _RelEUT2 ? "EUT2" : "";

                OnPropertyChanged();
            }
        }
        public bool RelEUT3
        {
            get
            {
                return _RelEUT3;
            }
            set
            {
                if (_RelEUT3 == value) return;

                _RelEUT3 = value;
                EUT3Message = _RelEUT3 ? "EUT3" : "";

                OnPropertyChanged();
            }
        }
        public bool RelEUT4
        {
            get
            {
                return _RelEUT4;
            }
            set
            {
                if (_RelEUT4 == value) return;

                _RelEUT4 = value;
                EUT4Message = _RelEUT4 ? "EUT4" : "";

                OnPropertyChanged();
            }
        }
        public bool RelEUT5
        {
            get
            {
                return _RelEUT5;
            }
            set
            {
                if (_RelEUT5 == value) return;

                _RelEUT5 = value;
                EUT5Message = _RelEUT5 ? "EUT5" : "";

                OnPropertyChanged();
            }
        }
        public bool RelEUT6
        {
            get
            {
                return _RelEUT6;
            }
            set
            {
                if (_RelEUT6 == value) return;

                _RelEUT6 = value;
                EUT6Message = _RelEUT6 ? "EUT6" : "";

                OnPropertyChanged();
            }
        }

        public bool SafeEUT1
        {
            get
            {
                return _SafeEUT1;
            }
            set
            {
                if (_SafeEUT1 == value) return;

                _SafeEUT1 = value;
                EUT1Message = _SafeEUT1 ? "EUT1" : "";

                OnPropertyChanged();
            }
        }
        public bool SafeEUT2
        {
            get
            {
                return _SafeEUT2;
            }
            set
            {
                if (_SafeEUT2 == value) return;

                _SafeEUT2 = value;
                EUT2Message = _SafeEUT2 ? "EUT2" : "";

                OnPropertyChanged();
            }
        }
        public bool SafeEUT3
        {
            get
            {
                return _SafeEUT3;
            }
            set
            {
                if (_SafeEUT3 == value) return;

                _SafeEUT3 = value;
                EUT3Message = _SafeEUT3 ? "EUT3" : "";

                OnPropertyChanged();
            }
        }
        public bool SafeEUT4
        {
            get
            {
                return _SafeEUT4;
            }
            set
            {
                if (_SafeEUT4 == value) return;

                _SafeEUT4 = value;
                EUT4Message = _SafeEUT4 ? "EUT4" : "";

                OnPropertyChanged();
            }
        }
        public bool SafeEUT5
        {
            get
            {
                return _SafeEUT5;
            }
            set
            {
                if (_SafeEUT5 == value) return;

                _SafeEUT5 = value;
                EUT5Message = _SafeEUT5 ? "EUT5" : "";

                OnPropertyChanged();
            }
        }
        public bool SafeEUT6
        {
            get
            {
                return _SafeEUT6;
            }
            set
            {
                if (_SafeEUT6 == value) return;

                _SafeEUT6 = value;
                EUT6Message = _SafeEUT6 ? "EUT6" : "";

                OnPropertyChanged();
            }
        }

        public bool PackEUT1
        {
            get
            {
                return _PackEUT1;
            }
            set
            {
                if (_PackEUT1 == value) return;

                _PackEUT1 = value;
                EUT1Message = _PackEUT1 ? "EUT1" : "";

                OnPropertyChanged();
            }
        }
        public bool PackEUT2
        {
            get
            {
                return _PackEUT2;
            }
            set
            {
                if (_PackEUT2 == value) return;

                _PackEUT2 = value;
                EUT2Message = _PackEUT2 ? "EUT2" : "";

                OnPropertyChanged();
            }
        }
        public bool PackEUT3
        {
            get
            {
                return _PackEUT3;
            }
            set
            {
                if (_PackEUT3 == value) return;

                _PackEUT3 = value;
                EUT3Message = _PackEUT3 ? "EUT3" : "";

                OnPropertyChanged();
            }
        }
        public bool PackEUT4
        {
            get
            {
                return _PackEUT4;
            }
            set
            {
                if (_PackEUT4 == value) return;

                _PackEUT4 = value;
                EUT4Message = _PackEUT4 ? "EUT4" : "";

                OnPropertyChanged();
            }
        }
        public bool PackEUT5
        {
            get
            {
                return _PackEUT5;
            }
            set
            {
                if (_PackEUT5 == value) return;

                _PackEUT5 = value;
                EUT5Message = _PackEUT5 ? "EUT5" : "";

                OnPropertyChanged();
            }
        }
        public bool PackEUT6
        {
            get
            {
                return _PackEUT6;
            }
            set
            {
                if (_PackEUT6 == value) return;

                _PackEUT6 = value;
                EUT6Message = _PackEUT6 ? "EUT6" : "";

                OnPropertyChanged();
            }
        }

        public bool GreenEUT1
        {
            get
            {
                return _GreenEUT1;
            }
            set
            {
                if (_GreenEUT1 == value) return;

                _GreenEUT1 = value;
                EUT1Message = _GreenEUT1 ? "EUT1" : "";

                OnPropertyChanged();
            }
        }
        public bool GreenEUT2
        {
            get
            {
                return _GreenEUT2;
            }
            set
            {
                if (_GreenEUT2 == value) return;

                _GreenEUT2 = value;
                EUT2Message = _GreenEUT2 ? "EUT2" : "";

                OnPropertyChanged();
            }
        }
        public bool GreenEUT3
        {
            get
            {
                return _GreenEUT3;
            }
            set
            {
                if (_GreenEUT3 == value) return;

                _GreenEUT3 = value;
                EUT3Message = _GreenEUT3 ? "EUT3" : "";

                OnPropertyChanged();
            }
        }
        public bool GreenEUT4
        {
            get
            {
                return _GreenEUT4;
            }
            set
            {
                if (_GreenEUT4 == value) return;

                _GreenEUT4 = value;
                EUT4Message = _GreenEUT4 ? "EUT4" : "";

                OnPropertyChanged();
            }
        }
        public bool GreenEUT5
        {
            get
            {
                return _GreenEUT5;
            }
            set
            {
                if (_GreenEUT5 == value) return;

                _GreenEUT5 = value;
                EUT5Message = _GreenEUT5 ? "EUT5" : "";

                OnPropertyChanged();
            }
        }
        public bool GreenEUT6
        {
            get
            {
                return _GreenEUT6;
            }
            set
            {
                if (_GreenEUT6 == value) return;

                _GreenEUT6 = value;
                EUT6Message = _GreenEUT6 ? "EUT6" : "";

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
                if (_EMC == value) return;

                _EMC = value;
                EMCMessage = _EMC ? "EMC" : "";

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
                if (_ENV == value) return;

                _ENV = value;
                ENVMessage = _ENV ? "ENV" : "";

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
                if (_REL == value) return;

                _REL = value;
                RELMessage = _REL ? "REL" : "";

                OnPropertyChanged();
            }
        }
        public bool SAFE
        {
            get
            {
                return _SAFE;
            }
            set
            {
                if (_SAFE == value) return;

                _SAFE = value;
                SAFEMessage = _SAFE ? "SAF" : "";

                OnPropertyChanged();
            }
        }
        public bool PACK
        {
            get
            {
                return _PACK;
            }
            set
            {
                if (_PACK == value) return;

                _PACK = value;
                PACKMessage = _PACK ? "PCK" : "";

                OnPropertyChanged();
            }
        }
        public bool GREEN
        {
            get
            {
                return _GREEN;
            }
            set
            {
                if (_GREEN == value) return;

                _GREEN = value;
                GREENMessage = _GREEN ? "ECO" : "";

                OnPropertyChanged();
            }
        }

        public string LinkToTestplan
        {
            get
            {
                return _linkToTestplan;
            }
            set
            {
                _linkToTestplan = value;
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

        public MainViewModel(BarcoApplicationDataService dataService)
        {
            this._dataservice = dataService;

            SendJobRequestCommand = new DelegateCommand(SendJobRequest);


            Divisions = new ObservableCollection<RqBarcoDivision>();
            JobNatures = new ObservableCollection<RqJobNature>();
        }


        public void SendJobRequest()
        {

            _dataservice.AddRequest(request, RequesterInitials, ProjectName,
                $"{EutPartnumber1}; {EutPartnumber2}; {EutPartnumber3}; {EutPartnumber4}; {EutPartnumber5}", ExpectedEndDate,
                $"Gross1: {GrossWeight1}; Gross2: {GrossWeight2}; Gross3: {GrossWeight3}; Gross4: {GrossWeight4}; Gross5: {GrossWeight5}",
                $"Net1: {NetWeight1}; Net2: {NetWeight2}; Net3: {NetWeight3}; Net4: {NetWeight4}; Net5: {NetWeight5}",
                SelectedDivision.Afkorting, SelectedJobNatures.Nature, Batteries_Yes);

            _dataservice.AddOptionel(optionel, request, LinkToTestplan, SpecialRemarks);

            if (_EMC)
            {
               
                createRequestDetail("EMC");
            }
            if (_ENV)
            {
                createRequestDetail("ENV");
            }
            if (_REL)
            {
                createRequestDetail("REL");
            }
            if (_SAFE)
            {
                createRequestDetail("SAFE");
            }
            if (_PACK)
            {
                createRequestDetail("PCK");
            }
            if (_GREEN)
            {

                createRequestDetail("ECO");
            }
            _dataservice.SaveChanges();
            OpenJobRequestWindow();
        }

        private void createRequestDetail(string division)
        {
           var requestDetail = new RqRequestDetail();
           
            _dataservice.AddDetail(requestDetail, request, division);
            
            var eut = new Eut();

            _dataservice.AddEut(eut, requestDetail,
                $"{EUT1Message} ; {EUT2Message} ; {EUT3Message} ; {EUT4Message} ; {EUT5Message} ; {EUT6Message}",
                EUT1Date );
        }

        ///////////////////////////////////////////loadDataIntoCombo///////////////////////////////////////////
        //Koen
        public void insertDivisionIntoComboBox()
        {
            var divisions = _dataservice.getAllDivisions();
            Divisions.Clear();
            foreach (var division in divisions)
            {
                Divisions.Add(division);
            }
        }

        //Koen
        public void insertJobNatureIntoComboBox()
        {
            var jobNatures = _dataservice.getAllJobNatures();
            JobNatures.Clear();
            foreach (var jobNature in jobNatures)
            {
                JobNatures.Add(jobNature);
            }
        }

        public void OpenJobRequestWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Hide();
            ViewJobrequest viewJR = new ViewJobrequest();
            viewJR.Closed += (s, args) => mainWindow.Close();
            viewJR.Show();
        }

    }

}
