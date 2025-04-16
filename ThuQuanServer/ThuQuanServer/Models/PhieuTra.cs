using System.ComponentModel.DataAnnotations.Schema;
using ThuQuanServer.Contains;

namespace ThuQuanServer.Models;

public class PhieuTra
{
    public int Id { get; set; }
    public int Id_ThanhVien {get;set;}
    public DateTime NgayTra { get; set; }
    // Thêm: thuộc tính ánh xạ từ DB
    public string TinhTrang { get; set; }

    // [NotMapped]
    // public TinhTrangPhieuTra TinhTrangText
    // {
    //     get
    //     {
    //         if(string.IsNullOrEmpty(TinhTrang))
    //             throw new NullReferenceException("TinhTrangText đang null hoặc rỗng");
    //         return TinhTrang switch
    //         {
    //             "Đã xuất phiếu" => TinhTrangPhieuTra.Đã_xuất_phiếu,
    //             "Đã hủy" => TinhTrangPhieuTra.Đã_hủy,
    //             "Ẩn" => TinhTrangPhieuTra.Ẩn,
    //             _ => throw new Exception($"Giá trị không hợp lệ: {TinhTrang}")
    //         };
    //     }
    // }
}