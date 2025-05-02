using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class PhieuMuonRepository : IPhieuMuonRepository
{
    private readonly DbContext _dbContext;
    public PhieuMuonRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public ICollection<PhieuMuon> GetPhieuMuon()
    {
        string query = "SELECT * FROM Phieumuon";
        var phieuMuon = _dbContext.GetData<PhieuMuon>(query);
        return phieuMuon;
    }

    public ICollection<PhieuMuon> GetPhieuMuonByProps(object? values)
    {
        var p = values.GetType().GetProperties();
        var query = "SELECT * FROM Phieumuon WHERE ";
        if (p.Length == 1)
        {
            query+=string.Join("", p.Select(p => p.Name)) + "=?";
        }
        else
        {
            query += string.Join("=? AND ", p.Select(p => p.Name)) + "=?";
        }
        var props = p.Select(p=> p.GetValue(values)).ToArray();
        var phieumuon = _dbContext.GetData<PhieuMuon>(query, props);
        return phieumuon;
    }

    public bool AddPhieuMuon(PhieuMuonInsertDTO phieuMuonInsertDto,int[] listId)
    {
        _dbContext.Add<PhieuMuon>(phieuMuonInsertDto);
        var addPhieuMuonResult = _dbContext.SaveChange();
        if(!addPhieuMuonResult)
            return false;
        var phieuMuonId = _dbContext.GetLastInsertId();
        var ChitietPhieuMuonList= new List<ChiTietPhieuMuon>();
        foreach (var VatDungId in listId)
        {
            var chiTietPhieuMuon = new ChiTietPhieuMuon()
            {
                Id_PhieuMuon = phieuMuonId,
                Id_VatDung = VatDungId
            };
            ChitietPhieuMuonList.Add(chiTietPhieuMuon);
        }

        _dbContext.AddList(ChitietPhieuMuonList);

        return _dbContext.SaveChange();
    }

    public bool UpdatePhieuMuon(PhieuMuonInsertDTO phieuMuonInsertDto,int id)
    {
        _dbContext.Update<PhieuMuon>(phieuMuonInsertDto, id);
        return _dbContext.SaveChange();
    }
}