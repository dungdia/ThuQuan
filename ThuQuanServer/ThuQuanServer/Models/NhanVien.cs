namespace ThuQuanServer.Models;

public class NhanVien
{
    public int Id { get; set; }
    public string HoTen { get; set; }
    public string SoDienThoai { get; set; }
    public string GioiTinh { get; set; }
    public string DiaChi { get; set; }
    public int Id_TaiKhoan{ get; set; }
    public string TinhTrang { get; set; }
}