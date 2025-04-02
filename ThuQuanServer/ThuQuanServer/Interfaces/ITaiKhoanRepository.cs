using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface ITaiKhoanRepository
{
    public ICollection<TaiKhoan> GetAccount();
    public ICollection<TaiKhoan> GetAccountByProps(object? values);
    public ICollection<ThanhVien> GetThanhVien();
    public bool AddThanhVien(TaikhoanInsertDTO taikhoan);
    public bool UpdateThanhVien(ThanhVienRequestDto taikhoan, int idThanhVien);
}