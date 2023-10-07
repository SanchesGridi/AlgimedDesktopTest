using Prism.Mvvm;
using System.Windows;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels.Base;

public abstract class ViewModelBase : BindableBase
{
    protected readonly Application _application;

    public ViewModelBase()
    {
        _application = Application.Current;
    }
}
