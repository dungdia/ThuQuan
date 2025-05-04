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
using DesktopClient.Models;
using DesktopClient.Contains;
using System.Net.Http.Headers;
using DesktopClient.UI.Dialog;

namespace DesktopClient.UI
{
    public partial class ItemPanel : UserControl
    {
        List<VatDung> vatDungs = new List<VatDung>();
        public ItemPanel()
        {
            InitializeComponent();
            vatDungs = APIContext.GetMethod<VatDung>("VatDung")
                  .Where(v => v.tinhTrang != TinhTrangVatDung.Ẩn.ToString())
                  .ToList();
            dataGridView1.DataSource = vatDungs;
            dataGridView1.CellFormatting += cellFormatting;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["tenVatDung"].HeaderText = "Tên vật dụng";
            dataGridView1.Columns["hinhAnh"].Visible = false;
            dataGridView1.Columns["moTa"].HeaderText = "Mô tả";
            dataGridView1.Columns["id_LoaiVatDung"].HeaderText = "Loại vật dụng";
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }

        private void cellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check xem cột hiện tại có phải là cột "id_LoaiVatDung" không
            if (dataGridView1.Columns[e.ColumnIndex].Name == "id_LoaiVatDung" && e.Value != null)
            {
                // Đổi từ string sang int và check
                int idValue = Convert.ToInt32(e.Value);
                e.Value = idValue == 1 ? "Sách" : "Thiết bị";
                e.FormattingApplied = true;
            }
        }



        // Nút xóa vật dụng
        private void delete_item_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedVatDungs = dataGridView1.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(row => (VatDung)row.DataBoundItem)
                    .ToList();

                var deleteDialog = new DeleteVatDungDialog(selectedVatDungs)
                {
                    StartPosition = FormStartPosition.Manual
                };
                deleteDialog.Location = new Point(450, 100);

                // Lắng nghe sự kiện OnItemsDeleted
                deleteDialog.OnItemsDeleted += ReloadData;

                deleteDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một vật dụng cần xóa.");
            }
        }

        // Nút sửa vật dụng
        private void edit_item_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedVatDung = (VatDung)dataGridView1.SelectedRows[0].DataBoundItem;
                var editDialog = new EditVatDungDialog(selectedVatDung)
                {
                    StartPosition = FormStartPosition.Manual
                };
                editDialog.Location = new Point(this.Location.X + 500, this.Location.Y + 250); // Đặt vị trí hiển thị
                // Lắng nghe sự kiện OnItemsDeleted
                editDialog.OnItemUpdated += ReloadData;
                editDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một vật dụng để sửa.");
            }
        }

        // Nút thêm vật dụng
        private void add_item_Click(object sender, EventArgs e)
        {
            var addDialog = new AddVatDungDialog()
            {
                StartPosition = FormStartPosition.CenterParent // Đặt vị trí hiển thị ở giữa
            };
            // Lắng nghe sự kiện OnItemAdded
            addDialog.OnItemAdded += ReloadData;
            addDialog.ShowDialog();
        }

        // Hàm làm mới dữ liệu
        private void ReloadData()
        {
            vatDungs = APIContext.GetMethod<VatDung>("VatDung")
                .Where(v => v.tinhTrang != TinhTrangVatDung.Ẩn.ToString())
                .ToList();
            dataGridView1.DataSource = null; // bỏ dữ liệu cũ
            dataGridView1.DataSource = vatDungs; // Gán dữ liệu mới
            // Đảm bảo không đăng ký trùng sự kiện
            dataGridView1.CellFormatting -= cellFormatting;
            dataGridView1.CellFormatting += cellFormatting;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["tenVatDung"].HeaderText = "Tên vật dụng";
            dataGridView1.Columns["hinhAnh"].Visible = false;
            dataGridView1.Columns["moTa"].HeaderText = "Mô tả";
            dataGridView1.Columns["id_LoaiVatDung"].HeaderText = "Loại vật dụng";
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }

        private void loadData()
        {
            // Đảm bảo không đăng ký trùng sự kiện
            dataGridView1.CellFormatting -= cellFormatting;
            dataGridView1.CellFormatting += cellFormatting;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["tenVatDung"].HeaderText = "Tên vật dụng";
            dataGridView1.Columns["hinhAnh"].Visible = false;
            dataGridView1.Columns["moTa"].HeaderText = "Mô tả";
            dataGridView1.Columns["id_LoaiVatDung"].HeaderText = "Loại vật dụng";
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }

        private void text_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string searchText = text_search.Text.ToLower();

            var filteredVatDungs = vatDungs
                .Where(vatDung => vatDung.tenVatDung.ToLower().Contains(searchText) ||
                                 vatDung.id_LoaiVatDung == 1 && "Sách".ToLower().Contains(searchText) ||
                                 vatDung.id_LoaiVatDung != 1 && "Thiết bị".ToLower().Contains(searchText) ||
                                 vatDung.tinhTrang.ToLower().Contains(searchText))
                .ToList();

            dataGridView1.DataSource = null; // bỏ dữ liệu cũ
            dataGridView1.DataSource = filteredVatDungs; // Gán dữ liệu mới
            loadData();
        }

        // Hàm bấm bằng nút Enter
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                search_btn.PerformClick(); // Mô phỏng một cú nhấp chuột
                return true; // Chỉ ra rằng phím nhấn đã được xử lý
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
