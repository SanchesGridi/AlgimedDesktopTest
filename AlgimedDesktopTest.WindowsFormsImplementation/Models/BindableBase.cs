using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Models;

public abstract class BindableBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void RaisePropertyChanged([CallerMemberName]string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected void SetProperty<TAny>(ref TAny field,  TAny value, [CallerMemberName]string? propertyName = null)
    {
        field = value;
        RaisePropertyChanged(propertyName);
    }
}
