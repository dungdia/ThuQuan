using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class ChangePasswordRequestDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email {get; set;}
    
    [Required(ErrorMessage = "Mat khau la khong de trong")]
    [Length(6,100,ErrorMessage = "Mật khẩu từ 6 đến 100 ký tự")]
    public string Password {get; set;}
    
    [Required(ErrorMessage = "Mat khau la khong de trong")]
    [Length(6,100,ErrorMessage = "Mật khẩu từ 6 đến 100 ký tự")]
    public string newPassword{get; set;}
}