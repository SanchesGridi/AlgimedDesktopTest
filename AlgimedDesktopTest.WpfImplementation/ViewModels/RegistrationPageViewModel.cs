using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Events;
using Prism.Regions;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class RegistrationPageViewModel : ViewModelBase
{
    public RegistrationPageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
    {
    }
}
