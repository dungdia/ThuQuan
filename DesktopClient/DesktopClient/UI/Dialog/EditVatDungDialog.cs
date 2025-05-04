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
    public partial class EditVatDungDialog : Form
    {
        public event Action? OnItemUpdated; // Sự kiện thông báo xóa thành công  
        private VatDung _vatDung;

        public EditVatDungDialog(VatDung vatDung)
        {
            InitializeComponent();
            _vatDung = vatDung;

            name_item.Text = vatDung.tenVatDung;
            img_item.Text = vatDung.hinhAnh;
            desc_item.Text = vatDung.moTa;

            // Initialize type_combobox  
            type_combobox.FormattingEnabled = true;
            type_combobox.Items.AddRange(new object[] { "Sách", "Thiết bị" });
            type_combobox.SelectedIndex = vatDung.id_LoaiVatDung == 1 ? 0 : 1;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show($"Bạn chắc chắn muốn sửa vật dụng ID {_vatDung.id} này?",
                "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.No)
            {
                return;
            }
            else
            {
                try
                {
                    VatDung vatDung = new VatDung()
                    {
                        id = _vatDung.id,
                        tenVatDung = name_item.Text,
                        hinhAnh = img_item.Text,
                        moTa = desc_item.Text,
                        id_LoaiVatDung = type_combobox.SelectedIndex == 0 ? 1 : 2,
                        tinhTrang = _vatDung.tinhTrang
                    };
                    var response = await APIContext.PutMethodAsync("VatDung/" + vatDung.id, vatDung);

                    if (!response.IsSuccessful)
                    {
                        MessageBox.Show($"Sửa vật dụng ID {vatDung.id} thất bại. " + APIContext.getErrorMessage(response),
                                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Vật dụng đã được sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Gọi sự kiện OnItemUpdated để thông báo cho các form khác
                    OnItemUpdated?.Invoke();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi cập nhật: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void desc_item_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


    }
}
