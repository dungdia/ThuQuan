using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class ThongKeLichSuNgayRequestDTO
{
    [Required(ErrorMessage = "Ngày không được để trống")]
    
    public DateTime ngay { get; set; }
}