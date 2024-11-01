using Domain.Bases.Entities;

namespace Domain.Entities;

public class UserAuthentication : BaseEntity
{   
    public string? NationalCode { get; set; }
}
