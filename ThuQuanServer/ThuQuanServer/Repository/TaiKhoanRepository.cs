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
    
    public ThanhVien? GetThanhVienById(int id)
    {
        string query = "SELECT * FROM ThanhVien WHERE Id_taikhoan = ?";
        var thanhVien = _dbContext.GetData<ThanhVien>(query, id).FirstOrDefault();
        return thanhVien;
    }

    public ThanhVien? GetThanhVienByIdThanhVien(int id)
    {
        string query = @"SELECT * FROM Thanhvien WHERE Id = ?";
        var thanhvien = _dbContext.GetData<ThanhVien>(query, id).FirstOrDefault();
        return thanhvien;
    }
    
    public NhanVien GetNhanVienById(int id)
    {
        string query = "SELECT * FROM NhanVien WHERE id_taikhoan = ?";
        var nhanVien = _dbContext.GetData<NhanVien>(query, id).FirstOrDefault();
        return nhanVien;
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

    public bool CheckTaiKhoanExist(string email)
    {
        string query = "SELECT * FROM TaiKhoan WHERE Email = ?";
        var taiKhoan = _dbContext.GetData<TaiKhoan>(query, email);
        return taiKhoan.Count > 0;
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

    public TaiKhoan ChangePassword(string email, string newPassword)
    {
        var query = "SELECT * From TaiKhoan WHERE email=?";   
        var taikhoan = _dbContext.GetData<TaiKhoan>(query,email).FirstOrDefault();

        if (taikhoan == null)
        {
            throw new Exception("Tài khoản không tồn tại");
        }
        
        string hasPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
        
        var updateQuery = "UPDATE TaiKhoan SET Password =? WHERE email =?";
        _dbContext.ExecuteNonQuery(updateQuery, hasPassword,email);
        
        taikhoan.Password = hasPassword;
        return taikhoan;
    }

    public ICollection<TaiKhoan> GetTaiKhoanByEmail(string email)
    {
        string query = "SELECT * FROM TaiKhoan WHERE Email = ?";
        var taiKhoan = _dbContext.GetData<TaiKhoan>(query, email);
        return taiKhoan;
    }
  
}