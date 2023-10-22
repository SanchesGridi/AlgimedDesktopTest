using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.WpfImplementation.Mapper.Profiles;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        }).CreateMapper());

        return @this;
    }

    public static IContainerRegistry RegisterAppDbContext(this IContainerRegistry @this)
    {
        @this.Register<AppDbContext>(() =>
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=algimed_test_task.db")
                .UseLazyLoadingProxies();
            var context = new AppDbContext(builder.Options);
            return context;
        });

        return @this;
    }
}
