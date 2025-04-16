namespace DesktopClient.DTO;

public class LoaiVatDungDTO
{
    public string tenLoai { get; set; }

    public LoaiVatDungDTO(string tenLoai)
    {
        this.tenLoai = tenLoai;
    }
}