using System.Runtime.Serialization;

namespace ThuQuanServer.Contains;

public enum TinhTrangPhieuMuon
{
    [EnumMember(Value = "Đã xuất phiếu")]
    Đã_xuất_phiếu=1,
    [EnumMember(Value = "Đã hủy")]
    Đã_hủy=2,
    [EnumMember(Value = "Ẩn")]
    Ẩn=3
}