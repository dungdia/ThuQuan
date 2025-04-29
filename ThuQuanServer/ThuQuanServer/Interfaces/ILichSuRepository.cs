using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface ILichSuRepository 
{
    public ICollection<LichSu> GetLichSu();
    public bool CheckLichSuVao(int? IdThanhVien);
}