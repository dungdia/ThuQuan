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
using DesktopClient.DTO.ApiRequestDTO;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Interface;
using DesktopClient.Models;
using DesktopClient.UI.CustomControls;
using DesktopClient.UI.Dialog;
using OfficeOpenXml;

namespace DesktopClient.UI
{
    public partial class MemberPanel : UserControl, IChildPanel
    {
        List<ThanhVienDTO> thanhViens;
        public MemberPanel()
        {
            InitializeComponent();

            // Thêm cột checkbox
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Chon";
            checkBoxColumn.Name = "Select";
            checkBoxColumn.FillWeight = 30;
            ThanhVienTable.Columns.Add(checkBoxColumn);
            refeshTable("all", "");
        }

        public void refeshTable()
        {
            refeshTable("all", "");
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
            ThanhVienTable.Columns["id_thanhvien"].ReadOnly = true;

            ThanhVienTable.Columns["hoten"].HeaderText = "Họ tên";
            ThanhVienTable.Columns["hoten"].ReadOnly = true;

            ThanhVienTable.Columns["sodienthoai"].HeaderText = "Số điện thoại";
            ThanhVienTable.Columns["sodienthoai"].ReadOnly = true;

            ThanhVienTable.Columns["tinhtrang"].HeaderText = "Tình trạng";
            ThanhVienTable.Columns["tinhtrang"].ReadOnly = true;

            ThanhVienTable.Columns["email"].HeaderText = "Email";
            ThanhVienTable.Columns["email"].DisplayIndex = 7;
            ThanhVienTable.Columns["email"].ReadOnly = true;

            // Visible
            ThanhVienTable.Columns["id_taiKhoan"].Visible = false;
            ThanhVienTable.Columns["username"].Visible = false;
            ThanhVienTable.Columns["ngaythamgia"].Visible = false;
            ThanhVienTable.Columns["password"].Visible = false;
        }

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

                if (cellValue == "Đã bị khoá")
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
                return;
            }
            MessageBox.Show(response.Content);
            refeshTable("all", "");
            return;
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

        private void Xoa_Event(object sender, EventArgs e)
        {
            Debug.WriteLine("Xóa thành viên");

            var selectedMembers = ThanhVienTable.Rows
                .Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells["Select"].Value))
                .Select(row => row.DataBoundItem as ThanhVienDTO)
                .ToList();
            selectedMembers.ForEach(x => Debug.WriteLine("id_thanhvien: " + x.id_thanhvien + "id_taikhoan: " + x.id_taikhoan));
            if (selectedMembers.Count > 0)
            {
                var deleteDialog = new DeleteMemeberDialog(selectedMembers);
                deleteDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một thành viên để xóa");
            }
        }

        private void ThanhVienTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ThanhVienTable.IsCurrentCellDirty)
            {
                ThanhVienTable.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            Thread staThread = new Thread(() =>
            {
                using OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Chọn file excel danh sách thành viên";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Debug.WriteLine(openFileDialog.FileName);

                    var filePath = openFileDialog.FileName;
                    ExcelPackage.License.SetNonCommercialPersonal("Thêm danh sách thành viên");

                    using var package = new ExcelPackage(new FileInfo(filePath));
                    var worksheet = package.Workbook.Worksheets[0];
                    if (worksheet == null)
                    {
                        throw new Exception("Không tìm thấy worksheet nào trong file Excel.");
                    }

                    int rowCount = worksheet.Dimension.Rows;
                    if (rowCount < 2) 
                    {
                        throw new Exception("File Excel không có dữ liệu hoặc không đúng định dạng");
                    }

                    for (int row = 2; row <= rowCount; row++)
                    { 
                        string usernameTxt = worksheet.Cells[row, 1].Value?.ToString();
                        string emailTxt = worksheet.Cells[row, 2].Value?.ToString();
                        string passwordTxt = worksheet.Cells[row, 3].Value?.ToString();
                        string hotenTxt = worksheet.Cells[row, 4].Value?.ToString();
                        string sodienthoaiTxt = worksheet.Cells[row, 5].Value?.ToString();

                        var data = new ThanhVienDTO
                        { 
                            username = usernameTxt,
                            email = emailTxt,
                            password = passwordTxt,
                            hoten = hotenTxt,
                            sodienthoai = sodienthoaiTxt,
                            ngaythamgia = DateTime.Now
                        };

                        var response = APIContext.PostMethod("Admin/AddThanhVien", data);
                        if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            var error = APIContext.getErrorMessage(response);
                            MessageBox.Show(error);
                        }
                        MessageBox.Show(response.Content, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
        }
    }
}
