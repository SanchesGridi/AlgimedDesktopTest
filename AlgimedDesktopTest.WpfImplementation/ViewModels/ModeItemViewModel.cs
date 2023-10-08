using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Events;
using Prism.Regions;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class ModeItemViewModel : ViewModelBase
{
    public ModeItemViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
    {
    }
}
