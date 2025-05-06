namespace DesktopClient.UI.Dialog
{
    partial class StaffDialog
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            idTextbox = new TextBox();
            fullNameTextbox = new TextBox();
            phoneNumberTextbox = new TextBox();
            addressTextbox = new TextBox();
            statusCombobox = new ComboBox();
            saveBtn = new Button();
            label7 = new Label();
            usernameTextbox = new TextBox();
            closeBtn = new Button();
            emailTextbox = new TextBox();
            label9 = new Label();
            joinedDateTextbox = new TextBox();
            label10 = new Label();
            accountIdTextbox = new TextBox();
            label8 = new Label();
            addBtn = new Button();
            genderCombobox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(31, 25);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.Location = new Point(329, 10);
            label2.Name = "label2";
            label2.Size = new Size(70, 25);
            label2.TabIndex = 1;
            label2.Text = "Họ tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.Location = new Point(329, 87);
            label3.Name = "label3";
            label3.Size = new Size(124, 25);
            label3.TabIndex = 2;
            label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label4.Location = new Point(12, 87);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 3;
            label4.Text = "Giới tính";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label5.Location = new Point(645, 6);
            label5.Name = "label5";
            label5.Size = new Size(70, 25);
            label5.TabIndex = 4;
            label5.Text = "Địa chỉ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label6.Location = new Point(645, 85);
            label6.Name = "label6";
            label6.Size = new Size(101, 25);
            label6.TabIndex = 5;
            label6.Text = "Tình trạng";
            // 
            // idTextbox
            // 
            idTextbox.Font = new Font("Segoe UI", 10.8F);
            idTextbox.ForeColor = SystemColors.InfoText;
            idTextbox.Location = new Point(12, 41);
            idTextbox.Name = "idTextbox";
            idTextbox.Size = new Size(288, 31);
            idTextbox.TabIndex = 6;
            // 
            // fullNameTextbox
            // 
            fullNameTextbox.Font = new Font("Segoe UI", 10.8F);
            fullNameTextbox.ForeColor = SystemColors.InfoText;
            fullNameTextbox.Location = new Point(329, 41);
            fullNameTextbox.Name = "fullNameTextbox";
            fullNameTextbox.Size = new Size(288, 31);
            fullNameTextbox.TabIndex = 7;
            // 
            // phoneNumberTextbox
            // 
            phoneNumberTextbox.Font = new Font("Segoe UI", 10.8F);
            phoneNumberTextbox.ForeColor = SystemColors.InfoText;
            phoneNumberTextbox.Location = new Point(329, 118);
            phoneNumberTextbox.Name = "phoneNumberTextbox";
            phoneNumberTextbox.Size = new Size(288, 31);
            phoneNumberTextbox.TabIndex = 8;
            // 
            // addressTextbox
            // 
            addressTextbox.Font = new Font("Segoe UI", 10.8F);
            addressTextbox.ForeColor = SystemColors.InfoText;
            addressTextbox.Location = new Point(645, 41);
            addressTextbox.Name = "addressTextbox";
            addressTextbox.Size = new Size(288, 31);
            addressTextbox.TabIndex = 10;
            // 
            // statusCombobox
            // 
            statusCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCombobox.Font = new Font("Segoe UI", 10.8F);
            statusCombobox.ForeColor = SystemColors.InfoText;
            statusCombobox.FormattingEnabled = true;
            statusCombobox.Items.AddRange(new object[] { "Đang làm việc", "Đã nghỉ" });
            statusCombobox.Location = new Point(645, 116);
            statusCombobox.Name = "statusCombobox";
            statusCombobox.Size = new Size(288, 33);
            statusCombobox.TabIndex = 11;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.FromArgb(16, 185, 129);
            saveBtn.Cursor = Cursors.Hand;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            saveBtn.Location = new Point(777, 332);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(156, 50);
            saveBtn.TabIndex = 13;
            saveBtn.Text = "Lưu thông tin";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label7.Location = new Point(12, 169);
            label7.Name = "label7";
            label7.Size = new Size(127, 25);
            label7.TabIndex = 14;
            label7.Text = "Tên tài khoản";
            // 
            // usernameTextbox
            // 
            usernameTextbox.Font = new Font("Segoe UI", 10.8F);
            usernameTextbox.ForeColor = SystemColors.InfoText;
            usernameTextbox.Location = new Point(12, 197);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.Size = new Size(288, 31);
            usernameTextbox.TabIndex = 16;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.FromArgb(239, 68, 68);
            closeBtn.Cursor = Cursors.Hand;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            closeBtn.Location = new Point(405, 332);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(156, 50);
            closeBtn.TabIndex = 18;
            closeBtn.Text = "Đóng";
            closeBtn.UseVisualStyleBackColor = false;
            closeBtn.Click += closeBtn_Click;
            // 
            // emailTextbox
            // 
            emailTextbox.Font = new Font("Segoe UI", 10.8F);
            emailTextbox.ForeColor = SystemColors.InfoText;
            emailTextbox.Location = new Point(645, 197);
            emailTextbox.Name = "emailTextbox";
            emailTextbox.Size = new Size(288, 31);
            emailTextbox.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label9.Location = new Point(645, 169);
            label9.Name = "label9";
            label9.Size = new Size(58, 25);
            label9.TabIndex = 19;
            label9.Text = "Email";
            // 
            // joinedDateTextbox
            // 
            joinedDateTextbox.Font = new Font("Segoe UI", 10.8F);
            joinedDateTextbox.ForeColor = SystemColors.InfoText;
            joinedDateTextbox.Location = new Point(12, 272);
            joinedDateTextbox.Name = "joinedDateTextbox";
            joinedDateTextbox.Size = new Size(288, 31);
            joinedDateTextbox.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label10.Location = new Point(12, 244);
            label10.Name = "label10";
            label10.Size = new Size(137, 25);
            label10.TabIndex = 21;
            label10.Text = "Ngày tham gia";
            // 
            // accountIdTextbox
            // 
            accountIdTextbox.Font = new Font("Segoe UI", 10.8F);
            accountIdTextbox.ForeColor = SystemColors.InfoText;
            accountIdTextbox.Location = new Point(328, 196);
            accountIdTextbox.Name = "accountIdTextbox";
            accountIdTextbox.Size = new Size(288, 31);
            accountIdTextbox.TabIndex = 24;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label8.Location = new Point(328, 168);
            label8.Name = "label8";
            label8.Size = new Size(118, 25);
            label8.TabIndex = 23;
            label8.Text = "ID Tài khoản";
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(16, 185, 129);
            addBtn.Cursor = Cursors.Hand;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            addBtn.Location = new Point(768, 332);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(165, 50);
            addBtn.TabIndex = 25;
            addBtn.Text = "Thêm nhân viên";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // genderCombobox
            // 
            genderCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            genderCombobox.Font = new Font("Segoe UI", 10.8F);
            genderCombobox.ForeColor = SystemColors.InfoText;
            genderCombobox.FormattingEnabled = true;
            genderCombobox.Items.AddRange(new object[] { "Nam", "Nữ" });
            genderCombobox.Location = new Point(12, 116);
            genderCombobox.Name = "genderCombobox";
            genderCombobox.Size = new Size(288, 33);
            genderCombobox.TabIndex = 26;
            // 
            // StaffDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 394);
            Controls.Add(genderCombobox);
            Controls.Add(addBtn);
            Controls.Add(accountIdTextbox);
            Controls.Add(label8);
            Controls.Add(joinedDateTextbox);
            Controls.Add(label10);
            Controls.Add(emailTextbox);
            Controls.Add(label9);
            Controls.Add(closeBtn);
            Controls.Add(usernameTextbox);
            Controls.Add(label7);
            Controls.Add(saveBtn);
            Controls.Add(statusCombobox);
            Controls.Add(addressTextbox);
            Controls.Add(phoneNumberTextbox);
            Controls.Add(fullNameTextbox);
            Controls.Add(idTextbox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StaffDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StaffDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox idTextbox;
        private TextBox fullNameTextbox;
        private TextBox phoneNumberTextbox;
        private TextBox addressTextbox;
        private ComboBox statusCombobox;
        private Button saveBtn;
        private Label label7;
        private TextBox usernameTextbox;
        private Button closeBtn;
        private TextBox emailTextbox;
        private Label label9;
        private TextBox joinedDateTextbox;
        private Label label10;
        private TextBox accountIdTextbox;
        private Label label8;
        private Button addBtn;
        private ComboBox genderCombobox;
    }
}