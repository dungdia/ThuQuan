using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class ThongKeKhoangTGRequestDTO
{
    [Required(ErrorMessage = "Ngày không được để trống")]
    
    public DateTime ngayBatDau { get; set; }
    public DateTime ngayKetThuc { get; set; }
}