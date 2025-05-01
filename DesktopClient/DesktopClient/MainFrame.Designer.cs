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
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            button7 = new Button();
            centerPanel = new Panel();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.BackColor = SystemColors.ControlLight;
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(150, 681);
            flowLayoutPanel1.TabIndex = 0;
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
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Green;
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
            label1.ForeColor = Color.Black;
            label1.Location = new Point(7, 88);
            label1.Name = "label1";
            label1.Size = new Size(131, 21);
            label1.TabIndex = 1;
            label1.Text = "Tên người dùng";
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
            // centerPanel
            // 
            centerPanel.Dock = DockStyle.Fill;
            centerPanel.Location = new Point(0, 0);
            centerPanel.Margin = new Padding(0);
            centerPanel.Name = "centerPanel";
            centerPanel.Size = new Size(1114, 681);
            centerPanel.TabIndex = 2;
            // 
            // MainFrame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(centerPanel);
            Controls.Add(panel2);
            Name = "MainFrame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosed += MainFrame_FormClosed;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Panel panel3;
        private Button button7;
        private Panel centerPanel;
    }
}