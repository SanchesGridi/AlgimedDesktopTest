using AlgimedDesktopTest.Database.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgimedDesktopTest.Database.Entities;

[Table("Users"), Index(nameof(Login), IsUnique = true, Name = "INDEX_LOGIN_IS_UNIQUE")]
public class UserEntity : IEntityBase<int>
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [StringLength(255)]
    public string? Login { get; set; }
    public string? Password { get; set; }
}
