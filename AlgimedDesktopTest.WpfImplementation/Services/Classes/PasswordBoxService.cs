using AlgimedDesktopTest.WpfImplementation.Services.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AlgimedDesktopTest.WpfImplementation.Services.Classes;

public class PasswordBoxService : IPasswordBoxService
{
    public string? GetPassword(object parameter)
    {
        return (parameter as PasswordBox)?.Password;
    }

    public void ClearPassword(DependencyObject view, string name)
    {
        (LogicalTreeHelper.FindLogicalNode(view, name) as PasswordBox)?.Clear();
    }
}
