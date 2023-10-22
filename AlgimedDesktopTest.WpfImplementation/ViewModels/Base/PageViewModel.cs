using AlgimedDesktopTest.Shared.Devices.Interfaces;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels.Base;

public abstract class PageViewModel : ViewModelBase, INavigationAware
{
    protected readonly IDeviceService _deviceService;

    public PageViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService,
        IDeviceService deviceService) : base(regionManager, eventAggregator, dialogService)
    {
        _deviceService = deviceService;
    }

    public virtual void OnNavigatedTo(NavigationContext navigationContext)
    {
        ClearSensitiveData();
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public bool IsNavigationTarget(NavigationContext navigationContext) => true;

    protected abstract void ClearSensitiveData();
}
