using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IPhieuDatRepository
{
    public ICollection<PhieuDat> GetPhieuDat();
    public ICollection<PhieuDat> GetPhieuDatByIdThanhVien(int idThanhVien);
    public ICollection<ChiTietPhieuDat> GetChiTietPhieuDatByIdPhieuDat(int idPhieuDat);
    public ICollection<PhieuDat> GetPhieuDatByProps(object? values);
    public bool AddPhieuDat(PhieuDat phieuDat);
    public int AddPhieuDatReturnId(PhieuDat phieuDat);
    public bool AddChiTietPhieuDat(ChiTietPhieuDat chiTietPhieuDat);
    public bool UpdatePhieuDat();
}