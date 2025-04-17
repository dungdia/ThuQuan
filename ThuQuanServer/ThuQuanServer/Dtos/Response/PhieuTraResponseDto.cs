namespace ThuQuanServer.Dtos.Response;

public class PhieuTraResponseDto
{
    public int Id { get; set; }
    public int Id_ThanhVien { get; set; }
    public int Id_NhanVien { get; set; }
    public DateTime NgayTra { get; set; }
    public ICollection<ChiTietPhieuTraResponseDto> ChiTietPhieuTra { get; set; }
    public string? TinhTrang { get; set; }
}