using Domain.Bases.Entities;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Reflection.Emit;
namespace Infrastructure.Bases.Data;

public class UsersDbContext : IdentityDbContext<UserAuthentication,UserRole,Guid>
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserAuthentication>(b =>
        {
            b.ToTable("PouyaUsers");
        });

        builder.Entity<UserRole>(b =>
        {
            b.ToTable("PouyaRoles");
        });
        builder.Entity<IdentityUserClaim<Guid>>(b =>
        {
            b.ToTable("PouyaClaims");
        });

        builder.Entity<IdentityUserLogin<Guid>>(b =>
        {
            b.ToTable("PouyaLogins");
        });

        builder.Entity<IdentityUserToken<Guid>>(b =>
        {
            b.ToTable("PouyaTokens");
        });


        builder.Entity<IdentityRoleClaim<Guid>>(b =>
        {
            b.ToTable("PouyaRoleClaims");
        });

        builder.Entity<IdentityUserRole<Guid>>(b =>
        {
            b.ToTable("PouyaUserRoles");
        });
    }


}