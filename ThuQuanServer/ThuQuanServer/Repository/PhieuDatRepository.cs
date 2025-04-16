using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class PhieuDatRepository : IPhieuDatRepository
{
    private readonly DbContext _dbContext;

    public PhieuDatRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public ICollection<PhieuDat> GetPhieuDat()
    {
        string query = "SELECT * FROM PhieuDat";
        var phieuDat = _dbContext.GetData<PhieuDat>(query);
        return phieuDat;
    }

    public ICollection<PhieuDat> GetPhieuDatByIdThanhVien(int idThanhVien)
    {
        string query = "SELECT * FROM PhieuDat WHERE id_thanhvien = @0";
        return _dbContext.GetData<PhieuDat>(query, idThanhVien);
    }

    public ICollection<ChiTietPhieuDat> GetChiTietPhieuDatByIdPhieuDat(int idPhieuDat)
    {
        string query = "SELECT * FROM ChiTietPhieuDat WHERE id_phieudat = @0";
        return _dbContext.GetData<ChiTietPhieuDat>(query, idPhieuDat);
    }

    
    public ICollection<PhieuDat> GetPhieuDatByProps(object? values)
    {
        throw new NotImplementedException();
    }



    public bool AddPhieuDat(PhieuDat phieuDat, int[] vatDungIds)
    {
        // Thiết lập TrangThai mặc định là "Đã xuất phiếu"
        _dbContext.Add<PhieuDat>(phieuDat);
        var addPhieuDatResult = _dbContext.SaveChange();
        if (!addPhieuDatResult)
            return false;
        var phieuDatId = _dbContext.GetLastInsertId();
        var chiTietPhieuDatList = new List<ChiTietPhieuDat>();
        foreach (var vatDungId in vatDungIds)
        {
            var chiTietPhieuDat = new ChiTietPhieuDat()
            {
                Id_PhieuDat = phieuDatId,
                Id_VatDung = vatDungId
            };
            chiTietPhieuDatList.Add(chiTietPhieuDat);
        }

        _dbContext.AddList(chiTietPhieuDatList);
        return _dbContext.SaveChange();
    }
    
    public int AddPhieuDatReturnId(PhieuDat phieuDat)
    {
        string query = "INSERT INTO PhieuDat (Id_ThanhVien, NgayDat, TinhTrang) VALUES (?, ?, ?); SELECT LAST_INSERT_ID();";

        return _dbContext.AddLastInsertId(query, new object[]
        {
            phieuDat.Id_ThanhVien,
            phieuDat.NgayDat,
            phieuDat.TinhTrang,
        });
    }


    public bool AddChiTietPhieuDat(ChiTietPhieuDat chiTietPhieuDat)
    {
        string query = "INSERT INTO ChiTietPhieuDat(id_phieudat, id_vatdung) VALUES (?, ?)";
        var result = _dbContext.ExecuteNonQuery(query, new object[]
        {
            chiTietPhieuDat.Id_PhieuDat,
            chiTietPhieuDat.Id_VatDung
        });
        return result > 0;
    }


    public bool UpdatePhieuDat()
    {
        throw new NotImplementedException();
    }
}