using AlgimedDesktopTest.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.Database.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<ModeEntity> Modes { get; set; }
    public DbSet<StepEntity> Steps { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // test data:
        modelBuilder.Entity<ModeEntity>().HasData(
            new ModeEntity[]
            {
                new ModeEntity { Id = 1, Name = "NONE", MaxBottleNumber = 0, MaxUsedTips = 4 },
                new ModeEntity { Id = 2, Name = "STANDART", MaxBottleNumber = 16, MaxUsedTips = 4 },
                new ModeEntity { Id = 3, Name = "DEMO", MaxBottleNumber = 16, MaxUsedTips = 4 }
            }
        );
        modelBuilder.Entity<StepEntity>().HasData(
            new StepEntity[]
            {
                new StepEntity { Id = 1, ModeId = 1, Timer = 0, Destination = "", Speed = 0, Type = "INIT", Volume = 0 },
                new StepEntity { Id = 2, ModeId = 1, Timer = 0, Destination = "Washstation", Speed = 400, Type = "EXIT", Volume = 10 }
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
