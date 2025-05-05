using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IPhieuPhatRepository
{
    public ICollection<PhieuPhat> GetPhieuPhat();
    public bool AddPhieuPhat(PhieuPhatInsertDTO phieuPhat, ChiTietPhieuPhat[] ctPhieuPhat);
}