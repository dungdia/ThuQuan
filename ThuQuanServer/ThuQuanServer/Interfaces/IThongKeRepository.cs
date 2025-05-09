using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IThongKeRepository
{
    public IEnumerable<Dictionary<string,object>> ThongKeLichSuNgay(DateTime ngay);
    
    public IEnumerable<Dictionary<string,object>> ThongKeLichSuKhoangNgay(string startDate, string endDate);
 
    public IEnumerable<Dictionary<string,object>> ThongKeVatDungMuon(string startDate, string endDate);
}