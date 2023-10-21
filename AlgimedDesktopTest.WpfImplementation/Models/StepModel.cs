using Prism.Mvvm;

namespace AlgimedDesktopTest.WpfImplementation.Models;

public class StepModel : BindableBase
{
    private readonly int _id;

    private double _timer;
    public double Timer
    {
        get => _timer;
        set => SetProperty(ref _timer, value);
    }

    private string? _destination;
    public string? Destination
    {
        get => _destination;
        set => SetProperty(ref _destination, value);
    }

    private double _speed;
    public double Speed
    {
        get => _speed;
        set => SetProperty(ref _speed, value);
    }

    private string? _type;
    public string? Type
    {
        get => _type;
        set => SetProperty(ref _type, value);
    }

    private double _volume;
    public double Volume
    {
        get => _volume;
        set => SetProperty(ref _volume, value);
    }

    public StepModel(int id) => _id = id;

    public int GetId() => _id;
}
