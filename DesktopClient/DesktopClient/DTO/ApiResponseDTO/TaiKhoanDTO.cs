using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.DTO.ApiResponseDTO
{
    public class TaiKhoanDTO
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime ngaythamgia { get; set; }
        public int vaitro { get; set; }
        public string tinhtrang { get; set; }
    }
}
