using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class PhieuPhatRequestDTO
{
    [Required]
    public int id { get; set; }
    [Required]
    public int Id_ThanhVien { get; set; }
    [Required]
    [MinLength(1,ErrorMessage = "Mức phạt không được để trống")]
    public string MucPhat { get; set; }
    [Required]
    [MinLength(1,ErrorMessage = "Lý do không được để trống")]
    public string LyDo { get; set; }
}