using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.Models;
using RestSharp;
using DesktopClient.APIs;
using DesktopClient.DTO;
using DesktopClient.DTO.ApiResponseDTO;

namespace DesktopClient
{
    public partial class LoginFrame : Form
    {
        public LoginFrame()
        {
            InitializeComponent();
            //Thêm vào cho tiện đỡ nhập lại thôi
            emailInput.Text = "dung@gmail.com";
            passwordInput.Text = "1234567";
        }

        public void resetState()
        {
            emailInput.Text = "";
            passwordInput.Text = "";
        }

        private void LoginFrame_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (emailInput.Text == "")
            {
                MessageBox.Show("Không được bỏ trống email", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (passwordInput.Text == "")
            {
                MessageBox.Show("Không được bỏ trống password", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var adminRequest = new adminloginRequestDTO()
            {
                email = emailInput.Text,
                password = passwordInput.Text
            };
            var response = APIContext.PostMethod($"adminlogin", adminRequest);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var errorMessage = APIContext.getErrorMessage(response);
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultDictionary = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Object>>(response.Content);
            var result = APIContext.ConvertToModel<AdminLoginDTO>(resultDictionary);
            MessageBox.Show("Đăng nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Open Main Frame with login account have access token and username
            var mainFrame = new MainFrame(result, this);
            Hide();
            mainFrame.Show();
        }

        // Hàm bấm bằng nút Enter khi đăng nhập
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                button1.PerformClick(); // Mô phỏng một cú nhấp chuột
                return true; // Chỉ ra rằng phím nhấn đã được xử lý
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
