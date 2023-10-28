﻿namespace AlgimedDesktopTest.WindowsFormsImplementation.Models;

public class ModeModel : BindableBase
{
    private string? _name;
    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private int _maxBottleNumber;
    public int MaxBottleNumber
    {
        get => _maxBottleNumber;
        set => SetProperty(ref _maxBottleNumber, value);
    }

    private int _maxUsedTips;
    public int MaxUsedTips
    {
        get => _maxUsedTips;
        set => SetProperty(ref _maxUsedTips, value);
    }
}
