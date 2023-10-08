using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Events;
using Prism.Regions;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class AuthorizationPageViewModel : ViewModelBase
{
    public AuthorizationPageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
    {
    }
}
