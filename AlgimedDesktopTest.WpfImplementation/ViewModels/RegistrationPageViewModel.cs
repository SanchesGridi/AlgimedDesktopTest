using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class RegistrationPageViewModel : PageViewModel
{
    public DelegateCommand SignInCommand { get; set; }

    public RegistrationPageViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService) : base(regionManager, eventAggregator, dialogService)
    {
        SignInCommand = new(SignInCommandExecute);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
        _eventAggregator.GetEvent<WindowTitleEvent>().Publish("Registration");
    }

    private void SignInCommandExecute()
    {
        _navigation.RegionName = RegionNames.PageRegion;
        _navigation.ViewName = Consts.ViewNames.AuthorizationPage;
        Navigate();
    }
}
