using AlgimedDesktopTest.WpfImplementation.Models.Base;

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

    public UserModel(int id) : base(id)
    {
    }
}
