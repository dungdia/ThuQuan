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
using DesktopClient.Models;
using DesktopClient.UI.Dialog;

namespace DesktopClient.UI.Panels
{
    public partial class HistoryPanel : UserControl
    {

        List<LichSuDTO> NhanvienList = new List<LichSuDTO>();

        public HistoryPanel()
        {
            InitializeComponent();
            refeshTable("all", "");
        }

        public void refeshTable(string type, string value)
        {
            NhanvienList = APIContext.GetMethod<LichSuDTO>($"LichSu/GetThanhVien");
            if (type == "id")
            {
                NhanvienList = NhanvienList.Where(x => x.id_thanhvien.ToString().StartsWith(value, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            NhanvienList = NhanvienList.GroupBy(x => x.id_thanhvien).Select(x => x.First()).ToList();
            LichSuTable.DataSource = NhanvienList;

            LichSuTable.Columns["id_thanhvien"].HeaderText = "ID";
            LichSuTable.Columns["id_thanhvien"].FillWeight = 30;
            LichSuTable.Columns["hoten"].HeaderText = "Họ tên";
            LichSuTable.Columns["sodienthoai"].HeaderText = "Số điện thoại";
            LichSuTable.Columns["tinhtrang"].HeaderText = "Tình trạng";
            //ThanhVienTable.Columns["email"].HeaderText = "Email";
            //ThanhVienTable.Columns["email"].DisplayIndex = 7;

            //// Visible
            LichSuTable.Columns["id_lichsu"].Visible = false;
            LichSuTable.Columns["thoigianvao"].Visible = false;
            //ThanhVienTable.Columns["password"].Visible = false;

        }

        private void CheckEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("Check");

            var idx = LichSuTable.CurrentRow.Index;
            var currentRows = LichSuTable.Rows[idx];

            var idThanhVien = Convert.ToInt32(currentRows.Cells["id_thanhvien"].Value.ToString());
            Debug.WriteLine(idThanhVien);

            var tinhtrang = currentRows.Cells["tinhtrang"].Value.ToString();
            Debug.WriteLine(tinhtrang);
            // Cái này ngoài đời check đc
            if (tinhtrang == "Đã bị khóa")
            {
                MessageBox.Show("Thành viên đang bị khóa", "Thoại báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var response = APIContext.PostMethod($"LichSu/CheckLichSuVao?idThanhVien={idThanhVien}", null);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var error = APIContext.getErrorMessage(response);
                MessageBox.Show(error);
            }
            MessageBox.Show(response.Content);
            refeshTable("all", "");
        }

        private void XemLichSuEvent(object sender, EventArgs e)
        {
            var historyDialog = new HistoryDialog(null, "", this);
            historyDialog.ShowDialog();
        }

        private void SearchEvent(object sender, EventArgs e)
        {
            var input = search_Input.Text;
            refeshTable("id", input);
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
