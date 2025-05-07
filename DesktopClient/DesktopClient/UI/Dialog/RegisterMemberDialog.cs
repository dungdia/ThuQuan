using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.DTO.ApiRequestDTO;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Models;

namespace DesktopClient.UI.Dialog
{
    public partial class RegisterMemberDialog : Form
    {
        public MemberPanel _parent;

        public RegisterMemberDialog(MemberPanel parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void ConfirmEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("Confirm");

            Debug.WriteLine("Username: " + username_Input.Text);
            Debug.WriteLine("Email: " + email_Input.Text);
            Debug.WriteLine("Password: " + password_Input.Text);
            Debug.WriteLine("Confirm Password: " + confirmPassword_Input.Text);

            var registerAccountRequestDTO = new RegisterAccountRequestDTO();

            registerAccountRequestDTO.username = username_Input.Text;
            registerAccountRequestDTO.email = email_Input.Text;
            registerAccountRequestDTO.password = password_Input.Text;

            if (password_Input.Text != confirmPassword_Input.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại Không khớp","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var response = APIContext.PostMethod("Admin/AddThanhVien", registerAccountRequestDTO);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var error = APIContext.getErrorMessage(response);
                    MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(response.Content);
                _parent.refeshTable("all", "");
            }
        }

        //private void RegisterAccountDialog_Load(object sender, EventArgs e)
        //{
        //}

        private void RegisterAccountDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
