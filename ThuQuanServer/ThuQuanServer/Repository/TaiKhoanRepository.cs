using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Dtos.Response;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class TaiKhoanRepository : ITaiKhoanRepository
{
    private readonly DbContext _dbContext;

    public TaiKhoanRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<TaiKhoan> GetAccount()
    {
        string query = "SELECT * FROM TaiKhoan";
        var taiKhoan = _dbContext.GetData<TaiKhoan>(query);
        return taiKhoan;
    }

    public ThanhVien? GetAccountThanhVienByEmailTaiKhoan(object? values)
    {
        // Kiểm tra null hoặc không có thuộc tính
        if (values == null) return null;

        var props = values.GetType().GetProperties();
        if (props.Length == 0) return null;

        // Tạo điều kiện WHERE với bảng TaiKhoan (alias t)
        var whereClause = string.Join(" AND ", props.Select(p => $"t.{p.Name} = ?"));

        // Câu truy vấn lấy thông tin từ bảng ThanhVien
        var query = @"
        SELECT tv.* 
        FROM TaiKhoan t
        JOIN ThanhVien tv ON t.Id = tv.Id_TaiKhoan
        WHERE " + whereClause + " LIMIT 1"; // Chỉ lấy 1 dòng

        // Lấy giá trị tham số
        var propValues = props.Select(p => p.GetValue(values)).ToArray();

        // Trả về đối tượng đầu tiên hoặc null nếu không có
        return _dbContext.GetData<ThanhVien>(query, propValues).FirstOrDefault();
    }


   

    public ICollection<TaiKhoan> GetAccountByProps(object? values)
    {
        var p = values.GetType().GetProperties();

        var query = "SELECT * FROM TaiKhoan WHERE ";
        if (p.Length == 1)
        {
            query += string.Join("", p.Select(p => p.Name)) + "=?";
        }
        else
        {
            query += string.Join("=? AND ", p.Select(p => p.Name)) + "=?";
        }

        Console.WriteLine(query);

        var props = p.Select(p => p.GetValue(values)).ToArray();

        var taiKhoan = _dbContext.GetData<TaiKhoan>(query, props);
        return taiKhoan;
    }

    public ICollection<ThanhVien> GetThanhVien()
    {
        string query = "SELECT * FROM ThanhVien";
        var thanhVien = _dbContext.GetData<ThanhVien>(query);
        return thanhVien;
    }

    public bool AddThanhVien(TaikhoanInsertDTO taikhoan)
    {
        // Add TaiKhoan
        _dbContext.Add<TaiKhoan>(taikhoan);
        var lastInsertId = _dbContext.GetLastInsertId();
        Console.WriteLine(lastInsertId);
        
        // Create new ThanhVien
        ThanhVienRequestDto thanhvien = new ThanhVienRequestDto();
        thanhvien.Id_TaiKhoan = lastInsertId;
        thanhvien.HoTen = "";
        thanhvien.SoDienThoai = "";
        thanhvien.TinhTrang = 1;
        _dbContext.Add<ThanhVien>(thanhvien);
        
        // Save changes
        return _dbContext.SaveChange();
    }

    public bool UpdateThanhVien(ThanhVienRequestDto thanhvien, int idThanhVien)
    {
        // Update thanhvien
        _dbContext.Update<ThanhVien>(thanhvien, idThanhVien);
        
        // Save 
        return _dbContext.SaveChange();
    }

    public bool UpdateTaiKhoan(TaikhoanInsertDTO taikhoan, int idTaiKhoan)
    {
        _dbContext.Update<TaiKhoan>(taikhoan, idTaiKhoan);
        
        return _dbContext.SaveChange(); 
    }
    
    public bool UpdateThanhVien(ThanhVienUpdateResponseDTO thanhvien, int idThanhVien)
    {
        _dbContext.Update<ThanhVien>(thanhvien, idThanhVien);
        return _dbContext.SaveChange();
    }

    public bool UpdateTaiKhoan(TaiKhoanUpdateResponseDTO taikhoan, int idTaiKhoan)
    {
        _dbContext.Update<TaiKhoan>(taikhoan, idTaiKhoan);
        return _dbContext.SaveChange();
    }
}