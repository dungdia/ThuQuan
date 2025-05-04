using DesktopClient.APIs;
using DesktopClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient.UI.Dialog
{
    public partial class AddVatDungDialog : Form
    {
        public event Action? OnItemAdded;
        public AddVatDungDialog()
        {
            InitializeComponent();
            type_combobox.Items.Insert(0, "-- Chọn loại --");
            type_combobox.SelectedIndex = 0;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {

            Regex nameRegex = new Regex(@"\S.{2,}");      // Tên: ít nhất 3 ký tự
            Regex otherRegex = new Regex(@"\S.{4,}");     // Mô tả & hình ảnh: ít nhất 5 ký tự

            if (!nameRegex.IsMatch(name_item.Text))
            {
                MessageBox.Show("Tên vật dụng phải chứa ít nhất 3 ký tự.");
                return;
            }

            if (!otherRegex.IsMatch(img_item.Text))
            {
                MessageBox.Show("Hình ảnh phải chứa ít nhất 5 ký tự.");
                return;
            }

            if (!otherRegex.IsMatch(desc_item.Text))
            {
                MessageBox.Show("Mô tả phải chứa ít nhất 5 ký tự.");
                return;
            }

            if (type_combobox.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn loại vật dụng.");
                return;
            }

            try
            {
                var data = new
                {
                    tenVatDung = name_item.Text,
                    hinhAnh = img_item.Text,
                    moTa = desc_item.Text,
                    id_LoaiVatDung = type_combobox.SelectedIndex == 1 ? 1 : 2
                };

                var response = APIContext.PostMethod("VatDung", data);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Thêm vật dụng thành công!");
                }
                else
                {
                    var errorMessage = APIContext.getErrorMessage(response);
                    MessageBox.Show("Thêm vật dụng thất bại: " + errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                // Gọi sự kiện OnItemAdded sau khi thêm thành công
                OnItemAdded?.Invoke();
                this.Close();
            }
        }

    }
}
