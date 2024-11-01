using Domain.Bases.Entities;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
namespace Infrastructure.Bases.Data;

public class ApplicationDbContext : IdentityDbContext<UserAuthentication, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entities = Assembly.GetAssembly(typeof(BaseEntity))?.GetTypes()
            .Where(x=> (
            x.IsSubclassOf(typeof(BaseEntity)) 
            || x.IsSubclassOf(typeof(BaseEntityEmpty))
            ) 
            && !x.IsAbstract);

        foreach (var entity in entities!)
        {
                modelBuilder.Entity(entity);
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}