using System.Runtime.Serialization;
using Google.Protobuf.WellKnownTypes;

namespace ThuQuanServer.Contains;

public enum TinhTrangVatDung
{
    [EnumMember(Value = "Chưa mượn")]
    Chưa_mượn = 1,
    [EnumMember(Value = "Đang mượn")]
    Đang_mượn = 2,
    [EnumMember(Value = "Đã đặt")]
    Đã_đặt=3,
    [EnumMember(Value = "Bị hỏng")]
    Bị_hỏng = 4,
    [EnumMember(Value = "Ẩn")]
    Ẩn = 5,
}
