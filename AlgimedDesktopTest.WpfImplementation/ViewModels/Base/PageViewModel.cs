using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels.Base;

public abstract class PageViewModel : ViewModelBase, INavigationAware
{
    public PageViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService) : base(regionManager, eventAggregator, dialogService)
    {
    }

    public virtual void OnNavigatedTo(NavigationContext navigationContext)
    {
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public bool IsNavigationTarget(NavigationContext navigationContext) => true;
}
