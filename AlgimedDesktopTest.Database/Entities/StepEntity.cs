using AlgimedDesktopTest.Database.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgimedDesktopTest.Database.Entities;

[Table("Steps")]
public class StepEntity : IEntityBase<int>
{
    public int Id { get; set; }
    public double Timer { get; set; }
    public string? Destination { get; set; }
    public double Speed { get; set; }
    public string? Type { get; set; }
    public double Volume { get; set; }

    [ForeignKey(nameof(Mode))]
    public virtual int ModeId { get; set; }
    public virtual ModeEntity? Mode { get; set; }
}
