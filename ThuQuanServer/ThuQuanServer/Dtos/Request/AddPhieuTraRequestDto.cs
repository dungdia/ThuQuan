using System.ComponentModel.DataAnnotations;
using ThuQuanServer.Models;

namespace ThuQuanServer.Dtos.Request;

public class AddPhieuTraRequestDto
{
    [Required(ErrorMessage = "Phải có ít nhất 1 vật dụng trong phiếu trả")]
    [MinLength(1, ErrorMessage = "Phải có ít nhất 1 vật dụng trong phiếu trả")]
    public ChiTietPhieuTra[] listItem { get; set; }
    
    [Required(ErrorMessage = "phải có id phiếu mượn")]
    public int id_phieumuon { get; set; }
    
    [Required(ErrorMessage = "Phải có id thành viên")]
    public int id_thanhvien { get; set; }
}