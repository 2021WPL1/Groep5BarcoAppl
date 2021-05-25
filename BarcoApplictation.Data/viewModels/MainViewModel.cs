namespace BarcoApplicatie.viewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string requesterInitials;

        public string RequesterInitials
        {
            get { return requesterInitials;}
            set { requesterInitials = value; OnPropertyChanged(); }
        }
    }
}
