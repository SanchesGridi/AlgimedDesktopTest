using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WpfImplementation.Mapper.Profiles.Base;
using AlgimedDesktopTest.WpfImplementation.Models;

namespace AlgimedDesktopTest.WpfImplementation.Mapper.Profiles;

public class ModeProfile : DbEntryProfile<ModeModel, ModeEntity>
{
    public ModeProfile() : base(x => new(x))
    {
    }
}
