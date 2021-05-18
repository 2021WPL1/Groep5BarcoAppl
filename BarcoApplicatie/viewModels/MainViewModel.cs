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

        public ObservableCollection<RqBarcoDivision> Divisions { get; set; }
        public ObservableCollection<RqJobNature> JobNatures { get; set; }

        private string _requesterInitials;

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

        public MainViewModel(BarcoApplicationDataService dataService)
        {
            this._dataservice = dataService;

            SendJobRequestCommand = new DelegateCommand(SendJobRequest);


            Divisions = new ObservableCollection<RqBarcoDivision>();
            JobNatures = new ObservableCollection<RqJobNature>();
        }

        private void SendJobRequest()
        {
            MessageBox.Show(RequesterInitials);
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
