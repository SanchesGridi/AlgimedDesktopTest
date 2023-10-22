using AlgimedDesktopTest.Shared.Devices.Interfaces;
using DeviceId;

namespace AlgimedDesktopTest.Shared.Devices.Classes;

public class DeviceService : IDeviceService
{
    private readonly DeviceIdBuilder _builder = new();

    public string GetId()
    {
        return _builder.AddMachineName().AddOsVersion().OnWindows(
            windows => windows.AddProcessorId().AddMotherboardSerialNumber().AddSystemDriveSerialNumber()
        ).ToString();
    }
}