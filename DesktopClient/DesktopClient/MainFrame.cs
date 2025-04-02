namespace DesktopClient
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            vatdungBtnTimer.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        bool vatdungBtnExpand = false;
        private void vatdungBtnTimer_Tick(object sender, EventArgs e)
        {
            if (!vatdungBtnExpand)
            {
                vatdungBtnContainer.Height += 16;
                if (vatdungBtnContainer.Height >= 220)
                {
                    vatdungBtnTimer.Stop();
                    vatdungBtnExpand = true;
                }
            }
            else
            {
                vatdungBtnContainer.Height -= 16;
                if (vatdungBtnContainer.Height <= 44)
                {
                    vatdungBtnTimer.Stop();
                    vatdungBtnExpand = false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void traBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void traBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
