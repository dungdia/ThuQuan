namespace DesktopClient.Models;

public class VatDung
{
    public int id { get; set; }
    public string tenVatDung { get; set; }
    public string hinhAnh { get; set; }
    public string? moTa { get; set; }
    public int id_LoaiVatDung { get; set; }
    public string? tinhTrang { get; set; }
}