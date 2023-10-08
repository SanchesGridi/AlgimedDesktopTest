using AlgimedDesktopTest.WpfImplementation.Models;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels.Base;

public abstract class ViewModelBase : BindableBase
{
    protected readonly IRegionManager _regionManager;
    protected readonly IEventAggregator _eventAggregator;
    protected readonly Application _application;
    protected NavigationModel _navigation;

    public ViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator)
    {
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
        _application = Application.Current;
        _navigation = new();
    }

    protected virtual void Navigate()
    {
        var region = _navigation.RegionName;
        var view = _navigation.ViewName;
        if (string.IsNullOrWhiteSpace(region) || string.IsNullOrWhiteSpace(view))
        {
            throw new InvalidOperationException();
        }
        else
        {
            _regionManager.RequestNavigate(region, view);
        }
    }
}
