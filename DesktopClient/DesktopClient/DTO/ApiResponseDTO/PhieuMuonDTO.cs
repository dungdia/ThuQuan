namespace DesktopClient.DTO.ApiResponseDTO;

public class PhieuMuonDTO
{
    public int id { get; set; }
    public int id_thanhvien { get; set; }
    public string ten_thanhvien { get; set; }
    public int id_nhanvien { get; set; }
    public string ten_nhanvien { get; set; }
    public DateTime thoigianmuon { get; set; }
    public DateTime thoigiantra { get; set; }
    public string tinhtrang { get; set; }
}
