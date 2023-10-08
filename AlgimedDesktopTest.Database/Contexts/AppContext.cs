using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.Database.Contexts;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
