using System;
using System.Collections.ObjectModel;
using DesktopClient.APIs;
using DesktopClient.DTO;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Models;
using DesktopClient.UI;
using DesktopClient.UI.CustomControls;
using DesktopClient.UI.Panels;
using Microsoft.VisualBasic.ApplicationServices;
using Object = System.Object;

namespace DesktopClient
{
    public partial class MainFrame : Form
    {

        private LoginFrame _loginFrame;
        public static AdminLoginDTO? _adminLoginDTO;

        NavButton[] navButtons;
        List<(string, Image)> navButtonsData = new List<(string, Image)>
        {
            ("Trang chủ", Properties.Resources.home_svgrepo_com),
            ("Vật dụng", Properties.Resources.box_svgrepo_com),
            ("Mượn", Properties.Resources.clock_square_svgrepo_com),
            ("Đặt lịch", Properties.Resources.calendar_add_svgrepo_com),
            ("Trả", Properties.Resources.rewind_back_svgrepo_com),
            ("Lịch sử", Properties.Resources.history_svgrepo_com),
            ("Phạt", Properties.Resources.home_svgrepo_com),
            ("Thành viên", Properties.Resources.cardholder_svgrepo_com),
            ("Nhân viên", Properties.Resources.user_svgrepo_com),
            //("Tài khoản", Properties.Resources.lock_password_svgrepo_com)
        };

        List<UserControl> panels = new List<UserControl> 
        {
            new HomePanel(),
            new ItemPanel(),
            new BorrowPanel(),
            new BookingPanel(),
            new ReturnPanel(),
            new HistoryPanel(),
            new PenaltyPanel(),
            new MemberPanel(),
            new StaffPanel(),
            //new AccountPanel()
        };

        public MainFrame(AdminLoginDTO adminLoginDTO, LoginFrame loginFrame)
        {
            InitializeComponent();
            _loginFrame = loginFrame;
            _adminLoginDTO = adminLoginDTO;
            userNameLabel.Text = adminLoginDTO.tenNhanVien;

            navButtons = new NavButton[navButtonsData.Count];
            for (int i = 0; i < navButtonsData.Count; i++)
            {
                navButtons[i] = new NavButton(navButtonsData[i].Item1, navButtonsData[i].Item2);
                navButtons[i].Margin = new Padding(0);
                navButtons[i].Padding = new Padding(0, 8, 0, 0);

                navButtons[i].Tag = i;
                navButtons[i].panel1.Click += navBtn_Click;
                navButtons[i].icon.Click += navBtn_Click;
                navButtons[i].text.Click += navBtn_Click;

                flowLayoutPanel1.Controls.Add(navButtons[i]);
            }

            switchFrame(0);
            navButtons[0].BackColor = Color.FromArgb(181, 203, 183);
            navButtons[0].isSelected = true;
        }

        private void navBtn_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;
            Control parent = clickedControl.Parent;
            int index = (int)parent.Tag;
            switchFrame(index);

            for (int i = 0; i < navButtons.Length; i++)
            {
                navButtons[i].isSelected = false;
                navButtons[i].BackColor = SystemColors.ControlLight;
            }
            navButtons[index].BackColor = Color.FromArgb(181, 203, 183);
            navButtons[index].isSelected = true;
        }

        private void switchFrame(int index)
        {
            centerPanel.Controls.Clear();
            centerPanel.Controls.Add(panels[index]);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _loginFrame.resetState();
                _loginFrame.Show();
                Dispose();
            }
        }

        private void MainFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginFrame.Dispose();
        }

    }
}
