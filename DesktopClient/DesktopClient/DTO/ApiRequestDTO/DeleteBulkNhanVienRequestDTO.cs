using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.DTO.ApiRequestDTO
{
    public class DeleteBulkNhanVienRequestDTO
    {
        public int id_taikhoan { get; set; }
        public int id_thanhvien { get; set; }
    }
}
