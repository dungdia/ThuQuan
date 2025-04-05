namespace ThuQuanServer.Dtos.Response;

public class TaiKhoanUpdateResponseDTO
{
    public int Id { get; set; } // Changed from Id_TaiKhoan to Id
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime? NgayThamGia { get; set; }
    public int VaiTro { get; set; }
}