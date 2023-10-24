using AlgimedDesktopTest.Database.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgimedDesktopTest.Database.Entities;

[Table("Parameters")]
public class ParameterEntity : IBaseEntity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }

    [ForeignKey(nameof(User))]
    public virtual int UserId { get; set; }
    public virtual UserEntity? User { get; set; }
}
