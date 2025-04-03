using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class UpdateThanhVienRequestDto
{ 
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Ten dang nhap khong de trong")]
    [MinLength(3, ErrorMessage = "Ten dang nhap phai co it nhat 3 ky tu")]
    [MaxLength(100, ErrorMessage = "Ten dang nhap nhieu nhat la 100 ky tu")]
    public string UserName {get;set;}
    
    [DefaultValue("")]
    [Required(ErrorMessage = "Vui long nhap ho ten")]
    [Length(3, 100, ErrorMessage = "Ho ten phai tu 3 ky tu den 100 ky tu")]
    public string Hoten {get;set;}
    
    [Required(ErrorMessage = "Email không được để trống.")]
    [EmailAddress(ErrorMessage = "Không đúng định dạng Email.")]
    public string Email {get;set;}
    
    [DefaultValue("")]
    [Required(ErrorMessage = "Vui long nhap so dien thoai")]
    [Length(10, 11, ErrorMessage = "So dien thoai co dinh dang co 10-11 ky tu")]
    public string sdt {get;set;}
}