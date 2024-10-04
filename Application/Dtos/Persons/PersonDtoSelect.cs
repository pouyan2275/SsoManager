
using Application.Dtos.Degrees;

namespace Application.Dtos.Persons;

public class PersonDtoSelect
{
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? NationalCode { get; set; }
    public Guid Id { get; set; }
    public Guid? DegreeId { get; set; }
    public DegreeDtoSelect? Degree { get; set; }
}
