using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Events;
using Prism.Regions;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class StepItemViewModel : ViewModelBase
{
    public StepItemViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
    {
    }
}
