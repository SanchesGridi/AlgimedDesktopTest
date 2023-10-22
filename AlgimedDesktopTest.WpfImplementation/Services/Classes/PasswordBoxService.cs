using AlgimedDesktopTest.WpfImplementation.Services.Interfaces;
using System.Windows.Controls;

namespace AlgimedDesktopTest.WpfImplementation.Services.Classes;

public class PasswordBoxService : IPasswordBoxService
{
    public string? GetPassword(object parameter)
    {
        return (parameter as PasswordBox)?.Password;
    }
}
