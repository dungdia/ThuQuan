namespace ThuQuanServer.Dtos.Response;

public class ChiTietPhieuPhatResponseDto
{
    public int Id_PhieuPhat { get; set; }
    public int Id_VatDung { get; set; }
    public string GhiChu { get; set; }
    public VatDung VatDung { get; set; }
}