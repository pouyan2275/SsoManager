using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserAuthentications;

public class LoginDto
{
    [Required(ErrorMessage ="فیلد شماره تلفن اجباری است")]
    public required string PhoneNumber { get; set; }
    [Required(ErrorMessage ="فیلد رمز عبور اجباری است")]
    public required string Password { get; set; }
    public string? TwoFactorCode { get; set; }
    public string? TwoFactorRecoveryCode { get; set; }
    public bool? UseCookies { get; set; }
    public bool? UseSessionCookies { get; set; }
}
