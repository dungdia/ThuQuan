using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class AdminUpdateThanhVienRequestDTO
{
    public string username { get; set; }
    
    public string email { get; set; }
    
    public string password { get; set; }
    
    public string hoten { get; set; }
    public string sodienthoai { get; set; }
}