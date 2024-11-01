using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserAuthentications;

public class RegisterDto
{
    [Required(ErrorMessage ="فیلد شماره تلفن اجباری است")]
    public required string PhoneNumber { get; set; }
    [Required(ErrorMessage ="فیلد رمز عبور اجباری است")]
    public required string Password { get; set; }
}
