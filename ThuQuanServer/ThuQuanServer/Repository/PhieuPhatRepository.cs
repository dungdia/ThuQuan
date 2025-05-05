using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Request;
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
    
    public ICollection<PhieuPhat> GetPhieuPhatByProps(object? values)
    {
        var p = values.GetType().GetProperties();
        var query = "SELECT * FROM Phieuphat WHERE ";
        if (p.Length == 1)
        {
            query+=string.Join("", p.Select(p => p.Name)) + "=?";
        }
        else
        {
            query += string.Join("=? AND ", p.Select(p => p.Name)) + "=?";
        }
        var props = p.Select(p=> p.GetValue(values)).ToArray();
        var phieuPhat = _dbContext.GetData<PhieuPhat>(query, props);
        return phieuPhat;
    }
    
    public bool AddPhieuPhat(PhieuPhatInsertDTO phieuPhat, ChiTietPhieuPhat[] ctPhieuPhat)
    {
        _dbContext.Add<PhieuPhat>(phieuPhat);
        var addPhieuPhatResult = _dbContext.SaveChange();
        if (!addPhieuPhatResult) return false;
        if (ctPhieuPhat.Length <= 0)
            return true;
        
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
    
    public bool UpdatePhieuPhat(PhieuPhatInsertDTO phieuPhatInsertDto,int id)
    {
        _dbContext.Update<PhieuPhat>(phieuPhatInsertDto, id);
        return _dbContext.SaveChange();
    }
    
}