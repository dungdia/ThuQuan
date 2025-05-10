namespace DesktopClient.UI.Dialog
{
    partial class DeleteMemeberDialog
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
            delete_member_table = new DataGridView();
            close_btn = new Button();
            confirm_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)delete_member_table).BeginInit();
            SuspendLayout();
            // 
            // delete_member_table
            // 
            delete_member_table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            delete_member_table.Location = new Point(14, 16);
            delete_member_table.Margin = new Padding(3, 4, 3, 4);
            delete_member_table.Name = "delete_member_table";
            delete_member_table.RowHeadersWidth = 51;
            delete_member_table.Size = new Size(887, 357);
            delete_member_table.TabIndex = 0;
            // 
            // close_btn
            // 
            close_btn.BackColor = SystemColors.Info;
            close_btn.Location = new Point(631, 408);
            close_btn.Margin = new Padding(3, 4, 3, 4);
            close_btn.Name = "close_btn";
            close_btn.Size = new Size(110, 76);
            close_btn.TabIndex = 2;
            close_btn.Text = "Hủy";
            close_btn.UseVisualStyleBackColor = false;
            close_btn.Click += close_btn_Click;
            // 
            // confirm_btn
            // 
            confirm_btn.BackColor = Color.IndianRed;
            confirm_btn.ForeColor = SystemColors.ButtonHighlight;
            confirm_btn.Location = new Point(787, 408);
            confirm_btn.Margin = new Padding(3, 4, 3, 4);
            confirm_btn.Name = "confirm_btn";
            confirm_btn.Size = new Size(113, 76);
            confirm_btn.TabIndex = 3;
            confirm_btn.Text = "Xóa";
            confirm_btn.UseVisualStyleBackColor = false;
            confirm_btn.Click += Delete_Event;
            // 
            // DeleteMemeberDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 520);
            Controls.Add(confirm_btn);
            Controls.Add(close_btn);
            Controls.Add(delete_member_table);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeleteMemeberDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xóa thành viên";
            ((System.ComponentModel.ISupportInitialize)delete_member_table).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView delete_member_table;
        private Button close_btn;
        private Button confirm_btn;
    }
}