using ThuQuanServer.Contains;

namespace ThuQuanServer.Models;

public class PhieuMuon
{
    public int Id { get; set; }
    public DateTime ThoiGianMuon { get; set; }
    public DateTime thoiGianTra { get; set; }
    public int Id_ThanhVien {get;set;}
    public int Id_NhanVien {get;set;}
    
    // Thêm: thuộc tính ánh xạ từ DB
    public string? TinhTrang {get;set;}

    public TinhTrangPhieuMuon? TinhTrangText
    {
        get
        {
            if (string.IsNullOrEmpty(TinhTrang))
                throw new NullReferenceException("TinhTrangText đang null hoặc rỗng");
            return TinhTrang switch
            {
                "Đã xuất phiếu" => TinhTrangPhieuMuon.Đã_xuất_phiếu,
                "Đã hủy" => TinhTrangPhieuMuon.Đã_hủy,
                "Ẩn" => TinhTrangPhieuMuon.Ẩn,
                _ => throw new Exception($"Giá trị không hợp lệ {TinhTrang}")
            };
        }
    }
    
}