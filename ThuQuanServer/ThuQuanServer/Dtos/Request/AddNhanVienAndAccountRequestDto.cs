using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class AddNhanVienAndAccountRequestDto
{
    [Required (ErrorMessage = "Họ tên không được để trống")]
    [Length(3,100, ErrorMessage = "Họ tên phải từ 3-100 ký tự")]
    public string hoten { get; set; }
    
    [Required (ErrorMessage = "Số điện thoại không được để trống")]
    [Length(10,11, ErrorMessage = "Số điện thoại phải từ 10-11 số")]
    public string sodienthoai { get; set; }
    [Required (ErrorMessage = "Giới tính không được để trống")]
    public string gioitinh { get; set; }
    [Required (ErrorMessage = "Địa chỉ không được để trống")]
    [Length(10,100, ErrorMessage = "Địa chỉ phải từ 10-100 ký tự")]
    public string diachi { get; set; }
    [Required (ErrorMessage = "Email không được trống")]
    [EmailAddress (ErrorMessage = "Email không đúng định dạng")]
    public string email { get; set; }
    [Required (ErrorMessage = "Username không được để trống")]
    [Length(3,30, ErrorMessage = "Username phải từ 3-30 ký tự")]
    public string username { get; set; }
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [Length(6,100,ErrorMessage = "Mật khẩu từ 6 đến 100 ký tự")]
    public string password { get; set; }
    [Required (ErrorMessage = "Ngày tham gia không được để trống")]
    public DateTime ngaythamgia { get; set; }
    [Required (ErrorMessage = "Tình trạng không được để trống")]
    public string tinhtrang { get; set; }
}