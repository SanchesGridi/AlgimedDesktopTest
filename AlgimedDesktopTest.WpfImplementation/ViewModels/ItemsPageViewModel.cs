using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class ItemsPageViewModel : ViewModelBase
{
    public ItemsPageViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService) : base(regionManager, eventAggregator, dialogService)
    {
    }
}
