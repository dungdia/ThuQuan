using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class NhanVienRepository : INhanVienRepository
{
    private readonly DbContext _dbContext;

    public NhanVienRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<NhanVien> GetNhanVien()
    {
        string query = "SELECT * FROM NhanVien";
        var nhanvien = _dbContext.GetData<NhanVien>(query);
        return nhanvien;
    }

    public ICollection<NhanVien> GetNhanVienByProps(object? values)
    {
        var p = values.GetType().GetProperties();

        var query = "SELECT * FROM Nhanvien WHERE ";
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
        var nhanvien = _dbContext.GetData<NhanVien>(query,props);
        
        return nhanvien;
    }
}