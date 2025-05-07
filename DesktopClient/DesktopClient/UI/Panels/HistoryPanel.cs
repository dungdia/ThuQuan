using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Interface;
using DesktopClient.Models;
using DesktopClient.UI.Dialog;
using static OfficeOpenXml.ExcelErrorValue;

namespace DesktopClient.UI.Panels
{
    public partial class HistoryPanel : UserControl,IChildPanel
    {

        List<ThanhVienDTO> NhanvienList = new List<ThanhVienDTO>();

        public HistoryPanel()
        {
            InitializeComponent();
            refeshTable("all", "");
        }

        public void refeshTable()
        {
            refeshTable("all", "");
        }

        public void refeshTable(string type, string value)
        {
            NhanvienList = APIContext.GetMethod<ThanhVienDTO>($"Admin/GetThanhVien");
            if (type == "phone")
            {
                NhanvienList = NhanvienList.Where(x => x.sodienthoai.ToString().StartsWith(value, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            LichSuTable.DataSource = NhanvienList;

            LichSuTable.Columns["id_thanhvien"].HeaderText = "ID";
            LichSuTable.Columns["id_thanhvien"].FillWeight = 30;

            // Visible
            LichSuTable.Columns["id_taikhoan"].Visible = false;
            LichSuTable.Columns["username"].Visible = false;
            LichSuTable.Columns["email"].Visible = false;
            LichSuTable.Columns["password"].Visible = false;
            LichSuTable.Columns["ngaythamgia"].Visible = false;
        }

        private void CheckEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("Check");

            var idx = LichSuTable.CurrentRow.Index;
            var currentRows = LichSuTable.Rows[idx];

            var idThanhVien = Convert.ToInt32(currentRows.Cells["id_thanhvien"].Value.ToString());
            Debug.WriteLine(idThanhVien);

            var tinhtrang = currentRows.Cells["tinhtrang"].Value.ToString();
            // Cái này ngoài đời check đc
            if (tinhtrang == "Đã bị khoá")
            {
                MessageBox.Show("Thành viên đang bị khóa", "Thoại báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var response = APIContext.PostMethod($"LichSu/CheckLichSuVao?idThanhVien={idThanhVien}", null);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var error = APIContext.getErrorMessage(response);
                    MessageBox.Show(error);
                } else
                {
                    MessageBox.Show(response.Content);
                }
                refeshTable("all", "");
            }
        }

        private void XemLichSuEvent(object sender, EventArgs e)
        {
            var historyDialog = new HistoryDialog(null, "", this);
            historyDialog.ShowDialog();
        }

        private void SearchEvent(object sender, EventArgs e)
        {
            var input = search_Input.Text;
            refeshTable("phone", input);
        }

        private void LichSuTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void XemEvent(object sender, EventArgs e)
        {
            var idx = LichSuTable.CurrentRow.Index;
            var currentRows = LichSuTable.Rows[idx];

            var selectedIdThanhVien = Convert.ToInt32(currentRows.Cells["id_thanhvien"].Value.ToString());

            var historyDialog = new HistoryDialog(selectedIdThanhVien, "Xem", this);
            historyDialog.ShowDialog();
        }
    }
}
