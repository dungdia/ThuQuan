using DesktopClient.APIs;
using DesktopClient.DTO;
using DesktopClient.Models;
using DesktopClient.UI;
using Object = System.Object;

namespace DesktopClient
{
    public partial class MainFrame : Form
    {
        ItemPanel ItemPanel { get; set; }
        MemberPanel MemberPanel { get; set; }

        public MainFrame()
        {
            InitializeComponent();
            MemberPanel = new MemberPanel();
            MemberPanel.Dock = DockStyle.Fill;
            this.Controls.Add(MemberPanel);
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

    }
}
