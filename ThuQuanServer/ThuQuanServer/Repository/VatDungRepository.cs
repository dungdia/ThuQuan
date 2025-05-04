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

    public VatDung VatDungById(int id)
    {
        string query = "SELECT * FROM VatDung WHERE id = @id";
        var result = _dbContext.GetFirstOrDefault<VatDung>(query, new { id });
        return result;
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

    public bool updateListTinhTrangDaDat(int[] listId)
    {
        foreach (var id in listId)
            _dbContext.Update<VatDung>(new { TinhTrang = "Đã đặt" }, id);
        return _dbContext.SaveChange();
    }

    public bool updateTinhTrangDaMuon(int id)
    {
        _dbContext.Update<VatDung>(new { TinhTrang = "Đang mượn" }, id);
        return _dbContext.SaveChange();
    }
    
    public bool updateTinhTrangChuaMuon(int id)
    {
            _dbContext.Update<VatDung>(new { TinhTrang = "Chưa mượn" }, id);
        return _dbContext.SaveChange();
    }
    
    public bool updateTinhTrangBiHong(int id)
    {
            _dbContext.Update<VatDung>(new { TinhTrang = "Bị hỏng" }, id);
        return _dbContext.SaveChange();
    }
    
    public ICollection<VatDung> GetVaTDungBooked()
    {
        string query = "SELECT * FROM VaTDung WHERE TinhTrang != ?";
        
        var vatDung = _dbContext.GetData<VatDung>(query,"Chưa mượn");
        return vatDung;
    }

    public bool UpdateTinhTrangAn(int id)
    {
        // Truy vấn trạng thái hiện tại của vật dụng
        string checkQuery = "SELECT TinhTrang FROM VatDung WHERE id = @id";
        using var connection = _dbContext.GetOpenConnection();
    
        var currentStatus = connection.ExecuteScalar<string>(checkQuery, new { id });

        if (string.IsNullOrEmpty(currentStatus))
        {
            return false;
        }
    
        if (currentStatus == "Chưa mượn" || currentStatus == "Bị hỏng")
        {
            // Thực hiện cập nhật trạng thái
            string query = "UPDATE VatDung SET TinhTrang = @TinhTrangAn WHERE id = @id";
            var result = connection.Execute(query, new { TinhTrangAn = "Ẩn", id });
        
            return result > 0; 
        }

        return false;
    }



    
    public ICollection<VatDung> GetBook()
    {
        string query = "SELECT * FROM VatDung WHERE id_loaivatdung = 1 AND tinhtrang != ?";

    
        var vatDung = _dbContext.GetData<VatDung>(
            query,
            "Ẩn"
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

    public ICollection<VatDung> GetThreeBook(int loaiVatDung)
    {
        string query = @"
            SELECT *FROM VatDung
            Where id_loaivatdung = @loaivatdung
            AND tinhtrang != @TinhTrangAn
            ORDER BY id;
        ";
        
        using var connection = _dbContext.GetOpenConnection();

        var allVatDung  = connection.Query<VatDung>(
            query,
            new
            {
                LoaiVatDung = loaiVatDung,
                TinhTrangAn = "Ẩn"
            }
        ).ToList();

        var result = new List<VatDung>();

        if (allVatDung.Count >= 1)
        {
            result.Add(allVatDung.First());
        }

        if (allVatDung.Count >= 3)
        {
            result.Add(allVatDung[allVatDung.Count / 2]);
        }
        
        if(allVatDung.Count >= 2)
            result.Add(allVatDung.Last());
        
        return result;
    }

    public ICollection<VatDung> GetDevice()
    {
        string query = "SELECT * FROM VatDung Where id_loaivatdung = 2 AND tinhtrang !=?";
        var vatDung = _dbContext.GetData<VatDung>(
            query,
            new object[] { "Ẩn" }
        );
        
        return vatDung;
    }

    public PageResultVatDungBooks<VatDung> GetVatDungDevices(string search, int page, int pageSize)
    {
        int offset = (page-1)*pageSize;
        string hiddenStatus = "Ẩn";
        string query = @"
            SELECT * FROM VatDung
            WHERE (@search IS NULL OR tenvatdung LIKE CONCAT('%',@search, '%'))
            AND id_loaivatdung = 2
            AND tinhtrang != @TinhTrangAn
            ORDER BY id
            LIMIT @pageSize OFFSET @offset;

            SELECT COUNT(*) FROM VatDung
            WHERE(@search IS NULL OR tenvatdung LIKE CONCAT('%', @search, '%'))
            AND id_loaivatdung = 2
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