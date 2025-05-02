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

namespace DesktopClient.UI
{
    public partial class ItemPanel : UserControl
    {
        List<VatDung> vatDungs = new List<VatDung>();
        public ItemPanel()
        {
            InitializeComponent();
            vatDungs = APIContext.GetMethod<VatDung>("VatDung");
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
    }
}
