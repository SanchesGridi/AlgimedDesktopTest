using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WpfImplementation.Models;
using AutoMapper;

namespace AlgimedDesktopTest.WpfImplementation.Mapper.Profiles;

public class StepProfile : Profile
{
    public StepProfile()
    {
        CreateMap<StepEntity, StepModel>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<StepModel, StepEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GetId()));
    }
}
