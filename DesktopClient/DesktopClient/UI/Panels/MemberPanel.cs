using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.DTO;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Models;
using DesktopClient.UI.CustomControls;
using DesktopClient.UI.Dialog;

namespace DesktopClient.UI
{
    public partial class MemberPanel : UserControl
    {
        List<ThanhVienDTO> thanhViens;
        public MemberPanel()
        {
            InitializeComponent();
            refeshTable("all", "");
        }

        public string RemoveAccentsSimple(string text)
        {
            if (text == null) return null;

            // Normalize the text to FormD (decomposed form)
            text = text.Normalize(NormalizationForm.FormD);

            // Remove all characters that are NonSpacingMark (diacritics)
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public void refeshTable(string type, string value)
        {
            thanhViens = APIContext.GetMethod<ThanhVienDTO>("Admin/GetThanhVien");

            switch (type)
            {
                case "all": break;
                // Tìm theo những ký tự đầu tiên
                case "name": thanhViens = thanhViens.Where(x => x.hoten.ToString().StartsWith(value, StringComparison.OrdinalIgnoreCase)).ToList(); break;
            }

            ThanhVienTable.DataSource = thanhViens;
            ThanhVienTable.Columns["id_thanhvien"].HeaderText = "ID";
            ThanhVienTable.Columns["id_thanhvien"].FillWeight = 30;
            ThanhVienTable.Columns["hoten"].HeaderText = "Họ tên";
            ThanhVienTable.Columns["sodienthoai"].HeaderText = "Số điện thoại";
            ThanhVienTable.Columns["tinhtrang"].HeaderText = "Tình trạng";
            ThanhVienTable.Columns["email"].HeaderText = "Email";
            ThanhVienTable.Columns["email"].DisplayIndex = 7;

            // Visible
            ThanhVienTable.Columns["id_taiKhoan"].Visible = false;
            ThanhVienTable.Columns["username"].Visible = false;
            ThanhVienTable.Columns["ngaythamgia"].Visible = false;
            ThanhVienTable.Columns["password"].Visible = false;

        }

        //private void panel1_Click(object sender, EventArgs e)
        //{
        //    var response = APIContext.PostMethod("insertLoaiVatDung", new LoaiVatDungDTO(""));
        //    string message = APIContext.translateResponse(response.Content);
        //    MessageBox.Show(message);
        //}

        private void EditEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("Edit Event");

            var idx = ThanhVienTable.CurrentRow.Index;
            var currentRows = ThanhVienTable.Rows[idx];

            var selectedItem = new ThanhVienDTO
            {
                id_taikhoan = Convert.ToInt32(currentRows.Cells["id_taikhoan"].Value.ToString()),
                id_thanhvien = Convert.ToInt32(currentRows.Cells["id_thanhvien"].Value.ToString()),
                username = currentRows.Cells["username"].Value.ToString(),
                email = currentRows.Cells["email"].Value.ToString(),
                ngaythamgia = DateTime.Parse(currentRows.Cells["ngaythamgia"].Value.ToString()),
                hoten = currentRows.Cells["hoten"].Value.ToString(),
                sodienthoai = currentRows.Cells["sodienthoai"].Value.ToString(),
                tinhtrang = currentRows.Cells["tinhtrang"].Value.ToString()
            };

            var updateDialog = new MemberDialog(selectedItem, "Cập nhật", this);
            updateDialog.ShowDialog();
        }

        private void OptionEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0) return;
                contextMenuStrip1.Show(Cursor.Position);

                string cellValue = ThanhVienTable.Rows[e.RowIndex].Cells["tinhtrang"].Value?.ToString();

                string normalizedCellValue = RemoveAccentsSimple(cellValue);

                if (normalizedCellValue == "Đa bi khoa")
                {
                    contextMenuStrip1.Items[2].Text = "Mở khóa";
                }
                else
                {
                    contextMenuStrip1.Items[2].Text = "Khóa";
                }
            }
        }

        private void ThanhVienTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void LockEvent(object sender, EventArgs e)
        {
            var idx = ThanhVienTable.CurrentRow.Index;
            var currentRows = ThanhVienTable.Rows[idx];

            var _idThanhVien = Convert.ToInt32(currentRows.Cells["id_thanhvien"].Value.ToString());
            Debug.WriteLine(_idThanhVien);
            var option = contextMenuStrip1.Items[2].Text;

            var response = APIContext.PostMethod($"Admin/KhoaThanhVien?idThanhVien={_idThanhVien}&type={option}", null);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var error = APIContext.getErrorMessage(response);
                MessageBox.Show(error);
            }
            MessageBox.Show(response.Content);
            refeshTable("all", "");
        }

        private void RegisterEvent(object sender, EventArgs e)
        {
            var registerDialog = new RegisterMemberDialog(this);
            registerDialog.ShowDialog();
        }

        private void SearchEvent(object sender, EventArgs e)
        {
            var value = timkiem_Input.Text;
            refeshTable("name", value);
        }

        private void XemEvent(object sender, EventArgs e)
        {
            // Boilerplate
            var idx = ThanhVienTable.CurrentRow.Index;
            var currentRows = ThanhVienTable.Rows[idx];

            var selectedItem = new ThanhVienDTO
            {
                id_taikhoan = Convert.ToInt32(currentRows.Cells["id_taikhoan"].Value.ToString()),
                id_thanhvien = Convert.ToInt32(currentRows.Cells["id_thanhvien"].Value.ToString()),
                username = currentRows.Cells["username"].Value.ToString(),
                email = currentRows.Cells["email"].Value.ToString(),
                ngaythamgia = DateTime.Parse(currentRows.Cells["ngaythamgia"].Value.ToString()),
                hoten = currentRows.Cells["hoten"].Value.ToString(),
                sodienthoai = currentRows.Cells["sodienthoai"].Value.ToString(),
                tinhtrang = currentRows.Cells["tinhtrang"].Value.ToString()
            };

            
            var updateDialog = new MemberDialog(selectedItem, "Xem", this);
            updateDialog.ShowDialog();
        }
    }
}
