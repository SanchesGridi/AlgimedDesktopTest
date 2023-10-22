using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Shared.Devices.Interfaces;
using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Extensions;
using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Linq;

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
        IDialogService dialogService,
        IDeviceService deviceService) : base(regionManager, eventAggregator, dialogService, deviceService)
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
    }

    private async void SignOutCommandExecute()
    {
        try
        {
            using var context = _application.GetContainer().Resolve<AppDbContext>();
            var user = await context.Users.FindAsync(User!.GetId());
            if (user != null)
            {
                var page = Consts.ViewNames.AuthorizationPage;
                var pageParameter = user.Parameters.FirstOrDefault(x => x.Name == Consts.Keys.PageKey);
                pageParameter!.Value = page;

                context.Parameters.Update(pageParameter);
                await context.SaveChangesAsync();

                _navigation.RegionName = RegionNames.PageRegion;
                _navigation.ViewName = page;
                Navigate();
            }
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }
}
