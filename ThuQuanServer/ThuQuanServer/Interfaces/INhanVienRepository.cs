using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface INhanVienRepository
{
    public ICollection<NhanVien> GetNhanVien();
    public ICollection<NhanVien> GetNhanVienByProps(object? values);
}