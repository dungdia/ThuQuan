using DesktopClient.Models;
using System.ComponentModel.DataAnnotations;

namespace DesktopClient.DTO.ApiRequestDTO;

public class AddPhieuTraRequestDTO
{
    public ChiTietPhieuTra[] listItem { get; set; }
    public int id_phieumuon { get; set; }
    public int id_thanhvien { get; set; }
}
