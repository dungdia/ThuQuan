using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class ThanhVienRequestDto
{
    [DefaultValue("")]
    [Required(ErrorMessage = "Vui long nhap ho ten")]
    [Length(10, 100, ErrorMessage = "Ho ten phai tu 10 ky tu den 100 ky tu")]
    public string HoTen { get; set; }
    
    [DefaultValue("")]
    [Required(ErrorMessage = "Vui long nhap so dien thoai")]
    [Length(10, 11, ErrorMessage = "So dien thoai co dinh dang co 10-11 ky tu")]
    public string SoDienThoai { get; set; }
    

    public int? Id_TaiKhoan { get; set; }
    
    [DefaultValue(1)]
    [Required(ErrorMessage = "Vui long nhap tinh trang")]
    [Range(1,2)]
    public int TinhTrang { get; set; }
    
}