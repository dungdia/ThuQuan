using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.DTO.ApiRequestDTO
{
    public class UpdateNhanVienRequestDTO
    {
        public string hoten { get; set; }
        public string sodienthoai { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public string email { get; set; }
    }
}
