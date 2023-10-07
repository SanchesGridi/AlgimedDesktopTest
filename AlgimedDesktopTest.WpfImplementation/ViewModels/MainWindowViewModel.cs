using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Regions;
using System;

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

        public DelegateCommand<string> NavigateCommand { get; }

        public MainWindowViewModel(IRegionManager regionManager) : base(regionManager)
        {
            NavigateCommand = new DelegateCommand<string>(NavigateCommandExecute);
        }

        private void NavigateCommandExecute(string navigationPath)
        {
            if (string.IsNullOrWhiteSpace(navigationPath))
            {
                throw new ArgumentException();
            }
            else
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
            }
        }
    }
}
