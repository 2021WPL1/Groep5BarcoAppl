using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BarcoApplicatie.BibModels;
using BarcoApplication.Data;
using Prism.Commands;

namespace BarcoApplicatie.viewModels
{

    /// <summary>
    /// Koen
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

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

        private bool _EUT1;
        public string EUT1Message {get;set;}
        private bool _EUT2;
        public string EUT2Message {get;set;}
        private bool _EUT3;
        public string EUT3Message {get;set;}
        private bool _EUT4;
        public string EUT4Message {get;set;}
        private bool _EUT5;
        public string EUT5Message {get;set;}
        private bool _EUT6;
        public string EUT6Message {get;set;}

        private bool _EMC;
        public string EMCMessage {get;set;}
        private bool _ENV;
        public string ENVMessage {get;set;}
        private bool _REL;
        public string RELMessage {get;set;}
        private bool _SAFE;
        public string SAFEMessage {get;set;}
        private bool _PACK;
        public string PACKMessage {get;set;}
        private bool _GREEN;
        public string GREENMessage {get;set;}

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

        public bool EUT1
        {
            get
            {
                return _EUT1;
            }
            set
            {
                if(_EUT1 == value) return;

                _EUT1 = value;
                EUT1Message = _EUT1 ? "EUT1" : "";

                OnPropertyChanged();
            }
        }
        public bool EUT2
        {
            get
            {
                return _EUT2;
            }
            set
            {
                if(_EUT2 == value) return;

                _EUT2 = value;
                EUT2Message = _EUT2 ? "EUT2" : "";

                OnPropertyChanged();
            }
        }
        public bool EUT3
        {
            get
            {
                return _EUT3;
            }
            set
            {
                if(_EUT3 == value) return;

                _EUT3 = value;
                EUT3Message = _EUT3 ? "EUT3" : "";

                OnPropertyChanged();
            }
        }
        public bool EUT4
        {
            get
            {
                return _EUT4;
            }
            set
            {
                if(_EUT4 == value) return;

                _EUT4 = value;
                EUT4Message = _EUT4 ? "EUT4" : "";

                OnPropertyChanged();
            }
        }
        public bool EUT5
        {
            get
            {
                return _EUT5;
            }
            set
            {
                if(_EUT5 == value) return;

                _EUT5 = value;
                EUT5Message = _EUT5 ? "EUT5" : "";

                OnPropertyChanged();
            }
        }
        public bool EUT6
        {
            get
            {
                return _EUT6;
            }
            set
            {
                if(_EUT6 == value) return;

                _EUT6 = value;
                EUT6Message = _EUT6 ? "EUT6" : "";

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
                if(_EMC == value) return;

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
                if(_ENV == value) return;

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
                if(_REL == value) return;

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
                if(_SAFE == value) return;

                _SAFE = value;
                SAFEMessage = _SAFE ? "SAFE" : "";

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
                if(_PACK == value) return;

                _PACK = value;
                PACKMessage = _PACK ? "PACK" : "";

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
                if(_GREEN == value) return;

                _GREEN = value;
                GREENMessage = _GREEN ? "GREEN" : "";

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
            _dataservice.SendJobRequest(RequesterInitials, ProjectName,
                $"{EutPartnumber1}; {EutPartnumber2}; {EutPartnumber3}; {EutPartnumber4}; {EutPartnumber5}",
                ExpectedEndDate, $"{GrossWeight1}; {GrossWeight2}; {GrossWeight3}; {GrossWeight4}; {GrossWeight5}",
                $"{NetWeight1}; {NetWeight2}; {NetWeight3}; {NetWeight4}; {NetWeight5}",
                SelectedDivision.Afkorting, SelectedJobNatures.Nature, Batteries_Yes,
                $"{EMCMessage}; {ENVMessage}; {RELMessage}; {SAFEMessage}; {PACKMessage}; {GREENMessage}",
                $"{EUT1Message}; {EUT2Message}; {EUT3Message}; {EUT4Message}; {EUT5Message}; {EUT6Message}; ",
                EUT1Date,EUT2Date, EUT3Date,EUT4Date,EUT5Date,EUT6Date
                );
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

    }

}
