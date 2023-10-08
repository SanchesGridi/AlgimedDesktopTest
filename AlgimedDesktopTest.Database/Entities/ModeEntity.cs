using AlgimedDesktopTest.Database.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgimedDesktopTest.Database.Entities;

[Table("Modes")]
public class ModeEntity : IEntityBase<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int MaxBottleNumber { get; set; }
    public int MaxUsedTips { get; set; }

    public virtual ICollection<StepEntity> Steps { get; set; } = new List<StepEntity>();
}
