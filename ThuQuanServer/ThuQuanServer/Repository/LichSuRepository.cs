using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class LichSuRepository : ILichSuRepository
{
    private readonly DbContext _dbContext;
    
    public LichSuRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<LichSu> GetLichSu()
    {
        string query = "SELECT * FROM LichSu";
        var lichSu = _dbContext.GetData<LichSu>(query);
        return lichSu;
    }

    public bool CheckLichSuVao(int? idThanhVien)
    {
        _dbContext.Add<LichSu>(new
        {
            ThoiGianVao = DateTime.Now,
            Id_ThanhVien = idThanhVien
        });
        
        // TODO: xử lý thành viên vi phạm 

        return _dbContext.SaveChange();
    }
}
