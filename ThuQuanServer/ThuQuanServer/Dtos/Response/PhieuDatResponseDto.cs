namespace ThuQuanServer.Dtos.Response;

public class PhieuDatResponseDto
{
    public int Id { get; set; }
    public int Id_ThanhVien {get; set;}
    public DateTime NgayDat { get; set; }
    
    // Thêm thuộc tính ChiTietPhieuDatList
    public ICollection<ChiTietPhieuDatResponseDto> ChiTietPhieuDatList { get; set; } = new List<ChiTietPhieuDatResponseDto>();
    
    // THÊM: thuộc tính ánh xạ từ DB
    public string? TinhTrang { get; set; }
}