namespace DesktopClient.UI.Dialog.ChildDialog
{
    partial class SelectTinhTrangVatDungTraDialog
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
            tinhTrangDropDown = new ComboBox();
            label2 = new Label();
            selectBtn = new Button();
            CancelBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(471, 52);
            label1.TabIndex = 2;
            label1.Text = "Chọn Tình Trạng Vật Dụng";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tinhTrangDropDown
            // 
            tinhTrangDropDown.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tinhTrangDropDown.FormattingEnabled = true;
            tinhTrangDropDown.Items.AddRange(new object[] { "Nguyên vẹn", "Hư hỏng", "Bị mất" });
            tinhTrangDropDown.Location = new Point(26, 107);
            tinhTrangDropDown.Name = "tinhTrangDropDown";
            tinhTrangDropDown.Size = new Size(340, 39);
            tinhTrangDropDown.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 73);
            label2.Name = "label2";
            label2.Size = new Size(119, 31);
            label2.TabIndex = 4;
            label2.Text = "Tình trạng";
            // 
            // selectBtn
            // 
            selectBtn.BackColor = SystemColors.MenuHighlight;
            selectBtn.Location = new Point(103, 163);
            selectBtn.Name = "selectBtn";
            selectBtn.Size = new Size(175, 52);
            selectBtn.TabIndex = 23;
            selectBtn.Text = "Chọn";
            selectBtn.UseVisualStyleBackColor = false;
            selectBtn.Click += selectBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Red;
            CancelBtn.Location = new Point(284, 163);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(175, 52);
            CancelBtn.TabIndex = 24;
            CancelBtn.Text = "Huỷ";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // SelectTinhTrangVatDungTraDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 227);
            Controls.Add(CancelBtn);
            Controls.Add(selectBtn);
            Controls.Add(label2);
            Controls.Add(tinhTrangDropDown);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectTinhTrangVatDungTraDialog";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox tinhTrangDropDown;
        private Label label2;
        private Button selectBtn;
        private Button CancelBtn;
    }
}