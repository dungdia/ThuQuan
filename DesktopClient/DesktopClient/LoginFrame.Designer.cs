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
            emailInput = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            passwordInput = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // emailInput
            // 
            emailInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            emailInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            emailInput.Location = new System.Drawing.Point(115, 179);
            emailInput.Name = "emailInput";
            emailInput.Size = new System.Drawing.Size(220, 27);
            emailInput.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)244)), ((int)((byte)241)), ((int)((byte)187)));
            button1.Cursor = System.Windows.Forms.Cursors.Hand;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            button1.Location = new System.Drawing.Point(165, 325);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(120, 42);
            button1.TabIndex = 2;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = false;
            button1.Click += loginBtn_Click;
            // 
            // passwordInput
            // 
            passwordInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            passwordInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            passwordInput.Location = new System.Drawing.Point(115, 249);
            passwordInput.Name = "passwordInput";
            passwordInput.PasswordChar = '*';
            passwordInput.Size = new System.Drawing.Size(220, 27);
            passwordInput.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(115, 156);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 25);
            label1.TabIndex = 4;
            label1.Text = "Email";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(115, 226);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(94, 25);
            label2.TabIndex = 5;
            label2.Text = "Mật khẩu";
            label2.Click += label2_Click;
            // 
            // LoginFrame
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)((byte)155)), ((int)((byte)193)), ((int)((byte)188)));
            ClientSize = new System.Drawing.Size(434, 411);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordInput);
            Controls.Add(button1);
            Controls.Add(emailInput);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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