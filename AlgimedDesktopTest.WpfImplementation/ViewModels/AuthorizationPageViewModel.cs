using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class AuthorizationPageViewModel : PageViewModel
{
    public DelegateCommand SignUpCommand { get; set; }

    public AuthorizationPageViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService) : base(regionManager, eventAggregator, dialogService)
    {
        SignUpCommand = new(SignUpCommandExecute);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
        _eventAggregator.GetEvent<WindowTitleEvent>().Publish("Authorization");
    }

    private void SignUpCommandExecute()
    {
        _navigation.RegionName = RegionNames.PageRegion;
        _navigation.ViewName = Consts.ViewNames.RegistrationPage;
        Navigate();
    }
}
