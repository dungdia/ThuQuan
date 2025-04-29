using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IPhieuTraRepository
{
    public ICollection<PhieuTra> GetPhieuTra();
    public ICollection<PhieuTra> GetPhieuTraByProps(object? values);
    public ICollection<PhieuTra> GetPhieuTraByIdThanhVien(int id);
    public ICollection<PhieuTra> GetPhieuTraByIdNhanVien(int id);
    
    public ICollection<ChiTietPhieuTra> GetChiTietPhieuTraByIdPhieuTra(int idPhieuTra);
    public ICollection<ChiTietPhieuTra> GetChiTietPhieuTraByProps(object? values);
    public bool AddPhieuTra(PhieuTra phieuTra, int[] idVatDung);
    public bool AddChiTietPhieuTra(ChiTietPhieuTra chiTietPhieuTra);
    public bool UpdatePhieuTra();
} 