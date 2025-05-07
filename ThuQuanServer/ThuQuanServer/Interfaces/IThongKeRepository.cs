using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IThongKeRepository
{
    public IEnumerable<Dictionary<string,object>> ThongKeLichSuNgay(DateTime ngay);
    
    public IEnumerable<Dictionary<string,object>> ThongKeLichSuKhoangNgay(DateTime ngayBatDau, DateTime ngayKetThuc);
    
}