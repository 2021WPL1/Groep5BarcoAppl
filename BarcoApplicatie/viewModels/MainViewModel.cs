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
    public class MainViewModel : ViewModelBase
    {
        private BarcoApplicationDataService _dataservice;

        public ICommand SendJobRequestCommand { get; set; }

        private ObservableCollection<RqBarcoDivision> _divisions { get; set; }
        private ObservableCollection<RqJobNature> _jobNatures { get; set; }

        private string _requesterInitials;

        private string _projectNumber;

        private string _projectName;

        private string _linkToTestplan;

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

        private bool _batteries_No;
        private bool _batteries_Yes;
        private const string NoBatteries = "No batteries inside";
        private const string YesBatteries = "batteries inside";
        public string MyBoundMessage {get;set;}

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
                MyBoundMessage = _batteries_No ? NoBatteries : YesBatteries;

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
                MyBoundMessage = _batteries_Yes ? YesBatteries : NoBatteries;

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

        public MainViewModel(BarcoApplicationDataService dataService)
        {
            this._dataservice = dataService;

            SendJobRequestCommand = new DelegateCommand(SendJobRequest);


            _divisions = new ObservableCollection<RqBarcoDivision>();
            _jobNatures = new ObservableCollection<RqJobNature>();
        }

        private void SendJobRequest()
        {
            MessageBox.Show(LinkToTestplan);
        }


        ///////////////////////////////////////////loadDataIntoGUI///////////////////////////////////////////
        //Koen
        public void insertDivisionIntoComboBox(ComboBox comboBox)
        {
            var divisions = _dataservice.getAllDivisions();

            foreach (var division in divisions)
            {
                comboBox.Items.Add(division.Afkorting);
            }
        }

        //Koen
        public void insertJobNatureIntoComboBox(ComboBox comboBox)
        {
            var jobNatures = _dataservice.getAllJobNatures();

            foreach (var jobNature in jobNatures)
            {
                comboBox.Items.Add(jobNature.Nature);
            }
        }
    }

}
