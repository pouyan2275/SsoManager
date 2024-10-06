using Domain.Bases.Entities;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Infrastructure.Bases.Data;

public class ApplicationDbContext : IdentityDbContext<Person,IdentityRole<Guid>,Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entities = Assembly.GetAssembly(typeof(BaseEntity))?.GetTypes();

        foreach (var entity in entities!)
        {
            if (entity.IsSubclassOf(typeof(BaseEntity)) && !entity.IsAbstract)
                modelBuilder.Entity(entity)
                .HasIndex("IsDeleted")
                .HasFilter("IsDeleted = 0");
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}