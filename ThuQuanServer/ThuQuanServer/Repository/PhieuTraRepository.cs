using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class PhieuTraRepository : IPhieuTraRepository
{
    private readonly DbContext _dbContext;

    public PhieuTraRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public ICollection<PhieuTra> GetPhieuTra()
    {
        string query = "SELECT * FROM PhieuTra";
        var phieuTra = _dbContext.GetData<PhieuTra>(query);
        return phieuTra;
    }

    public ICollection<PhieuTra> GetPhieuTraByProps(object? values)
    {
        var p = values.GetType().GetProperties();
        var query = "SELECT * FROM PhieuTra WHERE ";
        query += string.Join("=? AND ", p.Select(p => p.Name)) + "=?";
        var props = p.Select(p => p.GetValue(values)).ToArray();
        var phieuTra = _dbContext.GetData<PhieuTra>(query, props);
        return phieuTra;
    }

    public ICollection<PhieuTra> GetPhieuTraByIdThanhVien(int idThanhVien)
    {
        string query = "SELECT * FROM PhieuTra WHERE Id_ThanhVien = ?";
        return _dbContext.GetData<PhieuTra>(query, idThanhVien);
    }

    public ICollection<PhieuTra> GetPhieuTraByIdNhanVien(int idNhanVien)
    {
        string query = "SELECT * FROM PhieuTra WHERE Id_NhanVien = ?";
        return _dbContext.GetData<PhieuTra>(query, idNhanVien);
    }

    public ICollection<ChiTietPhieuTra> GetChiTietPhieuTraByIdPhieuTra(int idPhieuTra)
    {
        var query = "SELECT * FROM ChiTietPhieuTra WHERE Id_PhieuTra = ?";
        return _dbContext.GetData<ChiTietPhieuTra>(query, idPhieuTra);
    }

    public ICollection<ChiTietPhieuTra> GetChiTietPhieuTraByProps(object? values)
    {
        var p = values.GetType().GetProperties();
        var query = "SELECT * FROM ChiTietPhieuTra WHERE ";
        query += string.Join("=? AND ", p.Select(p => p.Name)) + "=?";
        var props = p.Select(p => p.GetValue(values)).ToArray();
        var chiTietPhieuDat = _dbContext.GetData<ChiTietPhieuTra>(query, props);
        return chiTietPhieuDat;
    }

    public bool AddPhieuTra(PhieuTraInsertDTO phieuTra, ChiTietPhieuTra[] listVd)
    {
        _dbContext.Add<PhieuTra>(phieuTra);
        var addPhieuTraResult = _dbContext.SaveChange();
        if (!addPhieuTraResult) return false;
        var phieuTraId = _dbContext.GetLastInsertId();
        var chiTietPhieuTraList = new List<ChiTietPhieuTra>();
        foreach (var item in listVd)
        {
            var chiTietPhieuTra = new ChiTietPhieuTra()
            {
                Id_PhieuTra = phieuTraId,
                Id_VatDung = item.Id_VatDung,
                TinhTrang = item.TinhTrang
            };
            chiTietPhieuTraList.Add(chiTietPhieuTra);
        }
        
        _dbContext.AddList(chiTietPhieuTraList);
        return _dbContext.SaveChange();
    }

    // public int AddPhieuTraReturnId(PhieuTra phieuTra)
    // {
    //     string query = "INSERT INTO PhieuTra (Id_ThanhVien, Id_NhanVien, ThoiGianTra, TinhTrang) VALUES (?, ?, ?, ?); SELECT LAST_INSERT_ID();";
    //     
    //     return _dbContext.AddLastInsertId(query, new Object[]
    //     {
    //         phieuTra.Id_ThanhVien,
    //         phieuTra.Id_NhanVien,
    //         phieuTra.NgayTra,
    //         phieuTra.TinhTrang,
    //     });
    // }

    public bool AddChiTietPhieuTra(ChiTietPhieuTra chiTietPhieuTra)
    {
        string query = "INSERT INTO ChiTietPhieuTra(Id_PhieuTra, Id_VatDung) VALUES (?, ?)";
        var result = _dbContext.ExecuteNonQuery(query, new object[]
        {
            chiTietPhieuTra.Id_PhieuTra,
            chiTietPhieuTra.Id_VatDung,
        });
        return result > 0;
    }

    public bool UpdatePhieuTra()
    {
        throw new NotImplementedException();
    }
}