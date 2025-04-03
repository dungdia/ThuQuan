using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class LoaiVatDungRequestDto
{
    [Required(ErrorMessage = "Ten loai vat dung khong duoc de trong")]
    [MinLength(3, ErrorMessage = "Ten loai vat dung phai co it nhat 3 ky tu")]
    [MaxLength(100, ErrorMessage = "Ten loai vat dung khong duoc vuot qua 255 ky tu")]
    
    public string tenLoai { get; set; }
    
}