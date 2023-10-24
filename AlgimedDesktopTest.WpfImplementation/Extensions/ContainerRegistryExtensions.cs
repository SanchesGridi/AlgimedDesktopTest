using AlgimedDesktopTest.WpfImplementation.Mapper.Profiles;
using AutoMapper;
using Prism.Ioc;

namespace AlgimedDesktopTest.WpfImplementation.Extensions;

public static class ContainerRegistryExtensions
{
    public static IContainerRegistry RegisterAutoMapperInstance(this IContainerRegistry @this)
    {
        @this.RegisterInstance(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ModeProfile>();
            cfg.AddProfile<StepProfile>();
            cfg.AddProfile<UserProfile>();
            cfg.AddProfile<ParameterProfile>();
        }).CreateMapper());

        return @this;
    }
}
