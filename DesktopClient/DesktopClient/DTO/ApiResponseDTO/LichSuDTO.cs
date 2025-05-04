using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.DTO.ApiResponseDTO
{
    public class LichSuDTO
    {
        public int id_thanhvien { get; set; }
        public string hoten { get; set; }
        public string sodienthoai { get; set; }
        public string tinhtrang { get; set; }

        // 
        public int id_lichsu { get; set; }
        public DateTime thoigianvao { get; set; }
    }
}
