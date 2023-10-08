using AlgimedDesktopTest.WpfImplementation.Services.Interfaces;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IStartPageOptionService _startPageOptionService;
        private string _title = "Welcome";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public DelegateCommand WindowLoadedCommand { get; }

        public MainWindowViewModel(
            IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IStartPageOptionService startPageOptionService) : base(regionManager, eventAggregator)
        {
            _startPageOptionService = startPageOptionService;

            WindowLoadedCommand = new DelegateCommand(WindowLoadedCommandExecute);
        }

        private void WindowLoadedCommandExecute()
        {
            _navigation.RegionName = RegionNames.PageRegion;
            _navigation.ViewName = _startPageOptionService.GetPageName();
            Navigate();
        }
    }
}
