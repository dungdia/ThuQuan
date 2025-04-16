namespace ThuQuanServer.Models;

public class ChiTietPhieuDat
{
    public int Id_PhieuDat { get; set; }
    public int Id_VatDung { get; set; }
    
    // Thuộc tính VatDung để chứa thông tin chi tiết về VatDung
    public VatDung VatDung { get; set; }
}