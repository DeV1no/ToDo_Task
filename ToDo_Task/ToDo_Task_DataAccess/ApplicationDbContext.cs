using Microsoft.EntityFrameworkCore;
using ToDo_Task_DataAccess.Configuration;
using ToDo_Task_DataAccess.Entity;

namespace ToDo_Task_DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new TasksConfiguration(modelBuilder.Entity<Tasks>());
    }

    public virtual DbSet<Tasks> Tasks { get; set; }
}