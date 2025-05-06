namespace DesktopClient.UI.Dialog
{
    partial class MemberDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            idThanhVien_Input = new TextBox();
            username_Input = new TextBox();
            email_Input = new TextBox();
            username = new Label();
            confirmBtn = new Button();
            matkhau_Input = new TextBox();
            xn_matkhau_Input = new TextBox();
            mk_lb = new Label();
            xn_mk_lb = new Label();
            sodienthoai_Input = new TextBox();
            label5 = new Label();
            label7 = new Label();
            panel = new Panel();
            tinhTrang_Txt = new Label();
            label8 = new Label();
            idTaiKhoan_Input = new TextBox();
            label3 = new Label();
            hoten_Input = new TextBox();
            label6 = new Label();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label1.Location = new Point(574, 16);
            label1.Name = "label1";
            label1.Size = new Size(127, 25);
            label1.TabIndex = 2;
            label1.Text = "ID thành viên";
            // 
            // idThanhVien_Input
            // 
            idThanhVien_Input.Enabled = false;
            idThanhVien_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idThanhVien_Input.Location = new Point(574, 47);
            idThanhVien_Input.Name = "idThanhVien_Input";
            idThanhVien_Input.ReadOnly = true;
            idThanhVien_Input.ShortcutsEnabled = false;
            idThanhVien_Input.Size = new Size(165, 34);
            idThanhVien_Input.TabIndex = 3;
            idThanhVien_Input.TabStop = false;
            // 
            // username_Input
            // 
            username_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            username_Input.Location = new Point(71, 119);
            username_Input.Name = "username_Input";
            username_Input.ShortcutsEnabled = false;
            username_Input.Size = new Size(165, 34);
            username_Input.TabIndex = 4;
            username_Input.TabStop = false;
            // 
            // email_Input
            // 
            email_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            email_Input.Location = new Point(71, 191);
            email_Input.Name = "email_Input";
            email_Input.ShortcutsEnabled = false;
            email_Input.Size = new Size(165, 34);
            email_Input.TabIndex = 5;
            email_Input.TabStop = false;
            // 
            // username
            // 
            username.AutoSize = true;
            username.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            username.Location = new Point(71, 88);
            username.Name = "username";
            username.Size = new Size(127, 25);
            username.TabIndex = 6;
            username.Text = "Tên tài khoản";
            // 
            // confirmBtn
            // 
            confirmBtn.BackColor = SystemColors.MenuHighlight;
            confirmBtn.ForeColor = Color.Black;
            confirmBtn.Location = new Point(640, 312);
            confirmBtn.Margin = new Padding(3, 4, 3, 4);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(161, 53);
            confirmBtn.TabIndex = 8;
            confirmBtn.Text = "Xác nhận";
            confirmBtn.UseVisualStyleBackColor = false;
            confirmBtn.Click += ConfirmEvent;
            // 
            // matkhau_Input
            // 
            matkhau_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            matkhau_Input.Location = new Point(301, 47);
            matkhau_Input.Name = "matkhau_Input";
            matkhau_Input.ShortcutsEnabled = false;
            matkhau_Input.Size = new Size(191, 34);
            matkhau_Input.TabIndex = 9;
            matkhau_Input.TabStop = false;
            // 
            // xn_matkhau_Input
            // 
            xn_matkhau_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xn_matkhau_Input.Location = new Point(301, 119);
            xn_matkhau_Input.Name = "xn_matkhau_Input";
            xn_matkhau_Input.ShortcutsEnabled = false;
            xn_matkhau_Input.Size = new Size(191, 34);
            xn_matkhau_Input.TabIndex = 10;
            xn_matkhau_Input.TabStop = false;
            // 
            // mk_lb
            // 
            mk_lb.AutoSize = true;
            mk_lb.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            mk_lb.Location = new Point(301, 16);
            mk_lb.Name = "mk_lb";
            mk_lb.Size = new Size(98, 25);
            mk_lb.TabIndex = 11;
            mk_lb.Text = "Mật khẩu ";
            // 
            // xn_mk_lb
            // 
            xn_mk_lb.AutoSize = true;
            xn_mk_lb.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            xn_mk_lb.Location = new Point(301, 88);
            xn_mk_lb.Name = "xn_mk_lb";
            xn_mk_lb.Size = new Size(176, 25);
            xn_mk_lb.TabIndex = 12;
            xn_mk_lb.Text = "Xác nhận mật khẩu";
            // 
            // sodienthoai_Input
            // 
            sodienthoai_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sodienthoai_Input.Location = new Point(574, 191);
            sodienthoai_Input.Name = "sodienthoai_Input";
            sodienthoai_Input.ShortcutsEnabled = false;
            sodienthoai_Input.Size = new Size(165, 34);
            sodienthoai_Input.TabIndex = 14;
            sodienthoai_Input.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label5.Location = new Point(574, 88);
            label5.Name = "label5";
            label5.Size = new Size(70, 25);
            label5.TabIndex = 15;
            label5.Text = "Họ tên";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label7.Location = new Point(574, 160);
            label7.Name = "label7";
            label7.Size = new Size(124, 25);
            label7.TabIndex = 18;
            label7.Text = "Số điện thoại";
            // 
            // panel
            // 
            panel.Controls.Add(tinhTrang_Txt);
            panel.Controls.Add(confirmBtn);
            panel.Controls.Add(label8);
            panel.Controls.Add(idTaiKhoan_Input);
            panel.Controls.Add(xn_matkhau_Input);
            panel.Controls.Add(label5);
            panel.Controls.Add(username_Input);
            panel.Controls.Add(label7);
            panel.Controls.Add(idThanhVien_Input);
            panel.Controls.Add(label3);
            panel.Controls.Add(matkhau_Input);
            panel.Controls.Add(hoten_Input);
            panel.Controls.Add(sodienthoai_Input);
            panel.Controls.Add(xn_mk_lb);
            panel.Controls.Add(mk_lb);
            panel.Controls.Add(email_Input);
            panel.Controls.Add(label6);
            panel.Controls.Add(username);
            panel.Controls.Add(label1);
            panel.Location = new Point(14, 16);
            panel.Margin = new Padding(3, 4, 3, 4);
            panel.Name = "panel";
            panel.Size = new Size(816, 384);
            panel.TabIndex = 21;
            // 
            // tinhTrang_Txt
            // 
            tinhTrang_Txt.AutoSize = true;
            tinhTrang_Txt.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            tinhTrang_Txt.Location = new Point(674, 245);
            tinhTrang_Txt.Name = "tinhTrang_Txt";
            tinhTrang_Txt.Size = new Size(97, 25);
            tinhTrang_Txt.TabIndex = 23;
            tinhTrang_Txt.Text = "tình trạng";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label8.Location = new Point(71, 16);
            label8.Name = "label8";
            label8.Size = new Size(116, 25);
            label8.TabIndex = 22;
            label8.Text = "ID tài khoản";
            // 
            // idTaiKhoan_Input
            // 
            idTaiKhoan_Input.Enabled = false;
            idTaiKhoan_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTaiKhoan_Input.Location = new Point(71, 47);
            idTaiKhoan_Input.Name = "idTaiKhoan_Input";
            idTaiKhoan_Input.ReadOnly = true;
            idTaiKhoan_Input.ShortcutsEnabled = false;
            idTaiKhoan_Input.Size = new Size(165, 34);
            idTaiKhoan_Input.TabIndex = 21;
            idTaiKhoan_Input.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.Location = new Point(574, 245);
            label3.Name = "label3";
            label3.Size = new Size(106, 25);
            label3.TabIndex = 20;
            label3.Text = "Tình trạng:";
            // 
            // hoten_Input
            // 
            hoten_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hoten_Input.Location = new Point(574, 119);
            hoten_Input.Name = "hoten_Input";
            hoten_Input.ShortcutsEnabled = false;
            hoten_Input.Size = new Size(165, 34);
            hoten_Input.TabIndex = 13;
            hoten_Input.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label6.Location = new Point(71, 160);
            label6.Name = "label6";
            label6.Size = new Size(58, 25);
            label6.TabIndex = 7;
            label6.Text = "Email";
            // 
            // MemberDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 415);
            Controls.Add(panel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MemberDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UpdateAccountDialog";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox idThanhVien_Input;
        private TextBox username_Input;
        private TextBox email_Input;
        private Label username;
        private Button confirmBtn;
        private TextBox matkhau_Input;
        private TextBox xn_matkhau_Input;
        private Label mk_lb;
        private Label xn_mk_lb;
        private TextBox name_Input;
        private TextBox sodienthoai_Input;
        private Label label5;
        private Label label7;
        private Panel panel;
        private Label label6;
        private Label label3;
        private TextBox hoten_Input;
        private Label label8;
        private TextBox idTaiKhoan_Input;
        private Label tinhTrang_Txt;
    }
}