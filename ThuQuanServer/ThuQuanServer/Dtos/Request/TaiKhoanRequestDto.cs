using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Google.Protobuf.WellKnownTypes;

namespace ThuQuanServer.Dtos.Request;

public class TaiKhoanRequestDto
{
    [Required(ErrorMessage = "Ten dang nhap khong de trong")]
    [MinLength(10, ErrorMessage = "Ten dang nhap phai co it nhat 10 ky tu")]
    [MaxLength(100, ErrorMessage = "Ten dang nhap nhieu nhat la 100 ky tu")]
    public string     UserName { get; set; }
    
    [Required(ErrorMessage = "Mat khau la khong de trong")]
    [MinLength(10, ErrorMessage = "Mat khau phai co it nhat 10 ky tu")]
    [MaxLength(255, ErrorMessage = "Mat khau nhieu nhat la 255 ky tu")]
    public string     Password { get; set; }
    
    [Required(ErrorMessage = "Email la khong de trong")]
    public string Email { get; set; }
    
    [DefaultValue(0)]
    [Description("""Vai Tro: Thành viên = 0, Nhân viên = 1""")]
    public int VaiTro { get; set; }
}