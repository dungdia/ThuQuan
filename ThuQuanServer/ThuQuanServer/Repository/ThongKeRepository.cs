using System.Collections;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class ThongKeRepository : IThongKeRepository
{
    private readonly DbContext _dbContext;

    public ThongKeRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Dictionary<string,object>> ThongKeLichSuNgay(DateTime ngay)
    {
        string date = ngay.ToString("yyyy-MM-dd");
        string query = @"
            SELECT DATE(thoigianvao) AS Ngay, COUNT(*) AS SoLuong 
            FROM lichsu
            WHERE DATE(lichsu.thoigianvao) = ?
            GROUP BY DATE(thoigianvao)
            ";
        var thongKeNgay = _dbContext.ExcuteQuerry(query, date);
        return thongKeNgay;
    }

    public IEnumerable<Dictionary<string, object>> ThongKeLichSuKhoangNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
    {
        string startDate = ngayBatDau.ToString("yyyy-MM-dd");
        string endDate = ngayKetThuc.ToString("yyyy-MM-dd");
        string query = @"
            WITH RECURSIVE dates AS (
              SELECT DATE(?) AS Ngay
              UNION ALL
              SELECT DATE_ADD(Ngay, INTERVAL 1 DAY)
              FROM dates
              WHERE Ngay < ?
            )
            SELECT d.Ngay, COUNT(l.thoigianvao) AS SoLuong
            FROM dates d
            LEFT JOIN lichsu l ON DATE(l.thoigianvao) = d.Ngay
            GROUP BY d.Ngay
            ORDER BY d.Ngay
            ";
        var thongKeLichSu = _dbContext.ExcuteQuerry(query, startDate, endDate);
        return thongKeLichSu;
    }
}