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
    public partial class PenaltyPanel : UserControl,IChildPanel
    {
        public PenaltyPanel()
        {
            InitializeComponent();
            typeDropDown.SelectedIndex = 0;
        }

        public void refeshTable()
        {
            var response = APIContext.GetMethod<PhieuPhatDTO>($"GetPhieuPhat?type=Tất cả");
            phieuPhatTable.DataSource = response;
            phieuPhatTable.Columns["id"].FillWeight = 30;
            phieuPhatTable.Columns["id_thanhvien"].FillWeight = 60;
            phieuPhatTable.Columns["id"].HeaderText = "ID";
            phieuPhatTable.Columns["id_thanhvien"].HeaderText = "ID Thành Viên";
            phieuPhatTable.Columns["hoten"].HeaderText = "Tên Thành Viên";
            phieuPhatTable.Columns["lydo"].HeaderText = "Lý Do";
            phieuPhatTable.Columns["mucphat"].HeaderText = "Mức Phạt";
            phieuPhatTable.Columns["tinhtrang"].HeaderText = "Tình Trạng";
        }

        private void typeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var response = APIContext.GetMethod<PhieuPhatDTO>($"GetPhieuPhat?type={typeDropDown.SelectedItem.ToString()}");
            phieuPhatTable.DataSource = response;
            phieuPhatTable.Columns["id"].FillWeight = 30;
            phieuPhatTable.Columns["id_thanhvien"].FillWeight = 60;
            phieuPhatTable.Columns["id"].HeaderText = "ID";
            phieuPhatTable.Columns["id_thanhvien"].HeaderText = "ID Thành Viên";
            phieuPhatTable.Columns["hoten"].HeaderText = "Tên Thành Viên";
            phieuPhatTable.Columns["lydo"].HeaderText = "Lý Do";
            phieuPhatTable.Columns["mucphat"].HeaderText = "Mức Phạt";
            phieuPhatTable.Columns["tinhtrang"].HeaderText = "Tình Trạng";
        }

        private void phieuPhatTable_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void fineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (phieuPhatTable.CurrentRow == null)
            {
                MessageBox.Show("Không có phiếu phạt nào để thực hiện hành động này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idx = phieuPhatTable.CurrentRow.Index;

            if (idx < 0)
            {
                MessageBox.Show("Lựa chọn một phiếu phạt nào để thực hiện hành động này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phieuPhatDTO = new PhieuPhatDTO()
            {
                id = int.Parse(phieuPhatTable.Rows[idx].Cells["id"].Value.ToString()),
                id_thanhvien = int.Parse(phieuPhatTable.Rows[idx].Cells["id_thanhvien"].Value.ToString()),
                lydo = phieuPhatTable.Rows[idx].Cells["lydo"].Value.ToString(),
                mucphat = phieuPhatTable.Rows[idx].Cells["mucphat"].Value.ToString(),
                tinhtrang = phieuPhatTable.Rows[idx].Cells["tinhtrang"].Value.ToString(),
                hoten = phieuPhatTable.Rows[idx].Cells["hoten"].Value.ToString()
            };

            if (phieuPhatDTO.tinhtrang == "Đã xử lý")
            {
                MessageBox.Show("Phiếu phạt này đã được xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (phieuPhatDTO.tinhtrang == "Đã huỷ")
            {
                MessageBox.Show("Phiếu phạt này đã bị huỷ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var penaltyDialog = new PenaltyDialog(this, "Xử lý", phieuPhatDTO);
            penaltyDialog.ShowDialog();

        }

        private void addButton_Click(object sender, EventArgs e)
        {


            var phieuPhatDTO = new PhieuPhatDTO();

            var penaltyDialog = new PenaltyDialog(this, "Tạo", phieuPhatDTO);
            penaltyDialog.ShowDialog();
        }

        private void editPhiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (phieuPhatTable.CurrentRow == null)
            {
                MessageBox.Show("Không có phiếu phạt nào để thực hiện hành động này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idx = phieuPhatTable.CurrentRow.Index;

            if (idx < 0)
            {
                MessageBox.Show("Lựa chọn một phiếu phạt nào để thực hiện hành động này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phieuPhatDTO = new PhieuPhatDTO()
            {
                id = int.Parse(phieuPhatTable.Rows[idx].Cells["id"].Value.ToString()),
                id_thanhvien = int.Parse(phieuPhatTable.Rows[idx].Cells["id_thanhvien"].Value.ToString()),
                lydo = phieuPhatTable.Rows[idx].Cells["lydo"].Value.ToString(),
                mucphat = phieuPhatTable.Rows[idx].Cells["mucphat"].Value.ToString(),
                tinhtrang = phieuPhatTable.Rows[idx].Cells["tinhtrang"].Value.ToString(),
                hoten = phieuPhatTable.Rows[idx].Cells["hoten"].Value.ToString()
            };

            if (phieuPhatDTO.tinhtrang == "Đã huỷ")
            {
                MessageBox.Show("Không thể sửa phiếu đã huỷ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var penaltyDialog = new PenaltyDialog(this, "Sửa", phieuPhatDTO);
            penaltyDialog.ShowDialog();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (phieuPhatTable.CurrentRow == null)
            {
                MessageBox.Show("Không có phiếu phạt nào để thực hiện hành động này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idx = phieuPhatTable.CurrentRow.Index;

            if (idx < 0)
            {
                MessageBox.Show("Lựa chọn một phiếu phạt nào để thực hiện hành động này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var id = int.Parse(phieuPhatTable.Rows[idx].Cells["id"].Value.ToString());
            var tinhtrang = phieuPhatTable.Rows[idx].Cells["tinhtrang"].Value.ToString();



            if (tinhtrang != "Đã xuất phiếu")
            {
                MessageBox.Show("Chỉ có thể huỷ phiếu chưa xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn huỷ phiếu phạt này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            var response = APIContext.PostMethod($"HuyPhieuPhat?id_phieuphat={id}", "");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var errorMessage = APIContext.getErrorMessage(response);
                MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Huỷ phiếu phạt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refeshTable();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (phieuPhatTable.CurrentRow == null)
            {
                MessageBox.Show("Không có phiếu phạt nào để thực hiện hành động này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idx = phieuPhatTable.CurrentRow.Index;

            if (idx < 0)
            {
                MessageBox.Show("Lựa chọn một phiếu phạt nào để thực hiện hành động này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var id = int.Parse(phieuPhatTable.Rows[idx].Cells["id"].Value.ToString());
            var tinhtrang = phieuPhatTable.Rows[idx].Cells["tinhtrang"].Value.ToString();



            if (tinhtrang != "Đã xuất phiếu" && tinhtrang != "Đã huỷ")
            {
                MessageBox.Show("Chỉ có thể huỷ phiếu chưa xử lý hoặc đã huỷ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn huỷ phiếu phạt này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            var response = APIContext.PostMethod($"XoaPhieuPhat?id_phieuphat={id}", "");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var errorMessage = APIContext.getErrorMessage(response);
                MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Huỷ phiếu phạt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refeshTable();
            }
        }
    }
}
