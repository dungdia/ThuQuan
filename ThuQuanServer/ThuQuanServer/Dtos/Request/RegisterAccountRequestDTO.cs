using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class RegisterAccountRequestDTO
{
    [Required(ErrorMessage = "Tên tài khoản không được để trống")]
    public string username { get; set; }
    
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [MinLength(6, ErrorMessage = "Mật khóa phải nhất 6 kí tự")]
    public string password { get; set; }
    
    [Required(ErrorMessage = "Email không được để trống")]
    public string email { get; set; }
    
    public int vaitro { get; set; }
}