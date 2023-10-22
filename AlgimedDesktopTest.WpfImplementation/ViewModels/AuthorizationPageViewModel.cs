using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Extensions;
using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.Services.Interfaces;
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

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class AuthorizationPageViewModel : PageViewModel
{
    private const string TitleName = "Authorization";
    private const string ExceptionMessage = "Invalid login data!";
    private const string ControlName = "authorization_password_box";

    private readonly IPasswordBoxService _passwordBoxService;
    private readonly IMapper _mapper;

    private string? _password;

    private string? _login;
    public string? Login
    {
        get => _login;
        set => SetProperty(ref _login, value);
    }

    public DelegateCommand SignUpCommand { get; }
    public DelegateCommand<object> PasswordChangedCommand { get; }
    public DelegateCommand SignInCommand { get; }

    public AuthorizationPageViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService,
        IPasswordBoxService passwordBoxService,
        IMapper mapper) : base(regionManager, eventAggregator, dialogService)
    {
        _passwordBoxService = passwordBoxService;
        _mapper = mapper;

        SignUpCommand = new(SignUpCommandExecute);
        PasswordChangedCommand = new(PasswordChangedCommandExecute);
        SignInCommand = new(SignInCommandExecute);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
        _eventAggregator.GetEvent<WindowTitleEvent>().Publish(TitleName);
    }

    protected override void ClearSensitiveData()
    {
        Login = null;
        _password = null;
        _passwordBoxService.ClearPassword(_application.MainWindow, ControlName);
    }

    private void SignUpCommandExecute()
    {
        _navigation.RegionName = RegionNames.PageRegion;
        _navigation.ViewName = Consts.ViewNames.RegistrationPage;
        Navigate();
    }

    private void PasswordChangedCommandExecute(object parameter)
    {
        _password = _passwordBoxService.GetPassword(parameter);
    }

    private async void SignInCommandExecute()
    {
        try
        {
            // todo: web api
            using var context = _application.GetContainer().Resolve<AppDbContext>();
            var entity = await context.Users.FirstOrDefaultAsync(x => x.Login == Login && x.Password == _password)
                ?? throw new InvalidOperationException(ExceptionMessage);
            var model = _mapper.Map<UserModel>(entity);

            _navigation.RegionName = RegionNames.PageRegion;
            _navigation.ViewName = Consts.ViewNames.ItemsPage;
            Navigate(new() { { Consts.Keys.UserKey, model } });
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }
}
