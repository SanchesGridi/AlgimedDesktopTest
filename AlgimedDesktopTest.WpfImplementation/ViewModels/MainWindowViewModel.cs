using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title = "Main Window";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel()
        {

        }
    }
}
