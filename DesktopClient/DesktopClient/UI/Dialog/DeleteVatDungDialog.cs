using DesktopClient.APIs;
using DesktopClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient.UI.Dialog
{
    public partial class DeleteVatDungDialog : Form
    {
        public event Action? OnItemsDeleted; // Sự kiện thông báo xóa thành công
        private List<VatDung> _vatDungs;
        //private VatDung _vatDung;
        public DeleteVatDungDialog(List<VatDung> vatDungs)
        {
            InitializeComponent();
            _vatDungs = vatDungs;

            // Hiển thị danh sách các vật dụng trong DataGridView
            VatDungGridView.DataSource = _vatDungs;
            VatDungGridView.CellFormatting += cellFormatting;
            VatDungGridView.Columns["id"].HeaderText = "ID";
            VatDungGridView.Columns["id"].FillWeight = 30;
            VatDungGridView.Columns["tenVatDung"].HeaderText = "Tên vật dụng";
            VatDungGridView.Columns["hinhAnh"].Visible = false;
            VatDungGridView.Columns["moTa"].HeaderText = "Mô tả";
            VatDungGridView.Columns["id_LoaiVatDung"].HeaderText = "Loại vật dụng";
            VatDungGridView.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }

        private void cellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check xem cột hiện tại có phải là cột "id_LoaiVatDung" không
            if (VatDungGridView.Columns[e.ColumnIndex].Name == "id_LoaiVatDung" && e.Value != null)
            {
                // Đổi từ string sang int và check
                int idValue = Convert.ToInt32(e.Value);
                e.Value = idValue == 1 ? "Sách" : "Thiết bị";
                e.FormattingApplied = true;
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private async void confirm_delete_item_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show($"Bạn chắc chắn muốn xóa {_vatDungs.Count} vật dụng này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    var successfullyDeleted = new List<VatDung>();
                    foreach (var vatDung in _vatDungs)
                    {
                        var vatDungDelete = new { Id = vatDung.id };
                        var response = await APIContext.PutMethodAsync("VatDung/An/" + vatDung.id, vatDungDelete);

                        if (response.IsSuccessful)
                        {
                            successfullyDeleted.Add(vatDung);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa vật dụng ID {vatDung.id} thất bại. " + APIContext.getErrorMessage(response),
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Các vật dụng đã xóa thì sẽ xóa khỏi deleteGridView
                    foreach (var deleteItem in successfullyDeleted)
                    {
                        _vatDungs.Remove(deleteItem);
                    }
                    VatDungGridView.DataSource = null;
                    VatDungGridView.DataSource = _vatDungs;

                    MessageBox.Show("Tất cả vật dụng đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnItemsDeleted?.Invoke(); // Gọi sự kiện khi xóa thành công
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
