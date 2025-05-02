using DesktopClient.APIs;
using DesktopClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient.UI.Panels
{
    public partial class StaffPanel : UserControl
    {
        List<NhanVien> nhanViens = new List<NhanVien>();
        public StaffPanel()
        {
            InitializeComponent();
            nhanViens = APIContext.GetMethod<NhanVien>("GetNhanVien");
            dataGridView1.DataSource = nhanViens;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["hoTen"].HeaderText = "Họ tên";
            dataGridView1.Columns["soDienThoai"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["id_TaiKhoan"].Visible = false;
            dataGridView1.Columns["gioiTinh"].HeaderText = "Giới tính";
            dataGridView1.Columns["diaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }
    }
}
