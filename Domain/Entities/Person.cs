using Domain.Bases.Entities;

namespace Domain.Entities;

public class Person : BaseEntity
{   
    public string? NationalCode { get; set; }
}
