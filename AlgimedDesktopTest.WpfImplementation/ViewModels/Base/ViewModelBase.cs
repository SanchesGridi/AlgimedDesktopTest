using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.Utils;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels.Base;

public abstract class ViewModelBase : BindableBase
{
    protected readonly IRegionManager _regionManager;
    protected readonly IEventAggregator _eventAggregator;
    protected readonly IDialogService _dialogService;
    protected readonly Application _application;
    protected NavigationModel _navigation;

    public ViewModelBase(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService)
    {
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
        _dialogService = dialogService;
        _application = Application.Current;
        _navigation = new();
    }

    protected void ShowExceptionDialog(Exception ex, Action<IDialogResult>? exceptionCallback = null)
    {
        _dialogService.ShowDialog(
            Consts.Dialogs.ExceptionDialog,
            new DialogParameters
            {
                { Consts.Keys.TitleKey, "Error Details" },
                { Consts.Keys.DetailsKey, ex.Message }
            },
            exceptionCallback != null ? exceptionCallback : x => { }
        );
    }

    protected void Navigate(NavigationParameters? parameters = null)
    {
        var region = _navigation.RegionName;
        var view = _navigation.ViewName;
        if (string.IsNullOrWhiteSpace(region) || string.IsNullOrWhiteSpace(view))
        {
            throw new InvalidOperationException();
        }
        else
        {
            _regionManager.RequestNavigate(region, view, parameters);
        }
    }
}
