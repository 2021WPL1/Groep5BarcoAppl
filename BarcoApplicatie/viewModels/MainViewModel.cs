using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BarcoApplicatie.BibModels;
using BarcoApplication.Data;
using Microsoft.Win32;
using Prism.Commands;

namespace BarcoApplicatie.viewModels
{
    public class MainViewModel : ViewModelBase
    {
        private BarcoApplicationDataService _dataservice;

        public ICommand SendJobRequestCommand { get; set; }

        public ObservableCollection<RqBarcoDivision> Divisions { get; set; }
        public ObservableCollection<RqJobNature> JobNatures { get; set; }

        private RqBarcoDivision _selectedDivision;
        private RqBarcoDivision _selectedJobNatures;

        public RqBarcoDivision SelectedDivision
        {
            get { return _selectedDivision; }
            set
            {
                _selectedDivision = value;
                OnPropertyChanged();
            }
        }
        public RqBarcoDivision SelectedJobNatures
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

        private bool _batteries_No;
        private bool _batteries_Yes;
        public string batteryMessage {get;set;}

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

        public string RequesterInitials
        {
            get
            {
                RegistryKey request = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\BarRequest");
                if (request != null)
                {
                    _requesterInitials = Convert.ToString(request.GetValue("Name"));
                }
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

        public bool Batteries_No
        {
            get
            {
                return _batteries_No;
            }
            set
            {
                if(_batteries_No == value) return;

                _batteries_No = value;
                batteryMessage = _batteries_No ? "No Batteries Inside" : "Batteries Inside";

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
                if(_batteries_Yes == value) return;

                _batteries_Yes = value;
                batteryMessage = _batteries_Yes ? "Batteries Inside" : "No Batteries Inside";

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
                EutPartnumber1, ExpectedEndDate, GrossWeight1,
                NetWeight1, SelectedDivision.Afkorting, SelectedJobNatures.Afkorting);
        }


        ///////////////////////////////////////////loadDataIntoGUI///////////////////////////////////////////
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
