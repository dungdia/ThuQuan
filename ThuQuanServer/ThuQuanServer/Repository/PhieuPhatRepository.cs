using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class PhieuPhatRepository : IPhieuPhatRepository
{
    private readonly DbContext _dbContext;

    public PhieuPhatRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public ICollection<PhieuPhat> GetPhieuPhat()
    {
        string query = "SELECT * FROM Phieumuon";
        var phieuphat = _dbContext.GetData<PhieuPhat>(query);
        return phieuphat;
    }
    
    public bool AddPhieuPhat(PhieuPhatInsertDTO phieuPhat, ChiTietPhieuPhat[] ctPhieuPhat)
    {
        _dbContext.Add<PhieuPhat>(phieuPhat);
        var addPhieuPhatResult = _dbContext.SaveChange();
        if (!addPhieuPhatResult) return false;
        var phieuPhatId = _dbContext.GetLastInsertId();
        var chiTietPhieuPhatList = new List<ChiTietPhieuPhat>();
        foreach (var item in ctPhieuPhat)
        {
            var chiTietPhieuPhat = new ChiTietPhieuPhat()
            {
                Id_VatDung = item.Id_VatDung,
                Id_PhieuPhat = phieuPhatId,
                GhiChu = item.GhiChu,
            };
            chiTietPhieuPhatList.Add(chiTietPhieuPhat);
        }
        
        _dbContext.AddList(chiTietPhieuPhatList);
        return _dbContext.SaveChange();
    }

    public ICollection<PhieuPhat> GetPhieuPhatByIdThanhVien(int idThanhVien)
    {
        string query = "SELECT * FROM PhieuPhat WHERE id_thanhvien = @0";
        return _dbContext.GetData<PhieuPhat>(query, idThanhVien);
    }

    public ICollection<ChiTietPhieuPhat> GetChiTietPhieuPhatByIdPhieuPhat(int idPhieuPhat)
    {
        string query = "SELECT * FROM ChiTietPhieuPhat WHERE id_phieuphat = @0";
        return _dbContext.GetData<ChiTietPhieuPhat>(query, idPhieuPhat);
    }
    
}