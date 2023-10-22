using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WpfImplementation.Mapper.Profiles.Base;
using AlgimedDesktopTest.WpfImplementation.Models;

namespace AlgimedDesktopTest.WpfImplementation.Mapper.Profiles;

public class UserProfile : DbEntryProfile<UserModel, UserEntity>
{
    public UserProfile() : base(x => new(x))
    {
    }
}
