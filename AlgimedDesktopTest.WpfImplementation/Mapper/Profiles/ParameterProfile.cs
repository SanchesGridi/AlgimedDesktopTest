using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WpfImplementation.Mapper.Profiles.Base;
using AlgimedDesktopTest.WpfImplementation.Models;

namespace AlgimedDesktopTest.WpfImplementation.Mapper.Profiles;

public class ParameterProfile : DbEntryProfile<ParameterModel, ParameterEntity>
{
    public ParameterProfile() : base(x => new(x))
    {
    }
}
