using AlgimedDesktopTest.WpfImplementation.Models.Base;
using System;
using System.Collections.ObjectModel;

namespace AlgimedDesktopTest.WpfImplementation.Models;

public class UserModel : DbEntryModel
{
    private string? _firstName;
    public string? FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    private string? _login;
    public string? Login
    {
        get => _login;
        set => SetProperty(ref _login, value);
    }

    private string? _password;
    public string? Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    private DateTime _createdAt;
    public DateTime CreatedAt
    {
        get => _createdAt;
        set => SetProperty(ref _createdAt, value);
    }

    private ObservableCollection<ParameterModel>? _parameters;
    public ObservableCollection<ParameterModel>? Parameters
    {
        get => _parameters;
        set => SetProperty(ref _parameters, value);
    }

    public UserModel(int id) : base(id)
    {
    }
}
