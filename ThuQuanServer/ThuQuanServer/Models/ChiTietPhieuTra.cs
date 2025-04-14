using System.ComponentModel.DataAnnotations.Schema;
using ThuQuanServer.Contains;

namespace ThuQuanServer.Models;

public class ChiTietPhieuTra
{
    public int Id_PhieuTra { get; set; }
    public int Id_VatDung { get; set; }
    
    public string? TinhTrang {get; set;}

    [NotMapped]
    public TinhTrangChiTietPhieuTra TinhTrangText
    {
        get
        {
            if (string.IsNullOrEmpty(TinhTrang))
                throw new NullReferenceException("TinhTrangText đang null hoặc rỗng");
            return TinhTrang switch
            {
                "Nguyên vẹn" => TinhTrangChiTietPhieuTra.Nguyên_vẹn,
                "Hư hỏng" => TinhTrangChiTietPhieuTra.Hư_hỏng,
                _ => throw new Exception($"Giá trị không hợp lệ {TinhTrang}")
            };
        }
    }
}