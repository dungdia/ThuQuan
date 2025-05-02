using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class PhieuMuonFromPhieuDatDTO
{
    [Required(ErrorMessage = "id_phieudat is required")]
    public int id_PhieuDat { get; set; }
    [Required(ErrorMessage = "ngayTra is required")]
    public DateTime ngayTra  { get; set; }
}