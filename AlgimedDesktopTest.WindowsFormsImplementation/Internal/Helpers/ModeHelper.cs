using AlgimedDesktopTest.Database.Entities;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Internal.Parsers;

public static class ModeHelper
{
    public static ModeEntity UpdateInMemory(Dictionary<string, object> dictionary, ModeEntity mode)
    {
        foreach (var item in dictionary)
        {
            if (item.Key == nameof(mode.Name))
            {
                mode.Name = item.Value.ToString();
            }
            else if (item.Key == nameof(mode.MaxBottleNumber))
            {
                mode.MaxBottleNumber = int.Parse(item.Value.ToString()!);
            }
            else if (item.Key == nameof(mode.MaxUsedTips))
            {
                mode.MaxUsedTips = int.Parse(item.Value.ToString()!);
            }
        }
        return mode;
    }
}
