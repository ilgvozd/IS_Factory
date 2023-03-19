using System.Windows;

namespace Factory.ViewModels
{
    public class LoginPictureVisibilityViewModel : ViewModelBase
    {
        private Visibility _visibility = Visibility.Hidden;

        public Visibility Visibility
        {
            get => _visibility; 
            set
            {
                _visibility = value;
                OnPropertyChanged(nameof(Visibility));
            }
        }
    }
}