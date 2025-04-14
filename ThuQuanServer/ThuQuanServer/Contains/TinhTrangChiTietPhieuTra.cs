using System.Runtime.Serialization;

namespace ThuQuanServer.Contains;

public enum TinhTrangChiTietPhieuTra
{
    [EnumMember(Value = "Nguyên vẹn")]
    Nguyên_vẹn=1,
    [EnumMember(Value = "Hư hỏng")]
    Hư_hỏng=2
}