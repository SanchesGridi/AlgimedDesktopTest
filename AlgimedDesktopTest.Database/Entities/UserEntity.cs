using AlgimedDesktopTest.Database.Entities.Base;

namespace AlgimedDesktopTest.Database.Entities;

public class UserEntity : IEntityBase<int>
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
}
