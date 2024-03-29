﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BarcoApplication.Data;
using Microsoft.Win32;
using BarcoApplication.Data.BibModels;
using Prism.Commands;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.Net.Mail;
using System.Net;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace BarcoApplicatie.viewModels
{
    /// <summary>
    /// Koen
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private RqRequest request = new RqRequest();
        private RqOptionel optionel = new RqOptionel();
        private BarcoApplicationDataService _dataservice;

        public ObservableCollection<RqBarcoDivision> Divisions { get; set; }

        public ObservableCollection<RqJobNature> JobNatures { get; set; }

        public MainViewModel(BarcoApplicationDataService dataService)
        {
            this._dataservice = dataService;

            SendJobRequestCommand = new DelegateCommand(SendJobRequest);

            HomeCommand = new RelayCommand<Window>(ShowHome);
            AddCommand = new RelayCommand<Window>(ShowAdd);
            ConfirmCommand = new RelayCommand<Window>(ShowConfirm);
            ViewCommand = new RelayCommand<Window>(ShowView);

            Divisions = new ObservableCollection<RqBarcoDivision>();
            JobNatures = new ObservableCollection<RqJobNature>();
        }

        ///////////////////////////////////////////Registry///////////////////////////////////////////
        //Robbe
        private string _registryDivision { get; set; }
        public string RegistryDivision
        {
            get
            {
                //Robbe
                string name = "";
                //Naam opvragen uit register
                RegistryKey request = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\BarRequest");

                if (request != null)
                {
                    name = Convert.ToString(request.GetValue("Division"));
                }
                _registryDivision = name;

                return _registryDivision;
            }
            set
            {
                _registryDivision = value;
                OnPropertyChanged();
            }
        }

        ///////////////////////////////////////////Getters&Setters///////////////////////////////////////////
        //Koen
        public ImageSource ImageBarco
        {
            get { return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png")); }
        }

        private RqBarcoDivision _selectedDivision;
        private RqJobNature _selectedJobNatures;

        public RqBarcoDivision SelectedDivision
        {
            get
            {

                return _selectedDivision;
            }
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
        private bool _batteries_No;

        public string EmcEUT1Message { get; set; }
        public string EmcEUT2Message { get; set; }
        public string EmcEUT3Message { get; set; }
        public string EmcEUT4Message { get; set; }
        public string EmcEUT5Message { get; set; }
        public string EmcEUT6Message { get; set; }

        public string EnvEUT1Message { get; set; }
        public string EnvEUT2Message { get; set; }
        public string EnvEUT3Message { get; set; }
        public string EnvEUT4Message { get; set; }
        public string EnvEUT5Message { get; set; }
        public string EnvEUT6Message { get; set; }

        public string RelEUT1Message { get; set; }
        public string RelEUT2Message { get; set; }
        public string RelEUT3Message { get; set; }
        public string RelEUT4Message { get; set; }
        public string RelEUT5Message { get; set; }
        public string RelEUT6Message { get; set; }

        public string SafeEUT1Message { get; set; }
        public string SafeEUT2Message { get; set; }
        public string SafeEUT3Message { get; set; }
        public string SafeEUT4Message { get; set; }
        public string SafeEUT5Message { get; set; }
        public string SafeEUT6Message { get; set; }

        public string PackEUT1Message { get; set; }
        public string PackEUT2Message { get; set; }
        public string PackEUT3Message { get; set; }
        public string PackEUT4Message { get; set; }
        public string PackEUT5Message { get; set; }
        public string PackEUT6Message { get; set; }

        public string GreenEUT1Message { get; set; }
        public string GreenEUT2Message { get; set; }
        public string GreenEUT3Message { get; set; }
        public string GreenEUT4Message { get; set; }
        public string GreenEUT5Message { get; set; }
        public string GreenEUT6Message { get; set; }

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
                //Robbe
                string name = "";
                //Naam opvragen uit register
                RegistryKey request = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\BarRequest");

                if (request != null)
                {
                    name = Convert.ToString(request.GetValue("Name"));
                }

                //initialen maken van de volledige naam
                string[] nameSplit = name.Trim().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                var initials = nameSplit[0].Substring(0, 1).ToUpper();

                if (nameSplit.Length > 1)
                {
                    initials += nameSplit[nameSplit.Length - 1].Substring(0, 1).ToUpper();
                }
                _requesterInitials = initials;

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
                EmcEUT1Message = _EmcEUT1 ? "EUT1" : "";

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
                EmcEUT2Message = _EmcEUT2 ? "EUT2" : "";

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
                EmcEUT3Message = _EmcEUT3 ? "EUT3" : "";

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
                EmcEUT4Message = _EmcEUT4 ? "EUT4" : "";

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
                EmcEUT5Message = _EmcEUT5 ? "EUT5" : "";

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
                EmcEUT6Message = _EmcEUT6 ? "EUT6" : "";

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
                EnvEUT1Message = _EnvEUT1 ? "EUT1" : "";

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
                EnvEUT2Message = _EnvEUT2 ? "EUT2" : "";

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
                EnvEUT3Message = _EnvEUT3 ? "EUT3" : "";

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
                EnvEUT4Message = _EnvEUT4 ? "EUT4" : "";

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
                EnvEUT5Message = _EnvEUT5 ? "EUT5" : "";

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
                EnvEUT6Message = _EnvEUT6 ? "EUT6" : "";

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
                RelEUT1Message = _RelEUT1 ? "EUT1" : "";

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
                RelEUT2Message = _RelEUT2 ? "EUT2" : "";

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
                RelEUT3Message = _RelEUT3 ? "EUT3" : "";

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
                RelEUT4Message = _RelEUT4 ? "EUT4" : "";

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
                RelEUT5Message = _RelEUT5 ? "EUT5" : "";

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
                RelEUT6Message = _RelEUT6 ? "EUT6" : "";

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
                SafeEUT1Message = _SafeEUT1 ? "EUT1" : "";

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
                SafeEUT2Message = _SafeEUT2 ? "EUT2" : "";

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
                SafeEUT3Message = _SafeEUT3 ? "EUT3" : "";

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
                SafeEUT4Message = _SafeEUT4 ? "EUT4" : "";

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
                SafeEUT5Message = _SafeEUT5 ? "EUT5" : "";

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
                SafeEUT6Message = _SafeEUT6 ? "EUT6" : "";

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
                PackEUT1Message = _PackEUT1 ? "EUT1" : "";

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
                PackEUT2Message = _PackEUT2 ? "EUT2" : "";

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
                PackEUT3Message = _PackEUT3 ? "EUT3" : "";

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
                PackEUT4Message = _PackEUT4 ? "EUT4" : "";

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
                PackEUT5Message = _PackEUT5 ? "EUT5" : "";

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
                PackEUT6Message = _PackEUT6 ? "EUT6" : "";

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
                GreenEUT1Message = _GreenEUT1 ? "EUT1" : "";

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
                GreenEUT2Message = _GreenEUT2 ? "EUT2" : "";

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
                GreenEUT3Message = _GreenEUT3 ? "EUT3" : "";

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
                GreenEUT4Message = _GreenEUT4 ? "EUT4" : "";

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
                GreenEUT5Message = _GreenEUT5 ? "EUT5" : "";

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
                GreenEUT6Message = _GreenEUT6 ? "EUT6" : "";

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

        public void SendJobRequest()
        {
            _dataservice.AddRequest(
                request,
                RequesterInitials,
                ProjectName,
                ProjectNumber,
                $"Part1: {EutPartnumber1}       " +
                $" Part2:  {EutPartnumber2}       " +
                $" Part3:  {EutPartnumber3}       " +
                $" Part4:  {EutPartnumber4}       " +
                $" Part5:  {EutPartnumber5}",
                ExpectedEndDate,
                $"Gross1:  {GrossWeight1}       " +
                $" Gross2:  {GrossWeight2}       " +
                $" Gross3:  {GrossWeight3}       " +
                $" Gross4:  {GrossWeight4}       " +
                $" Gross5:  {GrossWeight5}",
                $"Net1:  {NetWeight1}       " +
                $" Net2:  {NetWeight2}       " +
                $" Net3:  {NetWeight3}       " +
                $" Net4:  {NetWeight4}       " +
                $" Net5:  {NetWeight5}",
                RegistryDivision,
                SelectedJobNatures.Nature,
                Batteries_Yes);

            _dataservice.AddOptionel(optionel, request, LinkToTestplan, SpecialRemarks);

            if (_EMC)
            {
                if (EmcEUT1 || EmcEUT2 || EmcEUT3 || EmcEUT4 || EmcEUT5 || EmcEUT6)
                {
                    CreateRequestDetail("EMC", 
                        $"{EmcEUT1Message}" +
                        $"         {EmcEUT2Message} " +
                        $"         {EmcEUT3Message} " +
                        $"         {EmcEUT4Message} " +
                        $"         {EmcEUT5Message} " +
                        $"         {EmcEUT6Message} ",
                        EUT1Date);
                }
            }
            if (_ENV)
            {
                if (EnvEUT1 || EnvEUT2|| EnvEUT3 || EnvEUT4 || EnvEUT5 || EnvEUT6)
                {
                    CreateRequestDetail("ENV", 
                        $"{EnvEUT1Message}" +
                        $"   {EnvEUT2Message} " +
                        $"   {EnvEUT3Message} " +
                        $"   {EnvEUT4Message} " +
                        $"   {EnvEUT5Message} " +
                        $"   {EnvEUT6Message} ",
                        EUT2Date);
                }
            }
            if (_REL)
            {
                if (RelEUT1 || RelEUT2|| RelEUT3 || RelEUT4 || RelEUT5 || RelEUT6)
                {
                    CreateRequestDetail("REL", 
                        $"{RelEUT1Message} " +
                        $"   {RelEUT2Message} " +
                        $"   {RelEUT3Message} " +
                        $"   {RelEUT4Message} " +
                        $"   {RelEUT5Message} " +
                        $"   {RelEUT6Message} ",
                        EUT3Date);
                }
            }
            if (_SAFE)
            {
                if (SafeEUT1 || SafeEUT2|| SafeEUT3 || SafeEUT4 || SafeEUT5 || SafeEUT6)
                {
                    CreateRequestDetail("SAF", 
                        $"{SafeEUT1Message} " +
                        $"   {SafeEUT2Message} " +
                        $"   {SafeEUT3Message} " +
                        $"   {SafeEUT4Message} " +
                        $"   {SafeEUT5Message} " +
                        $"   {SafeEUT6Message} ",
                        EUT4Date);
                }
            }
            if (_PACK)
            {
                if (PackEUT1 || PackEUT2|| PackEUT3 || PackEUT4 || PackEUT5 || PackEUT6)
                {
                    CreateRequestDetail("PCK", 
                        $"{PackEUT1Message} " +
                        $"   {PackEUT2Message} " +
                        $"   {PackEUT3Message} " +
                        $"   {PackEUT4Message} " +
                        $"   {PackEUT5Message} " +
                        $"   {PackEUT6Message} ",
                        EUT5Date);
                }
            }
            if (_GREEN)
            {
                if (GreenEUT1 || GreenEUT2|| GreenEUT3 || GreenEUT4 || GreenEUT5 || GreenEUT6)
                {
                    CreateRequestDetail("ECO", 
                        $"{GreenEUT1Message} " +
                        $"   {GreenEUT2Message} " +
                        $"   {GreenEUT3Message} " +
                        $"   {GreenEUT4Message} " +
                        $"   {GreenEUT5Message} " +
                        $"   {GreenEUT6Message} ",
                        EUT6Date);
                }
            }
            _dataservice.SaveChanges();
            OpenJobRequestWindow();
        }

        private void CreateRequestDetail(string division, string eutMessage, DateTime date)
        {
            var requestDetail = new RqRequestDetail();
            _dataservice.AddDetail(requestDetail, request, division);

            var eut = new Eut();
            _dataservice.AddEut(eut, requestDetail, eutMessage, date);
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
            HomeScreen homescreen = new HomeScreen();
            homescreen.Closed += (s, args) => mainWindow.Close();
            homescreen.Show();
        }

        ///////////////////////////////////////////Commands///////////////////////////////////////////
        //Mathias & Nikki
        public ICommand SendJobRequestCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand ViewCommand { get; set; }

        public void ShowHome(Window window)
        {
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Show();
            if (window != null)
            {
                window.Close();
            }
        }
        public void ShowAdd(Window window)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            if (window != null)
            {
                window.Close();
            }
        }
        public void ShowConfirm(Window window)
        {
            ViewAcceptJobrequest viewAcceptJobrequest = new ViewAcceptJobrequest();
            viewAcceptJobrequest.Show();
            if (window != null)
            {
                window.Close();
            }
        }
        public void ShowView(Window window)
        {
            ViewJobrequest viewJobrequest = new ViewJobrequest();
            viewJobrequest.Show();
            if (window != null)
            {
                window.Close();
            }
        }

        ///////////////////////////////////////////Email///////////////////////////////////////////
        //Nikki

        //initialise for SendMail
        private static string mailFrom = "Groep3testprog@gmail.com";
        private static string mailFromPassword = "Testtest123";


        public void ActivateEmail()
        {
            //_dataService = BarcoApplicationDataService.Instance();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //Date kan aangepast worden naar keuze
            DateTime emailSendTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 17, 0); //18pm,0min,0sec
            DateTime dateNow = DateTime.Now;

            if (_dataservice.getAllRequests() != null)
            {
                //geen mail op zaterdag & zondag
                if (dateNow.DayOfWeek != DayOfWeek.Saturday || dateNow.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (emailSendTime.Hour == dateNow.Hour && emailSendTime.Minute == dateNow.Minute)
                    {
                        SendMail();
                    }
                }
            }

        }
        private void SendMail()
        {
            //setup smtp & mail 
            using SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            try
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mailFrom, mailFromPassword);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(mailFrom);
                mail.To.Add("nikki.noppe@student.vives.be");

                //needs to be updated with info!
                mail.Subject = "testtesttes";
                mail.Body = "Dit is een automatische mail";

                client.Send(mail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///////////////////////////////////////////Errorhandling///////////////////////////////////////////
        //Nikki
        public void ControlInput(string canBe, TextBox box, Label label, string content)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(box.Text, canBe))
            {
                label.Content = content;
                box.Text = box.Text.Remove(box.Text.Length - 1);
            }
        }

        //Check if checkbox is empty for datePicker
        public void dateEmpty(DatePicker DateEut, CheckBox cbEmcEut, CheckBox cbEnviromental, CheckBox cbReliability, CheckBox cbProductSafety, CheckBox cbPackaging, CheckBox cbGreenCompilance)
        {
            if (cbEmcEut.IsChecked == false && cbEnviromental.IsChecked == false && cbReliability.IsChecked == false && cbProductSafety.IsChecked == false && cbPackaging.IsChecked == false && cbGreenCompilance.IsChecked == false)
            {
                DateEut.IsEnabled = false;
            }
            else
            {
                DateEut.IsEnabled = true;
            }
        }

        //Check if text is empty
        public void EmptyTextBox(TextBox txtname, string text, Label label)
        {
            if (txtname.Text.Length == 0)
            {
                label.Content = "Please fill in " + text;
            }
            else
            {
                label.Content = "";
            }

        }
        public void EmptyComboBox(ComboBox cmbname, string text, Label label)
        {
            if (cmbname.SelectedIndex == -1)
            {
                label.Content = "Please fill in " + text;
            }
            else
            {
                label.Content = "";
            }
        }
    }
}