namespace DesktopClient.UI.Dialog
{
    partial class RegisterMemberDialog
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
            confirmBtn = new Button();
            username_Input = new TextBox();
            email_Input = new TextBox();
            password_Input = new TextBox();
            confirmPassword_Input = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            fullName_Input = new TextBox();
            label5 = new Label();
            label6 = new Label();
            phone_Input = new TextBox();
            SuspendLayout();
            // 
            // confirmBtn
            // 
            confirmBtn.BackColor = SystemColors.MenuHighlight;
            confirmBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmBtn.Location = new Point(234, 348);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(158, 40);
            confirmBtn.TabIndex = 0;
            confirmBtn.Text = "Thêm thành viên";
            confirmBtn.UseVisualStyleBackColor = false;
            confirmBtn.Click += ConfirmEvent;
            // 
            // username_Input
            // 
            username_Input.Font = new Font("Segoe UI", 10.8F);
            username_Input.Location = new Point(81, 46);
            username_Input.Name = "username_Input";
            username_Input.Size = new Size(245, 27);
            username_Input.TabIndex = 1;
            // 
            // email_Input
            // 
            email_Input.Font = new Font("Segoe UI", 10.8F);
            email_Input.Location = new Point(81, 103);
            email_Input.Name = "email_Input";
            email_Input.Size = new Size(245, 27);
            email_Input.TabIndex = 2;
            // 
            // password_Input
            // 
            password_Input.Font = new Font("Segoe UI", 10.8F);
            password_Input.Location = new Point(81, 262);
            password_Input.Name = "password_Input";
            password_Input.PasswordChar = '*';
            password_Input.Size = new Size(245, 27);
            password_Input.TabIndex = 3;
            // 
            // confirmPassword_Input
            // 
            confirmPassword_Input.Font = new Font("Segoe UI", 10.8F);
            confirmPassword_Input.Location = new Point(81, 315);
            confirmPassword_Input.Name = "confirmPassword_Input";
            confirmPassword_Input.PasswordChar = '*';
            confirmPassword_Input.Size = new Size(245, 27);
            confirmPassword_Input.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label1.Location = new Point(81, 22);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 5;
            label1.Text = "Tên tài khoản";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.Location = new Point(81, 80);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 6;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.Location = new Point(81, 239);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 7;
            label3.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label4.Location = new Point(81, 292);
            label4.Name = "label4";
            label4.Size = new Size(143, 20);
            label4.TabIndex = 8;
            label4.Text = "Xác nhận mật khẩu";
            // 
            // fullName_Input
            // 
            fullName_Input.Font = new Font("Segoe UI", 10.8F);
            fullName_Input.Location = new Point(81, 156);
            fullName_Input.Name = "fullName_Input";
            fullName_Input.Size = new Size(245, 27);
            fullName_Input.TabIndex = 9;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label5.Location = new Point(81, 133);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 10;
            label5.Text = "Họ tên";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label6.Location = new Point(81, 186);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 11;
            label6.Text = "Số điện thoại";
            // 
            // phone_Input
            // 
            phone_Input.Font = new Font("Segoe UI", 10.8F);
            phone_Input.Location = new Point(81, 209);
            phone_Input.Name = "phone_Input";
            phone_Input.Size = new Size(245, 27);
            phone_Input.TabIndex = 12;
            // 
            // RegisterMemberDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 440);
            Controls.Add(phone_Input);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(fullName_Input);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(confirmPassword_Input);
            Controls.Add(password_Input);
            Controls.Add(email_Input);
            Controls.Add(username_Input);
            Controls.Add(confirmBtn);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterMemberDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đăng ký";
            FormClosed += RegisterAccountDialog_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button confirmBtn;
        private TextBox username_Input;
        private TextBox email_Input;
        private TextBox password_Input;
        private TextBox confirmPassword_Input;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox fullName_Input;
        private Label label5;
        private Label label6;
        private TextBox phone_Input;
    }
}