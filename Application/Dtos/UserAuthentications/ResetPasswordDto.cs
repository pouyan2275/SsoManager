namespace Application.Dtos.UserAuthentications;

public class ResetPasswordDto
{
    public required string PhoneNumber { get; set; }
    public required string ResetCode { get; set; }
    public required string NewPassword { get; set; }
}
