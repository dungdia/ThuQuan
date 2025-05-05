using ThuQuanServer.Models;

namespace ThuQuanServer.Dtos.Response;

public class PhieuPhatResponseDto
{
    public int Id { get;set; }
    public int Id_ThanhVien { get; set; }
    public string lydo { get; set; }
    public string mucphat { get; set; }
    
    // Thêm thuộc tính ChiTietPhieuPhatList
    public ICollection<ChiTietPhieuPhatResponseDto> ChiTietPhieuPhatList { get; set; } = new List<ChiTietPhieuPhatResponseDto>();
    
    // THÊM: thuộc tính ánh xạ từ DB
    public string? TinhTrang { get; set; }
    
}