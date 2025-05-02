namespace ThuQuanServer.Dtos.InsertObject;

public class PhieuMuonInsertDTO
{
    public DateTime ThoiGianMuon { get; set; }
    public DateTime thoiGianTra { get; set; }
    public int Id_ThanhVien {get;set;}
    public int Id_NhanVien {get;set;}
    public string TinhTrang {get;set;}
}