using AlgimedDesktopTest.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;

namespace AlgimedDesktopTest.WpfImplementation.Extensions;

public static class ContainerRegistryExtensions
{
    public static IContainerRegistry RegisterAppContext(this IContainerRegistry @this)
    {
        @this.RegisterScoped<AppContext>(() =>
        {
            var builder = new DbContextOptionsBuilder<AppContext>()
                .UseSqlite("Data Source=algimed_test_task.db")
                .UseLazyLoadingProxies();
            var context = new AppContext(builder.Options);
            return context;
        });

        return @this;
    }
}
