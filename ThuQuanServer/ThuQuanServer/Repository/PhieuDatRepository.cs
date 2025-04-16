using ThuQuanServer.ApplicationContext;
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
    


    public bool AddPhieuDat(PhieuDat phieuDat)
    {
        // Thiết lập TrangThai mặc định là "Đã xuất phiếu"
        phieuDat.TinhTrang = "Đã xuất phiếu";

        // Truy vấn INSERT vào bảng PhieuDat
        string query = "INSERT INTO PhieuDat (Id_ThanhVien, NgayDat, tinhtrang) VALUES (?, ?, ?)";

        // Thực thi truy vấn
        var result = _dbContext.ExecuteNonQuery(query, new object[]
        {
            phieuDat.Id_ThanhVien,
            phieuDat.NgayDat,
            phieuDat.TinhTrang
        });

        // Trả về true nếu thêm thành công, ngược lại false
        return result > 0;
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