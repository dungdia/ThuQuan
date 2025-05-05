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
            confirmBtn.Location = new Point(785, 539);
            confirmBtn.Margin = new Padding(3, 4, 3, 4);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(86, 31);
            confirmBtn.TabIndex = 0;
            confirmBtn.Text = "Xác nhận";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += ConfirmEvent;
            // 
            // username_Input
            // 
            username_Input.Location = new Point(159, 40);
            username_Input.Margin = new Padding(3, 4, 3, 4);
            username_Input.Name = "username_Input";
            username_Input.Size = new Size(114, 27);
            username_Input.TabIndex = 1;
            // 
            // email_Input
            // 
            email_Input.Location = new Point(159, 79);
            email_Input.Margin = new Padding(3, 4, 3, 4);
            email_Input.Name = "email_Input";
            email_Input.Size = new Size(114, 27);
            email_Input.TabIndex = 2;
            // 
            // password_Input
            // 
            password_Input.Location = new Point(159, 117);
            password_Input.Margin = new Padding(3, 4, 3, 4);
            password_Input.Name = "password_Input";
            password_Input.PasswordChar = '*';
            password_Input.Size = new Size(114, 27);
            password_Input.TabIndex = 3;
            // 
            // confirmPassword_Input
            // 
            confirmPassword_Input.Location = new Point(159, 156);
            confirmPassword_Input.Margin = new Padding(3, 4, 3, 4);
            confirmPassword_Input.Name = "confirmPassword_Input";
            confirmPassword_Input.PasswordChar = '*';
            confirmPassword_Input.Size = new Size(114, 27);
            confirmPassword_Input.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 40);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 5;
            label1.Text = "tên tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 79);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 6;
            label2.Text = "email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 117);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 7;
            label3.Text = "mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 156);
            label4.Name = "label4";
            label4.Size = new Size(132, 20);
            label4.TabIndex = 8;
            label4.Text = "xác nhận mật khẩu";
            // 
            // RegisterMemberDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(confirmPassword_Input);
            Controls.Add(password_Input);
            Controls.Add(email_Input);
            Controls.Add(username_Input);
            Controls.Add(confirmBtn);
            Margin = new Padding(3, 4, 3, 4);
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