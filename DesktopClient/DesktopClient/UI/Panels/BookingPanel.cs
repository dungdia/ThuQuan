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
    public partial class BookingPanel : UserControl,IChildPanel
    {
        public BookingPanel()
        {
            InitializeComponent();
            typeDropDown.SelectedIndex = 0;
        }

        public void refeshTable()
        {
            var response = APIContext.GetMethod<PhieuDatDTO>($"getPhieuDatAdmin?type=Tất cả");
            phieuDatTable.DataSource = response;
            phieuDatTable.Columns["id"].FillWeight = 30;
            phieuDatTable.Columns["id_thanhvien"].FillWeight = 60;
            phieuDatTable.Columns["id"].HeaderText = "ID";
            phieuDatTable.Columns["id_thanhvien"].HeaderText = "ID Thành Viên";
            phieuDatTable.Columns["hoten"].HeaderText = "Họ Tên";
            phieuDatTable.Columns["ngaydat"].HeaderText = "Ngày Đặt";
            phieuDatTable.Columns["tinhtrang"].HeaderText = "Tình Trạng";
        }

        private void typeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var response = APIContext.GetMethod<PhieuDatDTO>($"getPhieuDatAdmin?type={typeDropDown.SelectedItem.ToString()}");
            phieuDatTable.DataSource = response;
            phieuDatTable.Columns["id"].FillWeight = 30;
            phieuDatTable.Columns["id_thanhvien"].FillWeight = 60;
            phieuDatTable.Columns["id"].HeaderText = "ID";
            phieuDatTable.Columns["id_thanhvien"].HeaderText = "ID Thành Viên";
            phieuDatTable.Columns["hoten"].HeaderText = "Họ Tên";
            phieuDatTable.Columns["ngaydat"].HeaderText = "Ngày Đặt";
            phieuDatTable.Columns["tinhtrang"].HeaderText = "Tình Trạng";
        }

        private void phieuDatTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0) return;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var idx = phieuDatTable.CurrentRow.Index;
            var id = phieuDatTable.Rows[idx].Cells["id"].Value.ToString();
            //MessageBox.Show($"{id}");
            var selectedItem = new PhieuDatDTO()
            {
                id = Int32.Parse(id),
                id_thanhvien = Int32.Parse(phieuDatTable.Rows[idx].Cells["id_thanhvien"].Value.ToString()),
                hoten = phieuDatTable.Rows[idx].Cells["hoten"].Value.ToString(),
                ngaydat = DateTime.Parse(phieuDatTable.Rows[idx].Cells["ngaydat"].Value.ToString()),
                tinhtrang = phieuDatTable.Rows[idx].Cells["tinhtrang"].Value.ToString()
            };
            var bookingDialog = new BookingDialog(selectedItem, "Xem", this);
            bookingDialog.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var idx = phieuDatTable.CurrentRow.Index;
            var id = phieuDatTable.Rows[idx].Cells["id"].Value.ToString();
            //MessageBox.Show($"{id}");
            var selectedItem = new PhieuDatDTO()
            {
                id = Int32.Parse(id),
                id_thanhvien = Int32.Parse(phieuDatTable.Rows[idx].Cells["id_thanhvien"].Value.ToString()),
                hoten = phieuDatTable.Rows[idx].Cells["hoten"].Value.ToString(),
                ngaydat = DateTime.Parse(phieuDatTable.Rows[idx].Cells["ngaydat"].Value.ToString()),
                tinhtrang = phieuDatTable.Rows[idx].Cells["tinhtrang"].Value.ToString()
            };
            if(selectedItem.tinhtrang != "Đã xuất phiếu")
            {
                MessageBox.Show("Không thể xử lý phiếu này","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            var bookingDialog = new BookingDialog(selectedItem, "Xử lý", this);
            bookingDialog.ShowDialog();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var idx = phieuDatTable.CurrentRow.Index;
            var id = phieuDatTable.Rows[idx].Cells["id"].Value.ToString();
            //MessageBox.Show($"{id}");
            var selectedItem = new PhieuDatDTO()
            {
                id = Int32.Parse(id),
                id_thanhvien = Int32.Parse(phieuDatTable.Rows[idx].Cells["id_thanhvien"].Value.ToString()),
                hoten = phieuDatTable.Rows[idx].Cells["hoten"].Value.ToString(),
                ngaydat = DateTime.Parse(phieuDatTable.Rows[idx].Cells["ngaydat"].Value.ToString()),
                tinhtrang = phieuDatTable.Rows[idx].Cells["tinhtrang"].Value.ToString()
            };

            if (selectedItem.tinhtrang != "Đã xuất phiếu")
            {
                MessageBox.Show("Bạn Không thể hủy phiếu này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu đặt này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {
                var response = APIContext.PostMethod($"HuyPhieuDat?id_phieudat={selectedItem.id}","");
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var error = APIContext.getErrorMessage(response);
                    MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Hủy phiếu đặt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            refeshTable();
        }
    }
}
