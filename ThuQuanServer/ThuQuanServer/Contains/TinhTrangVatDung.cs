using System.Runtime.Serialization;

namespace ThuQuanServer.Contains;

public enum TinhTrangVatDung
{
    [EnumMember(Value = "Chưa mượn")]
    Chưa_mượn = 1,
    [EnumMember(Value = "Đang mượn")]
    Đang_mượn = 2,
    [EnumMember(Value = "Bị hỏng")]
    Bị_hỏng = 3,
    [EnumMember(Value = "Ẩn")]
    Ẩn = 4
}
