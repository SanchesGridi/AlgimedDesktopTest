using AlgimedDesktopTest.WpfImplementation.Enums;

namespace AlgimedDesktopTest.WpfImplementation.Services.Interfaces;

public interface IStartPageOptionService
{
    string GetPageName();
    void Set(StartPageOption option);
}
