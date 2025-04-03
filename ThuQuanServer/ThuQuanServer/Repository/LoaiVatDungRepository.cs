using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class LoaiVatDungRepository : ILoaiVatDungRepository
{
    private readonly DbContext _dbContext;

    public LoaiVatDungRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public ICollection<LoaiVatDung> GetLoaiVatDung()
    {
        string query = "SELECT * FROM LoaiVatDung";
        var loaiVatDung = _dbContext.GetData<LoaiVatDung>(query);
        return loaiVatDung;
    }

    public ICollection<LoaiVatDung> GetLoaiVatDungByProps(object? values)
    {
        var p = values.GetType().GetProperties();

        var query = "SELECT * FROM LoaiVatDung WHERE ";
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

        var loaiVatDung = _dbContext.GetData<LoaiVatDung>(query, props);
        
        return loaiVatDung;
    }

    public bool AddLoaiVatDung(LoaiVatDungRequestDto loaiVatDung)
    {
        _dbContext.Add<LoaiVatDung>(loaiVatDung);

        return _dbContext.SaveChange();
    }

    public bool UpdateLoaiVatDung(LoaiVatDungRequestDto loaiVatDung, int id)
    {
        _dbContext.Update<LoaiVatDung>(loaiVatDung, id);
        
        return _dbContext.SaveChange();
    }
}