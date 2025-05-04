using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.DTO.ApiResponseDTO
{
    public class ThanhVienDTO
    {
        public int id_taikhoan { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime ngaythamgia { get; set; }
        public int id_thanhvien { get; set; }
        public string hoten { get; set; }
        public string sodienthoai { get; set; }
        public string tinhtrang { get; set; }

        public String ToString() { 
            return $"{id_taikhoan} - {username} - {email} - {password} - {ngaythamgia} - {id_thanhvien} - {hoten} - {sodienthoai} - {tinhtrang}";
        }
    }
}
