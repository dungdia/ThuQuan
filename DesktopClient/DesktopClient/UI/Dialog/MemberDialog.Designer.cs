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
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(516, 12);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 2;
            label1.Text = "Id nhân viên";
            // 
            // idThanhVien_Input
            // 
            idThanhVien_Input.Enabled = false;
            idThanhVien_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idThanhVien_Input.Location = new Point(621, 12);
            idThanhVien_Input.Margin = new Padding(3, 2, 3, 2);
            idThanhVien_Input.Name = "idThanhVien_Input";
            idThanhVien_Input.ReadOnly = true;
            idThanhVien_Input.ShortcutsEnabled = false;
            idThanhVien_Input.Size = new Size(130, 29);
            idThanhVien_Input.TabIndex = 3;
            idThanhVien_Input.TabStop = false;
            // 
            // username_Input
            // 
            username_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            username_Input.Location = new Point(286, 50);
            username_Input.Margin = new Padding(3, 2, 3, 2);
            username_Input.Name = "username_Input";
            username_Input.ShortcutsEnabled = false;
            username_Input.Size = new Size(130, 29);
            username_Input.TabIndex = 4;
            username_Input.TabStop = false;
            // 
            // email_Input
            // 
            email_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            email_Input.Location = new Point(286, 86);
            email_Input.Margin = new Padding(3, 2, 3, 2);
            email_Input.Name = "email_Input";
            email_Input.ShortcutsEnabled = false;
            email_Input.Size = new Size(130, 29);
            email_Input.TabIndex = 5;
            email_Input.TabStop = false;
            // 
            // username
            // 
            username.AutoSize = true;
            username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            username.Location = new Point(179, 53);
            username.Name = "username";
            username.Size = new Size(101, 21);
            username.TabIndex = 6;
            username.Text = "Tên tài khoản";
            // 
            // confirmBtn
            // 
            confirmBtn.Location = new Point(713, 415);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(75, 23);
            confirmBtn.TabIndex = 8;
            confirmBtn.Text = "Xác nhận";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += ConfirmEvent;
            // 
            // matkhau_Input
            // 
            matkhau_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            matkhau_Input.Location = new Point(286, 155);
            matkhau_Input.Margin = new Padding(3, 2, 3, 2);
            matkhau_Input.Name = "matkhau_Input";
            matkhau_Input.ShortcutsEnabled = false;
            matkhau_Input.Size = new Size(130, 29);
            matkhau_Input.TabIndex = 9;
            matkhau_Input.TabStop = false;
            // 
            // xn_matkhau_Input
            // 
            xn_matkhau_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xn_matkhau_Input.Location = new Point(286, 188);
            xn_matkhau_Input.Margin = new Padding(3, 2, 3, 2);
            xn_matkhau_Input.Name = "xn_matkhau_Input";
            xn_matkhau_Input.ShortcutsEnabled = false;
            xn_matkhau_Input.Size = new Size(130, 29);
            xn_matkhau_Input.TabIndex = 10;
            xn_matkhau_Input.TabStop = false;
            // 
            // mk_lb
            // 
            mk_lb.AutoSize = true;
            mk_lb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mk_lb.Location = new Point(201, 155);
            mk_lb.Name = "mk_lb";
            mk_lb.Size = new Size(79, 21);
            mk_lb.TabIndex = 11;
            mk_lb.Text = "mật khẩu ";
            // 
            // xn_mk_lb
            // 
            xn_mk_lb.AutoSize = true;
            xn_mk_lb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xn_mk_lb.Location = new Point(140, 188);
            xn_mk_lb.Name = "xn_mk_lb";
            xn_mk_lb.Size = new Size(140, 21);
            xn_mk_lb.TabIndex = 12;
            xn_mk_lb.Text = "xác nhận mật khẩu";
            // 
            // sodienthoai_Input
            // 
            sodienthoai_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sodienthoai_Input.Location = new Point(621, 90);
            sodienthoai_Input.Margin = new Padding(3, 2, 3, 2);
            sodienthoai_Input.Name = "sodienthoai_Input";
            sodienthoai_Input.ShortcutsEnabled = false;
            sodienthoai_Input.Size = new Size(130, 29);
            sodienthoai_Input.TabIndex = 14;
            sodienthoai_Input.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(561, 50);
            label5.Name = "label5";
            label5.Size = new Size(54, 21);
            label5.TabIndex = 15;
            label5.Text = "họ tên";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(516, 93);
            label7.Name = "label7";
            label7.Size = new Size(99, 21);
            label7.TabIndex = 18;
            label7.Text = "số điện thoại";
            // 
            // panel
            // 
            panel.Controls.Add(tinhTrang_Txt);
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
            panel.Location = new Point(12, 12);
            panel.Name = "panel";
            panel.Size = new Size(776, 288);
            panel.TabIndex = 21;
            // 
            // tinhTrang_Txt
            // 
            tinhTrang_Txt.AutoSize = true;
            tinhTrang_Txt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tinhTrang_Txt.Location = new Point(621, 151);
            tinhTrang_Txt.Name = "tinhTrang_Txt";
            tinhTrang_Txt.Size = new Size(78, 21);
            tinhTrang_Txt.TabIndex = 23;
            tinhTrang_Txt.Text = "tình trạng";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(183, 12);
            label8.Name = "label8";
            label8.Size = new Size(91, 21);
            label8.TabIndex = 22;
            label8.Text = "Id tài khoản";
            // 
            // idTaiKhoan_Input
            // 
            idTaiKhoan_Input.Enabled = false;
            idTaiKhoan_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTaiKhoan_Input.Location = new Point(286, 12);
            idTaiKhoan_Input.Margin = new Padding(3, 2, 3, 2);
            idTaiKhoan_Input.Name = "idTaiKhoan_Input";
            idTaiKhoan_Input.ReadOnly = true;
            idTaiKhoan_Input.ShortcutsEnabled = false;
            idTaiKhoan_Input.Size = new Size(130, 29);
            idTaiKhoan_Input.TabIndex = 21;
            idTaiKhoan_Input.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(537, 151);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 20;
            label3.Text = "tình trạng";
            // 
            // hoten_Input
            // 
            hoten_Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hoten_Input.Location = new Point(621, 50);
            hoten_Input.Margin = new Padding(3, 2, 3, 2);
            hoten_Input.Name = "hoten_Input";
            hoten_Input.ShortcutsEnabled = false;
            hoten_Input.Size = new Size(130, 29);
            hoten_Input.TabIndex = 13;
            hoten_Input.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(226, 86);
            label6.Name = "label6";
            label6.Size = new Size(48, 21);
            label6.TabIndex = 7;
            label6.Text = "email";
            // 
            // MemberDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel);
            Controls.Add(confirmBtn);
            Name = "MemberDialog";
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