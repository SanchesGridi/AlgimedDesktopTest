﻿using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WpfImplementation.Mapper.Profiles.Base;
using AlgimedDesktopTest.WpfImplementation.Models;

namespace AlgimedDesktopTest.WpfImplementation.Mapper.Profiles;

public class StepProfile : DbEntryProfile<StepModel, StepEntity>
{
    public StepProfile() : base(x => new(x))
    {
    }
}
