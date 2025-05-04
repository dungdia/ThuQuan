using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class UpdateNhanVienRequestDto
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
}