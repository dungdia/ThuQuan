using System.Runtime.Serialization;

namespace ThuQuanServer.Contains;

public enum TinhTrangPhieuDat
{
    [EnumMember(Value = "Đã xuất phiếu")]
    Đã_xuất_phiếu = 1,
    [EnumMember(Value = "Đã xử lý")]
    Đã_xử_Lý = 2,
    [EnumMember(Value = "Đã hủy")]
    Đã_hủy=3,
    [EnumMember(Value = "Ẩn")]
    Ẩn=4
}