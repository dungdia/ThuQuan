using DesktopClient.APIs;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Interface;
using DesktopClient.Models;
using DesktopClient.UI.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DesktopClient.UI.Panels
{
    public partial class StaffPanel : UserControl,IChildPanel
    {
        List<NhanVienDTO> nhanViens = new List<NhanVienDTO>();
        public StaffPanel()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            refreshTable();
        }

        public void refeshTable()
        {
            refreshTable();
        }

        public void refreshTable()
        {
            nhanViens = APIContext.GetMethod<NhanVienDTO>($"GetNhanVienAndTheirAccount?type=Tất cả");
            dataGridView1.DataSource = nhanViens;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["hoTen"].HeaderText = "Họ tên";
            dataGridView1.Columns["soDienThoai"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["id_TaiKhoan"].Visible = false;
            dataGridView1.Columns["gioiTinh"].HeaderText = "Giới tính";
            dataGridView1.Columns["diaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
            dataGridView1.Columns["username"].HeaderText = "Tên tài khoản";
            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["ngaythamgia"].HeaderText = "Ngày tham gia";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nhanViens = APIContext.GetMethod<NhanVienDTO>($"GetNhanVienAndTheirAccount?type={comboBox1.SelectedItem.ToString()}");
            dataGridView1.DataSource = nhanViens;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["hoTen"].HeaderText = "Họ tên";
            dataGridView1.Columns["soDienThoai"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["id_TaiKhoan"].Visible = false;
            dataGridView1.Columns["gioiTinh"].HeaderText = "Giới tính";
            dataGridView1.Columns["diaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
            dataGridView1.Columns["username"].HeaderText = "Tên tài khoản";
            dataGridView1.Columns["username"].Visible = false;
            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["email"].Visible = false;
            dataGridView1.Columns["ngaythamgia"].HeaderText = "Ngày tham gia";
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0) return;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void viewDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.CurrentCell.RowIndex;
            var id = dataGridView1.Rows[index].Cells["id"].Value.ToString();
            var selectedNhanVien = new NhanVienDTO()
            {
                id = Convert.ToInt32(id),
                hoten = dataGridView1.Rows[index].Cells["hoTen"].Value.ToString(),
                sodienthoai = dataGridView1.Rows[index].Cells["soDienThoai"].Value.ToString(),
                gioitinh = dataGridView1.Rows[index].Cells["gioiTinh"].Value.ToString(),
                diachi = dataGridView1.Rows[index].Cells["diaChi"].Value.ToString(),
                id_taikhoan = Convert.ToInt32(dataGridView1.Rows[index].Cells["id_TaiKhoan"].Value.ToString()),
                tinhtrang = dataGridView1.Rows[index].Cells["tinhTrang"].Value.ToString(),
                username = dataGridView1.Rows[index].Cells["username"].Value.ToString(),
                email = dataGridView1.Rows[index].Cells["email"].Value.ToString(),
                ngaythamgia = Convert.ToDateTime(dataGridView1.Rows[index].Cells["ngaythamgia"].Value.ToString())
            };

            var dialog = new StaffDialog(selectedNhanVien, "Xem chi tiết", this);
            dialog.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.CurrentCell.RowIndex;
            var id = dataGridView1.Rows[index].Cells["id"].Value.ToString();
            var selectedNhanVien = new NhanVienDTO()
            {
                id = Convert.ToInt32(id),
                hoten = dataGridView1.Rows[index].Cells["hoTen"].Value.ToString(),
                sodienthoai = dataGridView1.Rows[index].Cells["soDienThoai"].Value.ToString(),
                gioitinh = dataGridView1.Rows[index].Cells["gioiTinh"].Value.ToString(),
                diachi = dataGridView1.Rows[index].Cells["diaChi"].Value.ToString(),
                id_taikhoan = Convert.ToInt32(dataGridView1.Rows[index].Cells["id_TaiKhoan"].Value.ToString()),
                tinhtrang = dataGridView1.Rows[index].Cells["tinhTrang"].Value.ToString(),
                username = dataGridView1.Rows[index].Cells["username"].Value.ToString(),
                email = dataGridView1.Rows[index].Cells["email"].Value.ToString(),
                ngaythamgia = Convert.ToDateTime(dataGridView1.Rows[index].Cells["ngaythamgia"].Value.ToString())
            };

            var dialog = new StaffDialog(selectedNhanVien, "Sửa", this);
            dialog.ShowDialog();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var dialog = new StaffDialog(new NhanVienDTO(), "Thêm", this);
            dialog.ShowDialog();
        }
        private void accountLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.CurrentCell.RowIndex;
            var id = dataGridView1.Rows[index].Cells["id"].Value.ToString();
            var status = dataGridView1.Rows[index].Cells["tinhTrang"].Value.ToString();
            //MessageBox.Show(id);
            if (status == "Đang làm việc")
            {
                var confirmResult = MessageBox.Show("Xác nhận khóa tài khoản nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    var response = APIContext.PostMethod($"LockAccountNhanVien?idNhanVien={id}", null);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Khóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshTable();
                    }
                    else
                    {
                        MessageBox.Show(response.Content, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                var confirmResult = MessageBox.Show("Xác nhận mở khóa tài khoản nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    var response = APIContext.PostMethod($"UnlockAccountNhanVien?idNhanVien={id}", null);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Mở khóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshTable();
                    }
                    else
                    {
                        MessageBox.Show(response.Content, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchText = searchTextbox.Text.ToLower();
            var result = nhanViens.Where(
                nv => nv.hoten.ToLower().Contains(searchText) ||
                nv.sodienthoai.ToLower().Contains(searchText) ||
                nv.gioitinh.ToLower().Contains(searchText) ||
                nv.diachi.ToLower().Contains(searchText) ||
                (nv.tinhtrang != null && nv.tinhtrang.ToLower().Contains(searchText)) ||
                nv.username.ToLower().Contains(searchText) ||
                nv.email.ToLower().Contains(searchText) ||
                nv.ngaythamgia.ToString("dd/MM/yyyy").Contains(searchText)
            ).ToList();

            dataGridView1.DataSource = result;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            searchTextbox.Text = "";
            comboBox1.SelectedIndex = 0;
            refreshTable();
        }

    }
}
