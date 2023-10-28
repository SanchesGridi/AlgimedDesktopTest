using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.Database.Entities.Base;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Utils;

public static class EntityHelper
{
    public static TEntity? UpdateInMemory<TEntity>(Dictionary<string, object> dictionary, TEntity entity)
        where TEntity : class, IBaseEntity<int>
    {
        if (entity is ModeEntity mode)
        {
            return UpdateInMemory(dictionary, mode) as TEntity;
        }
        else if (entity is StepEntity step)
        {
            return UpdateInMemory(dictionary, step) as TEntity;
        }
        else
        {
            throw new InvalidOperationException($"Not recognizable entity type: [{entity.GetType().Name}]");
        }
    }

    private static ModeEntity UpdateInMemory(Dictionary<string, object> dictionary, ModeEntity mode)
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

    private static StepEntity UpdateInMemory(Dictionary<string, object> dictionary, StepEntity step)
    {
        foreach (var item in dictionary)
        {
            if (item.Key == nameof(step.Timer))
            {
                step.Timer = double.Parse(item.Value.ToString()!);
            }
            else if (item.Key == nameof(step.Destination))
            {
                step.Destination = item.Value.ToString();
            }
            else if (item.Key == nameof(step.Speed))
            {
                step.Speed = double.Parse(item.Value.ToString()!);
            }
            else if (item.Key == nameof(step.Type))
            {
                step.Type = item.Value.ToString();
            }
            else if (item.Key == nameof(step.Volume))
            {
                step.Volume = double.Parse(item.Value.ToString()!);
            }
            else if (item.Key == nameof(step.ModeId))
            {
                step.ModeId = int.Parse(item.Value.ToString()!);
            }
        }
        return step;
    }
}
