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
using DesktopClient.Models;
using DesktopClient.UI.Dialog;

namespace DesktopClient.UI.Panels
{
    public partial class BorrowPanel : UserControl
    {
        public BorrowPanel()
        {
            InitializeComponent();
            typeDropDown.SelectedItem = "Tất cả";
        }
        
        public void refeshTable()
        {
            var response = APIContext.GetMethod<PhieuMuonDTO>($"GetPhieuMuon?type=Tất cả");
            phieuMuonTable.DataSource = response;
            phieuMuonTable.Columns["id"].FillWeight = 30;
            phieuMuonTable.Columns["id_thanhvien"].FillWeight = 60;
            phieuMuonTable.Columns["id_nhanvien"].FillWeight = 60;
            phieuMuonTable.Columns["tinhtrang"].FillWeight = 70;
            phieuMuonTable.Columns["id"].HeaderText = "ID";
            phieuMuonTable.Columns["id_thanhvien"].HeaderText = "ID Thành Viên";
            phieuMuonTable.Columns["ten_thanhvien"].HeaderText = "Tên Thành Viên";
            phieuMuonTable.Columns["id_nhanvien"].HeaderText = "ID Nhân viên";
            phieuMuonTable.Columns["ten_nhanvien"].HeaderText = "Tên Nhân Viên";
            phieuMuonTable.Columns["thoigianmuon"].HeaderText = "Thời Gian Mượn";
            phieuMuonTable.Columns["thoigiantra"].HeaderText = "Thời Gian Trả";
            phieuMuonTable.Columns["tinhtrang"].HeaderText = "Tình Trạng";
        }

        private void typeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var response = APIContext.GetMethod<PhieuMuonDTO>($"GetPhieuMuon?type={typeDropDown.SelectedItem.ToString()}");
            phieuMuonTable.DataSource = response;
            phieuMuonTable.Columns["id"].FillWeight = 30;
            phieuMuonTable.Columns["id_thanhvien"].FillWeight = 60;
            phieuMuonTable.Columns["id_nhanvien"].FillWeight = 60;
            phieuMuonTable.Columns["tinhtrang"].FillWeight = 70;
            phieuMuonTable.Columns["id"].HeaderText = "ID";
            phieuMuonTable.Columns["id_thanhvien"].HeaderText = "ID Thành Viên";
            phieuMuonTable.Columns["ten_thanhvien"].HeaderText = "Tên Thành Viên";
            phieuMuonTable.Columns["id_nhanvien"].HeaderText = "ID Nhân viên";
            phieuMuonTable.Columns["ten_nhanvien"].HeaderText = "Tên Nhân Viên";
            phieuMuonTable.Columns["thoigianmuon"].HeaderText = "Thời Gian Mượn";
            phieuMuonTable.Columns["thoigiantra"].HeaderText = "Thời Gian Trả";
            phieuMuonTable.Columns["tinhtrang"].HeaderText = "Tình Trạng";
        }

        private void phieuMuonTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0) return;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (phieuMuonTable.CurrentRow == null)
            {
                MessageBox.Show("Không có một hàng để chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var idx = phieuMuonTable.CurrentRow.Index;
            //var id = phieuMuonTable.Rows[idx].Cells["id"].Value.ToString();
            if (idx < 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xem chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            var selectedItem = new PhieuMuonDTO()
            {
                id = int.Parse(phieuMuonTable.Rows[idx].Cells["id"].Value.ToString()),
                id_thanhvien = int.Parse(phieuMuonTable.Rows[idx].Cells["id_thanhvien"].Value.ToString()),
                id_nhanvien = int.Parse(phieuMuonTable.Rows[idx].Cells["id_nhanvien"].Value.ToString()),
                ten_thanhvien = phieuMuonTable.Rows[idx].Cells["ten_thanhvien"].Value.ToString(),
                ten_nhanvien = phieuMuonTable.Rows[idx].Cells["ten_nhanvien"].Value.ToString(),
                thoigianmuon = DateTime.Parse(phieuMuonTable.Rows[idx].Cells["thoigianmuon"].Value.ToString()),
                thoigiantra = DateTime.Parse(phieuMuonTable.Rows[idx].Cells["thoigiantra"].Value.ToString()),
                tinhtrang = phieuMuonTable.Rows[idx].Cells["tinhtrang"].Value.ToString()
            };

            var borrowPanel = new BorrowDialog(selectedItem, "Xem", this);
            borrowPanel.ShowDialog();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = new PhieuMuonDTO();

            var borrowPanel = new BorrowDialog(item, "Tạo", this);
            borrowPanel.ShowDialog();
        }

        private void phieuMuonTable_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
