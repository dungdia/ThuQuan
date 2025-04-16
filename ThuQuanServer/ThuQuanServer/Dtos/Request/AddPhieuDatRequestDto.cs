using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class AddPhieuDatRequestDto
{
    [Required(ErrorMessage = "Không có ngày đặt.")]
    public string NgayDat { get; set; }
    
    [Required(ErrorMessage = "Không thể tạo phiếu đặt với không vật dụng")]
    [MinLength(1, ErrorMessage = "Không thể tạo phiếu đạt với không vật dụng")]
    public int[] listId {get; set;}
}