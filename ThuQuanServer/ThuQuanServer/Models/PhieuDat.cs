using System.ComponentModel.DataAnnotations.Schema;
using ThuQuanServer.Contains;

namespace ThuQuanServer.Models;

public class PhieuDat
{
    public int Id { get; set; }
    public int Id_ThanhVien {get; set;}
    public DateTime NgayDat { get; set; }
    
    // Thêm thuộc tính ChiTietPhieuDatList
    public ICollection<ChiTietPhieuDat> ChiTietPhieuDatList { get; set; } = new List<ChiTietPhieuDat>();
    
    // THÊM: thuộc tính ánh xạ từ DB
    public string? TinhTrang { get; set; }

    // [NotMapped]
    // public TinhTrangPhieuDat TinhTrangText
    // {
    //     get
    //     {
    //         if(string.IsNullOrEmpty(TinhTrang))
    //             throw new NullReferenceException("TinhTrangText đang null hoặc rỗng");
    //         return TinhTrang switch
    //         {
    //             "Đã xuất phiếu" => TinhTrangPhieuDat.Đã_xuất_phiếu,
    //             "Đã hủy" => TinhTrangPhieuDat.Đã_hủy,
    //             "Ẩn" => TinhTrangPhieuDat.Ẩn,
    //             _ => throw new Exception($"Giá trị không hợp lệ: {TinhTrang}")
    //         };
    //     }
    // }
}