using System.Windows;

namespace AlgimedDesktopTest.WpfImplementation.Services.Interfaces;

public interface IPasswordBoxService
{
    string? GetPassword(object parameter);

    void ClearPassword(DependencyObject view, string name);
}
