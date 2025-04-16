using System.ComponentModel.DataAnnotations.Schema;
using ThuQuanServer.Contains;

public class VatDung
{
    public int Id { get; set; }
    public string TenVatDung { get; set; }
    public string HinhAnh { get; set; }
    public string? MoTa { get; set; }
    public int Id_LoaiVatDung { get; set; }

    // THÊM: thuộc tính ánh xạ từ DB
    public string? TinhTrang { get; set; }

    // [NotMapped]
    // public TinhTrangVatDung TinhTrangText
    // {
    //     get
    //     {
    //         if (string.IsNullOrEmpty(TinhTrang))
    //             throw new Exception("TinhTrangText đang null hoặc rỗng");
    //
    //         return TinhTrang switch
    //         {
    //             "Chưa mượn" => TinhTrangVatDung.Chưa_mượn,
    //             "Đang mượn" => TinhTrangVatDung.Đang_mượn,
    //             "Đã đặt"=>TinhTrangVatDung.Đã_đặt,
    //             "Bị hỏng" => TinhTrangVatDung.Bị_hỏng,
    //             "Ẩn" => TinhTrangVatDung.Ẩn,
    //             _ => throw new Exception($"Giá trị không hợp lệ: {TinhTrang}")
    //         };
    //     }
    // }
}