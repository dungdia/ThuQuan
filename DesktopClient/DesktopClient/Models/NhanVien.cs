using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Models
{
    public class NhanVien
    {
        public int id { get; set; }
        public string hoTen { get; set; }
        public string soDienThoai { get; set; }
        public string gioiTinh { get; set; }
        public string diaChi { get; set; }
        public int id_TaiKhoan { get; set; }
        public string? tinhTrang { get; set; }
    }
}
