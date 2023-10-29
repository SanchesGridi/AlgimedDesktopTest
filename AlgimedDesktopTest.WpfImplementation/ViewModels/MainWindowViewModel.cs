using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Shared.Devices.Interfaces;
using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Extensions;
using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Linq;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IDeviceService _deviceService;
    private readonly IMapper _mapper;

    private UserModel? _currentUser;

    private string? _title;
    public string? Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public DelegateCommand WindowLoadedCommand { get; }

    public MainWindowViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService,
        IDeviceService deviceService,
        IMapper mapper) : base(regionManager, eventAggregator, dialogService)
    {
        _deviceService = deviceService;
        _mapper = mapper;

        WindowLoadedCommand = new(WindowLoadedCommandExecute);

        _eventAggregator.GetEvent<WindowTitleEvent>().Subscribe(title => Title = title);
    }

    private async void WindowLoadedCommandExecute()
    {
        // todo:
        // web api project
        try
        {
            var deviceId = _deviceService.GetId();
            using var context = _application.GetContainer().Resolve<AppDbContext>();
            var user = (await context.Parameters.Where(x => x.Name == Consts.Keys.DeviceKey && x.Value == deviceId)
                .OrderByDescending(x => x.User!.LastLoginAt).FirstOrDefaultAsync()
            )?.User;

            var defaultStartPage = Consts.ViewNames.AuthorizationPage;
            if (user != null)
            {
                defaultStartPage = user.Parameters.FirstOrDefault(x => x.Name == Consts.Keys.PageKey)?.Value;
                _currentUser = _mapper.Map<UserModel>(user);
            }

            _navigation.RegionName = RegionNames.PageRegion;
            _navigation.ViewName = defaultStartPage;
            Navigate(defaultStartPage == Consts.ViewNames.ItemsPage ? new() { { Consts.Keys.UserKey, _currentUser } } : null);
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }
}
