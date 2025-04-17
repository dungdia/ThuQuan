namespace ThuQuanServer.Dtos.Response;

public class ChiTietPhieuDatResponseDto
{
    public int Id_PhieuDat { get; set; }
    public int Id_VatDung { get; set; }
    public VatDung VatDung { get; set; }
}