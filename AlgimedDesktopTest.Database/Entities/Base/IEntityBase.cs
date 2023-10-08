using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlgimedDesktopTest.Database.Entities.Base;

public interface IEntityBase<TAny>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TAny Id { get; set; }
}