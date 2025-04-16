using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.DTO;
using DesktopClient.Models;
using DesktopClient.UI.CustomControls;

namespace DesktopClient.UI
{
    public partial class MemberPanel : UserControl
    {
        List<ThanhVien> thanhViens;
        public MemberPanel()
        {
            InitializeComponent();
            thanhViens = APIContext.GetMethod<ThanhVien>("GetThanhVien");
            dataGridView1.DataSource = thanhViens;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["hoTen"].HeaderText = "Họ tên";
            dataGridView1.Columns["soDienThoai"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["id_TaiKhoan"].Visible = false;
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var response = APIContext.PostMethod("insertLoaiVatDung", new LoaiVatDungDTO(""));
            string message = APIContext.translateResponse(response.Content);
            MessageBox.Show(message);
        }
    }
}
