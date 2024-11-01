
namespace Application.Dtos.UserAuthentications;

public class UserAuthenticationDtoSelect
{
    public string? NationalCode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public required Guid Id { get; set; }
}
