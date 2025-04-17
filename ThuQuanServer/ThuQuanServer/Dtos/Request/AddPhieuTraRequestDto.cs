using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class AddPhieuTraRequestDto
{
    [Required(ErrorMessage = "Không có ngày trả")]   
    public string ngayTra { get; set; }
    
    [Required(ErrorMessage = "Phải có ít nhất 1 vật dụng trong phiếu trả")]
    [MinLength(1, ErrorMessage = "Phải có ít nhất 1 vật dụng trong phiếu trả")]
    public int[] listIds { get; set; }
}