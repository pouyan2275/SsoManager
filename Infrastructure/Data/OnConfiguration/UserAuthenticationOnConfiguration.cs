using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.OnConfiguration;

public class UserAuthenticationOnConfiguration : IEntityTypeConfiguration<UserAuthentication>
{
    public void Configure(EntityTypeBuilder<UserAuthentication> builder)
    {
        builder.ToTable("UserAuthentications")
            .HasIndex(x=> x.NationalCode)
            .IsUnique()
            ;
    }
}
