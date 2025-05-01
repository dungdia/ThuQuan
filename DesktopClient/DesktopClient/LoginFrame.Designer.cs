namespace DesktopClient
{
    partial class LoginFrame
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
            emailInput = new TextBox();
            button1 = new Button();
            passwordInput = new MaskedTextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // emailInput
            // 
            emailInput.BorderStyle = BorderStyle.None;
            emailInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailInput.Location = new Point(101, 134);
            emailInput.Margin = new Padding(3, 2, 3, 2);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(192, 22);
            emailInput.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(244, 241, 187);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(129, 232);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(126, 32);
            button1.TabIndex = 2;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = false;
            button1.Click += loginBtn_Click;
            // 
            // passwordInput
            // 
            passwordInput.BorderStyle = BorderStyle.None;
            passwordInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordInput.Location = new Point(101, 187);
            passwordInput.Margin = new Padding(3, 2, 3, 2);
            passwordInput.Name = "passwordInput";
            passwordInput.PasswordChar = '*';
            passwordInput.Size = new Size(192, 22);
            passwordInput.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(101, 112);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 4;
            label1.Text = "Email";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(101, 165);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 5;
            label2.Text = "Mật khẩu";
            label2.Click += label2_Click;
            // 
            // LoginFrame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(155, 193, 188);
            ClientSize = new Size(380, 308);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordInput);
            Controls.Add(button1);
            Controls.Add(emailInput);
            Name = "LoginFrame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginFrame";
            Load += LoginFrame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailInput;
        private System.Windows.Forms.Button button1;
        private MaskedTextBox passwordInput;
        private System.Windows.Forms.Label label1;
        private Label label2;
    }
}