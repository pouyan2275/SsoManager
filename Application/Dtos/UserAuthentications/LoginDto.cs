using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserAuthentications;

public class LoginDto
{
    [Required(ErrorMessage ="فیلد شماره تلفن اجباری است")]
    public required string NationalCode { get; set; }
    [Required(ErrorMessage ="فیلد رمز عبور اجباری است")]
    public required string Password { get; set; }
    public bool? UseCookies { get; set; }
}
