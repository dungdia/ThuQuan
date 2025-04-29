using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Dtos.Response;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface ITaiKhoanRepository
{
    public ICollection<TaiKhoan> GetAccount();
    public ThanhVien? GetAccountThanhVienByEmailTaiKhoan(object? values);
    public ICollection<TaiKhoan> GetAccountByProps(object? values);
    public ICollection<ThanhVien> GetThanhVien();
    public ThanhVien GetThanhVienById(int id);
    public NhanVien GetNhanVienById(int id);
    public bool AddThanhVien(TaikhoanInsertDTO taikhoan);
    public bool UpdateThanhVien(ThanhVienRequestDto taikhoan, int idThanhVien);
    public bool UpdateTaiKhoan(TaikhoanInsertDTO taikhoan, int idTaiKhoan);
    public bool CheckTaiKhoanExist(string email);
    public bool UpdateThanhVien(ThanhVienUpdateResponseDTO thanhvien, int idThanhVien);
    public bool UpdateTaiKhoan(TaiKhoanUpdateResponseDTO taikhoan, int idTaiKhoan);
    public TaiKhoan ChangePassword(string email, string newPassword);
    public ICollection<TaiKhoan> GetTaiKhoanByEmail(string email);
}