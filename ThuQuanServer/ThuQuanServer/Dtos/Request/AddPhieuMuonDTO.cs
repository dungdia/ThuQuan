using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class AddPhieuMuonDTO
{
    [Required(ErrorMessage = "Không Có Thời gian trả")] 
    public DateTime thoigiantra { get; set; }
    [Required(ErrorMessage = "Không có id thành viên")]
    public int id_thanhvien{ get; set; }
    [Required(ErrorMessage = "Không có danh sách vật dụng")]
    [MinLength(1,ErrorMessage = "Phải có ít nhất một vật dụng")]
    public int[] listId { get; set; }
}