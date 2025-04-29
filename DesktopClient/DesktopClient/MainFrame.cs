using DesktopClient.APIs;
using DesktopClient.DTO;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Models;
using DesktopClient.UI;
using Object = System.Object;

namespace DesktopClient
{
    public partial class MainFrame : Form
    {
        ItemPanel ItemPanel { get; set; }
        MemberPanel MemberPanel { get; set; }

        private LoginFrame _loginFrame;
        private AdminLoginDTO _adminLoginDTO;

        public MainFrame(AdminLoginDTO adminLoginDTO,LoginFrame loginFrame)
        {
            InitializeComponent();
            _loginFrame = loginFrame;
            _adminLoginDTO = adminLoginDTO;
            
            MemberPanel = new MemberPanel();
            MemberPanel.Dock = DockStyle.Fill;
            this.Controls.Add(MemberPanel);
            userNameLabel.Text = _adminLoginDTO.tenNhanVien;
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất","Đăng xuất",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _loginFrame.resetState();
                _loginFrame.Show();
                Close();
            }
        }
    }
}
