namespace DesktopClient.UI.Dialog.ChildDialog
{
    partial class BookingDateInputDialog
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
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            Confirm = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarTitleBackColor = SystemColors.Window;
            dateTimePicker1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(12, 47);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(366, 38);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 1;
            label1.Text = "Chọn ngày trả dự kiến";
            // 
            // Confirm
            // 
            Confirm.BackColor = SystemColors.ActiveCaption;
            Confirm.Location = new Point(181, 104);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(166, 46);
            Confirm.TabIndex = 2;
            Confirm.Text = "Xác nhận";
            Confirm.UseVisualStyleBackColor = false;
            Confirm.Click += Confirm_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.Red;
            cancelBtn.Location = new Point(353, 104);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(166, 46);
            cancelBtn.TabIndex = 3;
            cancelBtn.Text = "Huỷ";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // BookingDateInputDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(524, 157);
            Controls.Add(cancelBtn);
            Controls.Add(Confirm);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BookingDateInputDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "BookingDateInputDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Button Confirm;
        private Button cancelBtn;
    }
}