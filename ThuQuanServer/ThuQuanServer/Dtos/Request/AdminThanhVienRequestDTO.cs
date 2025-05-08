using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class AdminThanhVienRequestDTO
{
    [Required(ErrorMessage = "Tên tài khoản không được để trống")]
    public string username { get; set; }
    
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải nhất 6 kí tự")]
    public string password { get; set; }
    
    [Required(ErrorMessage = "Email không được để trống")]
    public string email { get; set; }
    
    [Required(ErrorMessage = "Họ tên không được để trống")]
    public string hoten { get; set; }
    
    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    public string sodienthoai { get; set; }
    
    public int vaitro { get; set; }
}