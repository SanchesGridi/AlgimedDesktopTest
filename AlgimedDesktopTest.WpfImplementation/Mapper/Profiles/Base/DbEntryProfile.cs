using AlgimedDesktopTest.Database.Entities.Base;
using AlgimedDesktopTest.WpfImplementation.Models.Base;
using AutoMapper;
using System;

namespace AlgimedDesktopTest.WpfImplementation.Mapper.Profiles.Base;

public abstract class DbEntryProfile<TModel, TEntity> : Profile
    where TModel : DbEntryModel
    where TEntity : IEntityBase<int>
{
    public DbEntryProfile(Func<int, TModel> constructor)
    {
        Map(constructor);
    }

    private void Map(Func<int, TModel> constructor)
    {
        CreateMap<TEntity, TModel>()
            .ConstructUsing(src => constructor.Invoke(src.Id));

        CreateMap<TModel, TEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GetId()));
    }
}
