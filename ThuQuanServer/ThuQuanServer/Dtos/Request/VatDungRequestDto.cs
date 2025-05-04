namespace ThuQuanServer.Dtos.Request;

public class VatDungRequestDto
{
    public string TenVatDung { get; set; }
    public string HinhAnh { get; set; }
    public string MoTa { get; set; }
    public int id_loaiVatDung {get;set;}

    public string TinhTrang { get; set; } = "Chưa mượn";
}