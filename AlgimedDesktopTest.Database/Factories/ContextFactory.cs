using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Utils;
using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.Database.Factories;

public static class ContextFactory
{
    public static AppDbContext Create()
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(Db.ConnectionString)
            .UseLazyLoadingProxies();

        return new (builder.Options);
    }
}
