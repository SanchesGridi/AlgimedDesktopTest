using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WpfImplementation.Models;
using AutoMapper;

namespace AlgimedDesktopTest.WpfImplementation.Mapper.Profiles;

public class ModeProfile : Profile
{
    public ModeProfile()
    {
        CreateMap<ModeEntity, ModeModel>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<ModeModel, ModeEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GetId()));
    }
}
