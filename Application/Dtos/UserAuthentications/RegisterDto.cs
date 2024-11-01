using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserAuthentications;

public class RegisterDto
{
    [Length(10,10,ErrorMessage ="کد ملی به درستی وارد نشده")]
    [Required(ErrorMessage ="فیلد کد ملی اجباری است")]
    public required string NationalCode { get; set; }
    [Length(11,11,ErrorMessage = " شماره موبایل به درستی وارد نشده")]
    [Required(ErrorMessage ="فیلد شماره تلفن اجباری است")]
    public required string PhoneNumber { get; set; }
}
