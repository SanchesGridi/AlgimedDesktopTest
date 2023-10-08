using AlgimedDesktopTest.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.Database.Contexts;

public class AppContext : DbContext
{
    public DbSet<ModeEntity> Modes { get; set; }
    public DbSet<StepEntity> Steps { get; set; }

    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
