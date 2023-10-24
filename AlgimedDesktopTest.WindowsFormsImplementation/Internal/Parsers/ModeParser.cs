using AlgimedDesktopTest.Database.Entities;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Internal.Parsers;

public static class ModeParser
{
    public static ModeEntity Parse(Dictionary<string, object> dictionary, int id) // id remove
    {
        var mode = new ModeEntity { Id = id }; // pass old (tracking entity
        foreach (var item in dictionary)
        {
            if (item.Key == nameof(mode.Name))
            {
                mode.Name = item.Value.ToString();
            }
            else if (item.Key == nameof(mode.MaxBottleNumber))
            {
                mode.MaxBottleNumber = (int)item.Value;
            }
            else if (item.Key == nameof(mode.MaxUsedTips))
            {
                mode.MaxUsedTips = (int)item.Value;
            }
            else if (item.Key == nameof(mode.Steps))
            {
                mode.Steps = (ICollection<StepEntity>)item.Value;
            }
        }
        return mode;
    }
}
