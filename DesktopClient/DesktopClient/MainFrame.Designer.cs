namespace DesktopClient
{
    partial class MainFrame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            button8 = new Button();
            vatdungBtnContainer = new FlowLayoutPanel();
            vatdungBtn = new Button();
            button1 = new Button();
            button2 = new Button();
            muonBtn = new Button();
            traBtn = new Button();
            button4 = new Button();
            button6 = new Button();
            button3 = new Button();
            button5 = new Button();
            vatdungBtnTimer = new System.Windows.Forms.Timer(components);
            panel2 = new Panel();
            panel3 = new Panel();
            button7 = new Button();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            vatdungBtnContainer.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(93, 87, 107);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(button8);
            flowLayoutPanel1.Controls.Add(vatdungBtnContainer);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Controls.Add(button6);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Controls.Add(button5);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(150, 681);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 150);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(155, 193, 188);
            label2.Location = new Point(35, 119);
            label2.Name = "label2";
            label2.Size = new Size(71, 17);
            label2.TabIndex = 2;
            label2.Text = "Nhân viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(7, 88);
            label1.Name = "label1";
            label1.Size = new Size(131, 21);
            label1.TabIndex = 1;
            label1.Text = "Tên người dùng";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user_circle2;
            pictureBox1.Location = new Point(35, 8);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 80);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // button8
            // 
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Location = new Point(0, 150);
            button8.Margin = new Padding(0);
            button8.Name = "button8";
            button8.Size = new Size(150, 44);
            button8.TabIndex = 7;
            button8.Text = "Trang chủ";
            button8.UseVisualStyleBackColor = true;
            // 
            // vatdungBtnContainer
            // 
            vatdungBtnContainer.Controls.Add(vatdungBtn);
            vatdungBtnContainer.Controls.Add(button1);
            vatdungBtnContainer.Controls.Add(button2);
            vatdungBtnContainer.Controls.Add(muonBtn);
            vatdungBtnContainer.Controls.Add(traBtn);
            vatdungBtnContainer.FlowDirection = FlowDirection.TopDown;
            vatdungBtnContainer.Location = new Point(0, 194);
            vatdungBtnContainer.Margin = new Padding(0);
            vatdungBtnContainer.Name = "vatdungBtnContainer";
            vatdungBtnContainer.Size = new Size(150, 44);
            vatdungBtnContainer.TabIndex = 1;
            vatdungBtnContainer.Paint += flowLayoutPanel2_Paint;
            // 
            // vatdungBtn
            // 
            vatdungBtn.FlatAppearance.BorderSize = 0;
            vatdungBtn.FlatStyle = FlatStyle.Flat;
            vatdungBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vatdungBtn.ForeColor = Color.White;
            vatdungBtn.Location = new Point(0, 0);
            vatdungBtn.Margin = new Padding(0);
            vatdungBtn.Name = "vatdungBtn";
            vatdungBtn.Size = new Size(150, 44);
            vatdungBtn.TabIndex = 0;
            vatdungBtn.Text = "Vật dụng";
            vatdungBtn.UseVisualStyleBackColor = false;
            vatdungBtn.Click += button1_Click_1;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(150, 0);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(150, 44);
            button1.TabIndex = 3;
            button1.Text = "Danh sách";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(300, 0);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(150, 44);
            button2.TabIndex = 4;
            button2.Text = "Đặt";
            button2.UseVisualStyleBackColor = true;
            // 
            // muonBtn
            // 
            muonBtn.FlatAppearance.BorderSize = 0;
            muonBtn.FlatStyle = FlatStyle.Flat;
            muonBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            muonBtn.ForeColor = Color.White;
            muonBtn.Location = new Point(450, 0);
            muonBtn.Margin = new Padding(0);
            muonBtn.Name = "muonBtn";
            muonBtn.Size = new Size(150, 44);
            muonBtn.TabIndex = 1;
            muonBtn.Text = "Mượn";
            muonBtn.UseVisualStyleBackColor = true;
            // 
            // traBtn
            // 
            traBtn.FlatAppearance.BorderSize = 0;
            traBtn.FlatStyle = FlatStyle.Flat;
            traBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            traBtn.ForeColor = Color.White;
            traBtn.Location = new Point(600, 0);
            traBtn.Margin = new Padding(0);
            traBtn.Name = "traBtn";
            traBtn.Size = new Size(150, 44);
            traBtn.TabIndex = 2;
            traBtn.Text = "Trả";
            traBtn.UseVisualStyleBackColor = true;
            traBtn.Click += traBtn_Click_1;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(0, 238);
            button4.Margin = new Padding(0);
            button4.Name = "button4";
            button4.Size = new Size(150, 44);
            button4.TabIndex = 4;
            button4.Text = "Thành viên";
            button4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(0, 282);
            button6.Margin = new Padding(0);
            button6.Name = "button6";
            button6.Size = new Size(150, 44);
            button6.TabIndex = 6;
            button6.Text = "Lịch sử";
            button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(0, 326);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new Size(150, 44);
            button3.TabIndex = 3;
            button3.Text = "Nhân viên";
            button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(0, 370);
            button5.Margin = new Padding(0);
            button5.Name = "button5";
            button5.Size = new Size(150, 44);
            button5.TabIndex = 5;
            button5.Text = "Tài khoản";
            button5.UseVisualStyleBackColor = true;
            // 
            // vatdungBtnTimer
            // 
            vatdungBtnTimer.Interval = 1;
            vatdungBtnTimer.Tick += vatdungBtnTimer_Tick;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(1114, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(150, 681);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(237, 106, 90);
            panel3.Controls.Add(button7);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 637);
            panel3.Name = "panel3";
            panel3.Size = new Size(150, 44);
            panel3.TabIndex = 0;
            panel3.Paint += panel3_Paint;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Bottom;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(0, 0);
            button7.Margin = new Padding(0);
            button7.Name = "button7";
            button7.Size = new Size(150, 44);
            button7.TabIndex = 8;
            button7.Text = "Đăng xuất";
            button7.UseVisualStyleBackColor = true;
            // 
            // MainFrame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel2);
            Name = "MainFrame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += MainFrame_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            vatdungBtnContainer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private FlowLayoutPanel vatdungBtnContainer;
        private Button vatdungBtn;
        private Button muonBtn;
        private Button traBtn;
        private System.Windows.Forms.Timer vatdungBtnTimer;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button4;
        private Button button6;
        private Button button3;
        private Button button5;
        private Panel panel2;
        private Panel panel3;
        private Button button7;
        private Button button8;
    }
}
