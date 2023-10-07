using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels.Base;

public abstract class ViewModelBase : BindableBase
{
    protected readonly IRegionManager _regionManager;
    protected readonly Application _application;

    public ViewModelBase(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        _application = Application.Current;
    }
}
