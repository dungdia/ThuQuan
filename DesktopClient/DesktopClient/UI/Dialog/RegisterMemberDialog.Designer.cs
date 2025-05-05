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
            SuspendLayout();
            // 
            // confirmBtn
            // 
            confirmBtn.BackColor = SystemColors.MenuHighlight;
            confirmBtn.Location = new Point(471, 389);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(141, 40);
            confirmBtn.TabIndex = 0;
            confirmBtn.Text = "Xác nhận";
            confirmBtn.UseVisualStyleBackColor = false;
            confirmBtn.Click += ConfirmEvent;
            // 
            // username_Input
            // 
            username_Input.Location = new Point(227, 133);
            username_Input.Name = "username_Input";
            username_Input.Size = new Size(200, 23);
            username_Input.TabIndex = 1;
            // 
            // email_Input
            // 
            email_Input.Location = new Point(227, 182);
            email_Input.Name = "email_Input";
            email_Input.Size = new Size(200, 23);
            email_Input.TabIndex = 2;
            // 
            // password_Input
            // 
            password_Input.Location = new Point(227, 231);
            password_Input.Name = "password_Input";
            password_Input.PasswordChar = '*';
            password_Input.Size = new Size(200, 23);
            password_Input.TabIndex = 3;
            // 
            // confirmPassword_Input
            // 
            confirmPassword_Input.Location = new Point(227, 280);
            confirmPassword_Input.Name = "confirmPassword_Input";
            confirmPassword_Input.PasswordChar = '*';
            confirmPassword_Input.Size = new Size(200, 23);
            confirmPassword_Input.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label1.Location = new Point(227, 110);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 5;
            label1.Text = "tên tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.Location = new Point(227, 159);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 6;
            label2.Text = "email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.Location = new Point(227, 208);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 7;
            label3.Text = "mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label4.Location = new Point(227, 257);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 8;
            label4.Text = "xác nhận mật khẩu";
            // 
            // RegisterMemberDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 441);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(confirmPassword_Input);
            Controls.Add(password_Input);
            Controls.Add(email_Input);
            Controls.Add(username_Input);
            Controls.Add(confirmBtn);
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
    }
}