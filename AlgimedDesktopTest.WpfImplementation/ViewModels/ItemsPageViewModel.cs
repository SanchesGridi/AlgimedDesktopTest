using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class ItemsPageViewModel : PageViewModel
{
    private UserModel? _user;
    public UserModel? User
    {
        get => _user;
        set => SetProperty(ref _user, value);
    }

    public DelegateCommand SignOutCommand { get; }

    public ItemsPageViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService) : base(regionManager, eventAggregator, dialogService)
    {
        SignOutCommand = new(SignOutCommandExecute);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
        _eventAggregator.GetEvent<WindowTitleEvent>().Publish("Items management");
        User = navigationContext.Parameters.GetValue<UserModel>(Consts.Keys.UserKey);
    }

    protected override void ClearSensitiveData()
    {
        User = null;
    }

    private void SignOutCommandExecute()
    {
        _navigation.RegionName = RegionNames.PageRegion;
        _navigation.ViewName = Consts.ViewNames.AuthorizationPage;
        Navigate();
    }
}
