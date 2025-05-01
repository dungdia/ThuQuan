namespace DesktopClient.Models;

public class VatDung
{
    public int Id { get; set; }
    public string TenVatDung { get; set; }
    public string HinhAnh { get; set; }
    public string? MoTa { get; set; }
    public int Id_LoaiVatDung { get; set; }
    public string? TinhTrang { get; set; }
}