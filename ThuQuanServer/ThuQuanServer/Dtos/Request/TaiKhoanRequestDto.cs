using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Google.Protobuf.WellKnownTypes;

namespace ThuQuanServer.Dtos.Request;

public class TaiKhoanRequestDto
{
    
    public string     UserName { get; set; }
    
   
    public string     Password { get; set; }

    [Required(ErrorMessage = "Email la khong duoc de trong")]
    public string Email { get; set; }
    
    [DefaultValue(0)]
    [Description("""Vai Tro: Thành viên = 0, Nhân viên = 1""")]
    public int VaiTro { get; set; }
}