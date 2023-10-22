using AlgimedDesktopTest.WpfImplementation.Models.Base;

namespace AlgimedDesktopTest.WpfImplementation.Models;

public class ParameterModel : DbEntryModel
{
    private string? _name;
    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private string? _value;
    public string? Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }

    private int _userId;
    public int UserId
    {
        get => _userId;
        set => SetProperty(ref _userId, value);
    }

    public ParameterModel(int id) : base(id)
    {
    }
}
