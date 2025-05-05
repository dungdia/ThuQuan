using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IPhieuPhatRepository
{
    public ICollection<PhieuPhat> GetPhieuPhat();
    public bool AddPhieuPhat(PhieuPhatInsertDTO phieuPhat, ChiTietPhieuPhat[] ctPhieuPhat);

    public ICollection<PhieuPhat> GetPhieuPhatByIdThanhVien(int idPhieuPhat);
    public ICollection<ChiTietPhieuPhat> GetChiTietPhieuPhatByIdPhieuPhat(int idPhieuPhat);

    public ICollection<PhieuPhat> GetPhieuPhatByProps(object? values);
    public bool UpdatePhieuPhat(PhieuPhatInsertDTO phieuPhatInsertDto, int id);

}