using AlgimedDesktopTest.Database.Entities.Base;
using AlgimedDesktopTest.Database.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgimedDesktopTest.Database.Entities;

[Table(Db.Modes)]
public class ModeEntity : IBaseEntity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int MaxBottleNumber { get; set; }
    public int MaxUsedTips { get; set; }

    public virtual ICollection<StepEntity> Steps { get; set; } = new List<StepEntity>();
}
