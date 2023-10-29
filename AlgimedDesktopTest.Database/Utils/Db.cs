using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AlgimedDesktopTest.Database.Utils;

public static class Db
{
    public const string Modes = nameof(Modes);
    public const string Steps = nameof(Steps);
    public const string ConnectionString = "Data Source=algimed_test_task.db";

    public static readonly string[] ModeHeaders = new[] { "ID", "Name", "MaxBottleNumber", "MaxUsedTips" };
    public static readonly string[] StepHeaders = new[] { "ID", "ModeId", "Timer", "Destination", "Speed", "Type", "Volume" };

    public static ModeEntity ModeMapper(DataRow row) =>
        new()
        {
            Id = int.Parse(row["ID"].ToString()!),
            Name = row["Name"].ToString(),
            MaxBottleNumber = int.Parse(row["MaxBottleNumber"].ToString()!),
            MaxUsedTips = int.Parse(row["MaxUsedTips"].ToString()!)
        };

    public static StepEntity StepMapper(DataRow row) =>
        new()
        {
            Id = int.Parse(row["ID"].ToString()!),
            ModeId = int.Parse(row["ModeId"].ToString()!),
            Type = row["Type"].ToString(),
            Destination = row["Destination"].ToString(),
            Speed = row.Field<double>("Speed"),
            Timer = row.Field<double>("Timer"),
            Volume = row.Field<double>("Volume")
        };

    public static bool RowValidator(DataRow row) =>
        !string.IsNullOrWhiteSpace(row["Id"].ToString());

    public static class ContextWrapper
    {
        public static async Task SaveModesAsync(AppDbContext context, List<ModeEntity> modes)
        {
            var modeIds = await context.Modes.Select(x => x.Id).ToListAsync();
            foreach (var mode in modes)
            {
                if (modeIds.Contains(mode.Id))
                {
                    var existingMode = await context.Modes.FirstOrDefaultAsync(x => x.Id == mode.Id);
                    existingMode!.Name = mode.Name;
                    existingMode!.MaxBottleNumber = mode.MaxBottleNumber;
                    existingMode!.MaxUsedTips = mode.MaxUsedTips;

                    context.Modes.Update(existingMode);
                }
                else
                {
                    context.Modes.Add(mode);
                }
            }
            await context.SaveChangesAsync();
        }

        public static async Task SaveStepsAsync(AppDbContext context, List<StepEntity> steps)
        {
            var stepIds = await context.Steps.Select(x => x.Id).ToListAsync();
            foreach (var step in steps)
            {
                if (stepIds.Contains(step.Id))
                {
                    var existingStep = await context.Steps.FirstOrDefaultAsync(x => x.Id == step.Id);
                    existingStep!.ModeId = step.ModeId;
                    existingStep!.Type = step.Type;
                    existingStep!.Destination = step.Destination;
                    existingStep!.Speed = step.Speed;
                    existingStep!.Timer = step.Timer;
                    existingStep!.Volume = step.Volume;

                    context.Steps.Update(existingStep);
                }
                else
                {
                    context.Steps.Add(step);
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
