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
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Interface;
using DesktopClient.UI.Dialog;

namespace DesktopClient.UI.Panels
{
    public partial class ReturnPanel : UserControl,IChildPanel
    {
        public ReturnPanel()
        {
            InitializeComponent();
            typeDropDown.SelectedItem = typeDropDown.Items[0];
        }

        public void refeshTable()
        {
            var response = APIContext.GetMethod<PhieuTraDTO>($"GetPhieuTra?type=Tất cả");
            phieuTraTable.DataSource = response;
            phieuTraTable.Columns["id"].FillWeight = 30;
            phieuTraTable.Columns["id_thanhvien"].FillWeight = 60;
            phieuTraTable.Columns["id_nhanvien"].FillWeight = 60;
            phieuTraTable.Columns["tinhtrang"].FillWeight = 70;
            phieuTraTable.Columns["id"].HeaderText = "ID";
            phieuTraTable.Columns["id_thanhvien"].HeaderText = "ID Thành Viên";
            phieuTraTable.Columns["ten_thanhvien"].HeaderText = "Tên Thành Viên";
            phieuTraTable.Columns["id_nhanvien"].HeaderText = "ID Nhân viên";
            phieuTraTable.Columns["ten_nhanvien"].HeaderText = "Tên Nhân Viên";
            phieuTraTable.Columns["thoigiantra"].HeaderText = "Thời Gian Trả";
            phieuTraTable.Columns["tinhtrang"].HeaderText = "Tình Trạng";
        }

        private void typeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var response = APIContext.GetMethod<PhieuTraDTO>($"GetPhieuTra?type={typeDropDown.SelectedItem.ToString()}");
            phieuTraTable.DataSource = response;
            phieuTraTable.Columns["id"].FillWeight = 30;
            phieuTraTable.Columns["id_thanhvien"].FillWeight = 60;
            phieuTraTable.Columns["id_nhanvien"].FillWeight = 60;
            phieuTraTable.Columns["tinhtrang"].FillWeight = 70;
            phieuTraTable.Columns["id"].HeaderText = "ID";
            phieuTraTable.Columns["id_thanhvien"].HeaderText = "ID Thành Viên";
            phieuTraTable.Columns["ten_thanhvien"].HeaderText = "Tên Thành Viên";
            phieuTraTable.Columns["id_nhanvien"].HeaderText = "ID Nhân viên";
            phieuTraTable.Columns["ten_nhanvien"].HeaderText = "Tên Nhân Viên";
            phieuTraTable.Columns["thoigiantra"].HeaderText = "Thời Gian Trả";
            phieuTraTable.Columns["tinhtrang"].HeaderText = "Tình Trạng";

        }

        private void phieuTraTable_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (phieuTraTable.CurrentRow == null)
            {
                MessageBox.Show("Không có một hàng để chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var idx = phieuTraTable.CurrentRow.Index;
            if (idx < 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xem chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var phieuTraDTO = new PhieuTraDTO()
            {
                id = int.Parse(phieuTraTable.Rows[idx].Cells["id"].Value.ToString()),
                id_thanhvien = int.Parse(phieuTraTable.Rows[idx].Cells["id_thanhvien"].Value.ToString()),
                id_nhanvien = int.Parse(phieuTraTable.Rows[idx].Cells["id_nhanvien"].Value.ToString()),
                ten_thanhvien = phieuTraTable.Rows[idx].Cells["ten_thanhvien"].Value.ToString(),
                ten_nhanvien = phieuTraTable.Rows[idx].Cells["ten_nhanvien"].Value.ToString(),
                thoigiantra = DateTime.Parse(phieuTraTable.Rows[idx].Cells["thoigiantra"].Value.ToString()),
                tinhtrang = phieuTraTable.Rows[idx].Cells["tinhtrang"].Value.ToString(),
            };

            var returnDialog = new ReturnDialog(this, "Xem", phieuTraDTO);
            returnDialog.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var PhieuTraDTO = new PhieuTraDTO();
            var returnDialog = new ReturnDialog(this, "Tạo", PhieuTraDTO);
            returnDialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
