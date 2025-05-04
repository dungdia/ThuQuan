using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.DTO.ApiResponseDTO
{
    public class NhanVienDTO
    {
        public int id { get; set; }
        public string hoten { get; set; }
        public string sodienthoai { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public int id_taikhoan { get; set; }
        public string? tinhtrang { get; set; }
    }
}
