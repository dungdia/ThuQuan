namespace ThuQuanServer.Dtos.Response;

public class ChiTietPhieuTraResponseDto
{
    public int Id_PhieuTra { get; set; }
    public int Id_VatDung { get; set; }
    public VatDung VatDung { get; set; }
    public string TinhTrang { get; set; }
}