using AlgimedDesktopTest.WpfImplementation.Enums;
using AlgimedDesktopTest.WpfImplementation.Services.Interfaces;
using System;

namespace AlgimedDesktopTest.WpfImplementation.Services.Classes;

public class StartPageOptionService : IStartPageOptionService
{
    private StartPageOption _option;

    public StartPageOptionService()
    {
        _option = StartPageOption.Registration;
    }

    public string GetPageName()
    {
        return $"{_option}Page";
    }

    public void Set(StartPageOption option)
    {
        switch (option)
        {
            case StartPageOption.Registration:
            case StartPageOption.Authorization:
            case StartPageOption.Items:
                _option = option;
                break;
            default:
                throw new ArgumentException($"Invalid [{nameof(StartPageOption)}] enum type, value: [{(int)option}]");
        }
    }
}
