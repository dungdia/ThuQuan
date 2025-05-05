namespace DesktopClient.UI.Dialog.ChildDialog
{
    partial class SelectFineType
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
            hinhThucDropDown = new ComboBox();
            label3 = new Label();
            mucPhatTextBox = new TextBox();
            confirmBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 75);
            label1.Name = "label1";
            label1.Size = new Size(114, 31);
            label1.TabIndex = 0;
            label1.Text = "Hình thức";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(461, 52);
            label2.TabIndex = 3;
            label2.Text = "Chọn Hình Thức Phạt";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hinhThucDropDown
            // 
            hinhThucDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            hinhThucDropDown.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hinhThucDropDown.FormattingEnabled = true;
            hinhThucDropDown.Items.AddRange(new object[] { "Phạt tiền", "Khoá tài khoản", "Khác" });
            hinhThucDropDown.Location = new Point(40, 119);
            hinhThucDropDown.Name = "hinhThucDropDown";
            hinhThucDropDown.Size = new Size(351, 39);
            hinhThucDropDown.TabIndex = 4;
            hinhThucDropDown.SelectedIndexChanged += hinhThucDropDown_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(38, 167);
            label3.Name = "label3";
            label3.Size = new Size(113, 31);
            label3.TabIndex = 5;
            label3.Text = "Mức phạt";
            // 
            // mucPhatTextBox
            // 
            mucPhatTextBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mucPhatTextBox.Location = new Point(40, 201);
            mucPhatTextBox.Name = "mucPhatTextBox";
            mucPhatTextBox.Size = new Size(347, 38);
            mucPhatTextBox.TabIndex = 6;
            // 
            // confirmBtn
            // 
            confirmBtn.BackColor = SystemColors.MenuHighlight;
            confirmBtn.Location = new Point(93, 270);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(175, 52);
            confirmBtn.TabIndex = 27;
            confirmBtn.Text = "Xác nhận";
            confirmBtn.UseVisualStyleBackColor = false;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.Red;
            cancelBtn.Location = new Point(274, 270);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(175, 52);
            cancelBtn.TabIndex = 28;
            cancelBtn.Text = "Huỷ";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // SelectFineType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 334);
            Controls.Add(cancelBtn);
            Controls.Add(confirmBtn);
            Controls.Add(mucPhatTextBox);
            Controls.Add(label3);
            Controls.Add(hinhThucDropDown);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectFineType";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SelectFineType";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox hinhThucDropDown;
        private Label label3;
        private TextBox mucPhatTextBox;
        private Button confirmBtn;
        private Button cancelBtn;
    }
}