using DesktopClient.APIs;
using DesktopClient.DTO.ApiRequestDTO;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Models;
using DesktopClient.UI.Panels;
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
    public partial class StaffDialog : Form
    {
        private NhanVienDTO _nhanVienDTO;
        private string _type;
        public StaffPanel _parent;
        public StaffDialog(NhanVienDTO? NhanVienDTO, string? type, StaffPanel? parent)
        {
            InitializeComponent();
            _nhanVienDTO = NhanVienDTO;
            _type = type;
            _parent = parent;
            Text = $"{type} nhân viên";
            addBtn.Visible = false;
            saveBtn.Visible = false;
            closeBtn.Visible = true;

            idTextbox.Text = NhanVienDTO.id.ToString();
            fullNameTextbox.Text = NhanVienDTO.hoten;
            genderCombobox.Text = NhanVienDTO.gioitinh;
            phoneNumberTextbox.Text = NhanVienDTO.sodienthoai;
            addressTextbox.Text = NhanVienDTO.diachi;
            statusCombobox.Text = NhanVienDTO.tinhtrang;
            usernameTextbox.Text = NhanVienDTO.username;
            emailTextbox.Text = NhanVienDTO.email;
            accountIdTextbox.Text = NhanVienDTO.id_taikhoan.ToString();
            joinedDateTextbox.Text = NhanVienDTO.ngaythamgia.ToString("dd/MM/yyyy");

            if (type == "Xem chi tiết")
            {
                usernameTextbox.ReadOnly = true;
                usernameTextbox.Enter += PreventFocus;
                idTextbox.ReadOnly = true;
                idTextbox.Enter += PreventFocus;
                fullNameTextbox.ReadOnly = true;
                fullNameTextbox.Enter += PreventFocus;
                genderCombobox.Enabled = false;
                genderCombobox.Enter += PreventFocus;
                phoneNumberTextbox.ReadOnly = true;
                phoneNumberTextbox.Enter += PreventFocus;
                addressTextbox.ReadOnly = true;
                addressTextbox.Enter += PreventFocus;
                statusCombobox.Enabled = false;
                statusCombobox.Enter += PreventFocus;
                emailTextbox.ReadOnly = true;
                emailTextbox.Enter += PreventFocus;
                joinedDateTextbox.ReadOnly = true;
                joinedDateTextbox.Enter += PreventFocus;
                accountIdTextbox.ReadOnly = true;
                accountIdTextbox.Enter += PreventFocus;
            }
            else if (type == "Sửa")
            {
                idTextbox.ReadOnly = true;
                idTextbox.Enter += PreventFocus;
                usernameTextbox.ReadOnly = true;
                usernameTextbox.Enter += PreventFocus;
                joinedDateTextbox.ReadOnly = true;
                joinedDateTextbox.Enter += PreventFocus;
                accountIdTextbox.ReadOnly = true;
                accountIdTextbox.Enter += PreventFocus;
                statusCombobox.Enabled = false;
                statusCombobox.Enter += PreventFocus;
                saveBtn.Visible = true;
            }
            else if (type == "Thêm")
            {
                idTextbox.Text = String.Empty;
                idTextbox.ReadOnly = true;
                idTextbox.Enter += PreventFocus;
                fullNameTextbox.Text = String.Empty;
                genderCombobox.SelectedIndex = 0;
                phoneNumberTextbox.Text = String.Empty;
                addressTextbox.Text = String.Empty;
                statusCombobox.SelectedIndex = 0;
                usernameTextbox.Text = String.Empty;
                emailTextbox.Text = String.Empty;
                accountIdTextbox.Text = String.Empty;
                accountIdTextbox.ReadOnly = true;
                accountIdTextbox.Enter += PreventFocus;
                joinedDateTextbox.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                joinedDateTextbox.ReadOnly = true;
                joinedDateTextbox.Enter += PreventFocus;
                addBtn.Visible = true;
            }
        }

        private void PreventFocus(object sender, EventArgs e)
        {
            this.ActiveControl = closeBtn;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_nhanVienDTO.id.ToString());
            var confirmResult = MessageBox.Show("Xác nhận lưu thông tin nhân viên?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                if (fullNameTextbox.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập họ tên nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (phoneNumberTextbox.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (addressTextbox.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (emailTextbox.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập email nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var nhanVien = new UpdateNhanVienRequestDTO
                {
                    hoten = fullNameTextbox.Text,
                    diachi = addressTextbox.Text,
                    gioitinh = genderCombobox.Text,
                    sodienthoai = phoneNumberTextbox.Text,
                    email = emailTextbox.Text,
                };

                var result = APIContext.PostMethod($"UpdateNhanVienById?idNhanVien={_nhanVienDTO.id}", nhanVien);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(result.Content, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _parent.refreshTable();
                    this.Close();
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Xác nhận thêm nhân viên?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                if(fullNameTextbox.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập họ tên nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                if(phoneNumberTextbox.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (addressTextbox.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (usernameTextbox.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (emailTextbox.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập email nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var newNhanVien = new AddNhanVienAndAccountRequestDTO
                    {
                        hoten = fullNameTextbox.Text,
                        sodienthoai = phoneNumberTextbox.Text,
                        gioitinh = genderCombobox.Text,
                        diachi = addressTextbox.Text,
                        email = emailTextbox.Text,
                        username = usernameTextbox.Text,
                        password = "123456", // Set password mặc định
                        ngaythamgia = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssZ"),
                        tinhtrang = statusCombobox.Text,
                    };
                var result = APIContext.PostMethod($"InsertNhanVienAndTheirAccount", newNhanVien);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(result.Content, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _parent.refreshTable();
                    this.Close();
                }
            }
        }
    }
}
