using Dapper;
using MySql.Data.MySqlClient;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Contains;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class VatDungRepository : IVatDungRepository
{
    private readonly DbContext _dbContext;

    public VatDungRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public ICollection<VatDung> GetVatDung()
    {
        string query = "SELECT * FROM VatDung";
        var vatDung = _dbContext.GetData<VatDung>(query);
        return vatDung;
    }

    public ICollection<VatDung> GetVatDungByProps(object? values)
    {
        var p = values.GetType().GetProperties();
        var query = "SELECT * FROM VatDung WHERE ";
        if (p.Length == 1)
        {
            query+=string.Join("", p.Select(p => p.Name)) + "=?";
        }
        else
        {
            query += string.Join("=? AND ", p.Select(p => p.Name)) + "=?";
        }
        var props = p.Select(p=> p.GetValue(values)).ToArray();
        var vatDung = _dbContext.GetData<VatDung>(query, props);
        return vatDung;
    }

    public bool AddVatDung(VatDungRequestDto vatDungRequestDto)
    {
        _dbContext.Add<VatDung>(vatDungRequestDto);
        return _dbContext.SaveChange();
    }

    public bool UpdateVatDung(VatDungRequestDto vatDungRequestDto, int id)
    {
        _dbContext.Update<VatDung>(vatDungRequestDto, id);
        return _dbContext.SaveChange();
    }
    
    public ICollection<VatDung> GetBook()
    {
        string query = "SELECT * FROM VatDung WHERE id_loaivatdung = 1 AND tinhtrang != ?";

    
        var vatDung = _dbContext.GetData<VatDung>(
            query,
            new object[] {"Ẩn"}
        );

        return vatDung;
    }

    public PageResultVatDungBooks<VatDung> GetVatDungBooks(string search, int page, int pageSize)
    {
        int offset = (page - 1) * pageSize;
        string hiddenStatus = "Ẩn";

        string query = @"
            SELECT * FROM VatDung
            WHERE (@search IS NULL OR tenvatdung LIKE CONCAT('%', @search, '%'))
            AND id_loaivatdung = 1
            AND tinhtrang != @TinhTrangAn
            ORDER BY id 
            LIMIT @pageSize OFFSET @offset;

            SELECT COUNT(*) FROM VatDung
            WHERE (@search IS NULL OR tenvatdung LIKE CONCAT('%', @search, '%'))
            AND id_loaivatdung = 1
            AND tinhtrang != @TinhTrangAn;
        ";

        using var connection = _dbContext.GetOpenConnection(); 
        using var multi = connection.QueryMultiple(query, new
        {
            search = string.IsNullOrWhiteSpace(search) ? null : search,
            pageSize,
            offset,
            TinhTrangAn = hiddenStatus
        });

        var items = multi.Read<VatDung>().ToList();
        var totalItems = multi.ReadFirst<int>();

        return new PageResultVatDungBooks<VatDung>
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems
        };
    }
    
    
}