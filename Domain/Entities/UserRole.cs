using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class UserRole : IdentityRole<Guid>
{
    [Key]
    public override Guid Id { get; set; } = Guid.NewGuid();
}
