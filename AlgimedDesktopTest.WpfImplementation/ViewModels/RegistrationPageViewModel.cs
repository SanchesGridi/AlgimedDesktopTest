using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Extensions;
using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.Services.Interfaces;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using AutoMapper;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Linq;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class RegistrationPageViewModel : PageViewModel
{
    private const string TitleName = "Registration";
    private const string PasswordExceptionMessage = "Check passwords please!";
    private const string LoginExceptionMessage = "This login is already taken!";
    private const string PasswordControlName = "p_password_box";
    private const string ConfirmPasswordControlName = "cp_password_box";
    private const int NewUserId = 0;

    private readonly IPasswordBoxService _passwordBoxService;
    private readonly IMapper _mapper;

    private string? _password;
    private string? _confirmPassword;

    private UserModel? _user;
    public UserModel? User
    {
        get => _user ??= new(NewUserId);
        set => SetProperty(ref _user, value);
    }

    public DelegateCommand SignInCommand { get; }
    public DelegateCommand<object> PasswordChangedCommand { get; }
    public DelegateCommand<object> ConfirmPasswordChangedCommand { get; }
    public DelegateCommand SignUpCommand { get; }

    public RegistrationPageViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService,
        IPasswordBoxService passwordBoxService,
        IMapper mapper) : base(regionManager, eventAggregator, dialogService)
    {
        _passwordBoxService = passwordBoxService;
        _mapper = mapper;

        SignInCommand = new(SignInCommandExecute);
        PasswordChangedCommand = new(PasswordChangedCommandExecute);
        ConfirmPasswordChangedCommand = new(ConfirmPasswordChangedCommandExecute);
        SignUpCommand = new(SignUpCommandExecute);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
        _eventAggregator.GetEvent<WindowTitleEvent>().Publish(TitleName);
    }

    protected override void ClearSensitiveData()
    {
        User = null;
        _password = null;
        _confirmPassword = null;
        _passwordBoxService.ClearPassword(_application.MainWindow, PasswordControlName);
        _passwordBoxService.ClearPassword(_application.MainWindow, ConfirmPasswordControlName);
    }

    private void SignInCommandExecute()
    {
        _navigation.RegionName = RegionNames.PageRegion;
        _navigation.ViewName = Consts.ViewNames.AuthorizationPage;
        Navigate();
    }

    private void PasswordChangedCommandExecute(object parameter)
    {
        _password = _passwordBoxService.GetPassword(parameter);
    }

    private void ConfirmPasswordChangedCommandExecute(object parameter)
    {
        _confirmPassword = _passwordBoxService.GetPassword(parameter);
    }

    private async void SignUpCommandExecute()
    {
        try
        {
            // todo: web api
            using var context = _application.GetContainer().Resolve<AppDbContext>();

            var uShallNotPass = string.IsNullOrWhiteSpace(_password) && string.IsNullOrWhiteSpace(_confirmPassword);
            if (_password != _confirmPassword || uShallNotPass)
            {
                throw new InvalidOperationException(PasswordExceptionMessage);
            }
            else if (context.Users.Select(x => x.Login).Contains(User!.Login))
            {
                throw new InvalidOperationException(LoginExceptionMessage);
            }
            else
            {
                User!.Password = _password;

                await context.Users.AddAsync(_mapper.Map<UserEntity>(User));
                await context.SaveChangesAsync();

                _navigation.RegionName = RegionNames.PageRegion;
                _navigation.ViewName = Consts.ViewNames.AuthorizationPage;
                Navigate();
            }
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }
}
