using ThuQuanServer.Dtos.Request;

namespace ThuQuanServer.Dtos.InsertObject;

public class TaikhoanInsertDTO : TaiKhoanRequestDto
{
    public DateTime? NgayThamGia { get; set; } = DateTime.Now;
}