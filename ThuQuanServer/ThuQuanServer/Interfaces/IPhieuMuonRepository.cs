using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IPhieuMuonRepository
{
    public ICollection<PhieuMuon> GetPhieuMuon();
    public ICollection<PhieuMuon> GetPhieuMuonByProps(object? values);
    public bool AddPhieuMuon(PhieuMuonInsertDTO phieuMuonInsertDto,int[] listId);
    public bool UpdatePhieuMuon(PhieuMuonInsertDTO phieuMuonInsertDto,int id);
    
}