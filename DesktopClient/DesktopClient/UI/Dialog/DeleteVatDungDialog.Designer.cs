namespace DesktopClient.UI.Dialog
{
    partial class DeleteVatDungDialog
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            close_btn = new Button();
            confirm_delete_item = new Button();
            VatDungGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)VatDungGridView).BeginInit();
            SuspendLayout();
            // 
            // close_btn
            // 
            close_btn.BackColor = SystemColors.Info;
            close_btn.Location = new Point(773, 617);
            close_btn.Name = "close_btn";
            close_btn.Size = new Size(96, 57);
            close_btn.TabIndex = 1;
            close_btn.Text = "Hủy";
            close_btn.UseVisualStyleBackColor = false;
            close_btn.Click += close_btn_Click;
            // 
            // confirm_delete_item
            // 
            confirm_delete_item.BackColor = Color.IndianRed;
            confirm_delete_item.ForeColor = SystemColors.ButtonHighlight;
            confirm_delete_item.Location = new Point(929, 617);
            confirm_delete_item.Name = "confirm_delete_item";
            confirm_delete_item.Size = new Size(99, 57);
            confirm_delete_item.TabIndex = 2;
            confirm_delete_item.Text = "Xóa";
            confirm_delete_item.UseVisualStyleBackColor = false;
            confirm_delete_item.Click += confirm_delete_item_Click;
            // 
            // VatDungGridView
            // 
            VatDungGridView.AllowUserToAddRows = false;
            VatDungGridView.AllowUserToDeleteRows = false;
            VatDungGridView.AllowUserToResizeColumns = false;
            VatDungGridView.AllowUserToResizeRows = false;
            VatDungGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            VatDungGridView.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            VatDungGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            VatDungGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            VatDungGridView.Location = new Point(34, 44);
            VatDungGridView.Name = "VatDungGridView";
            VatDungGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            VatDungGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            VatDungGridView.RowHeadersVisible = false;
            VatDungGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            VatDungGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            VatDungGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            VatDungGridView.Size = new Size(994, 538);
            VatDungGridView.TabIndex = 0;
            // 
            // DeleteVatDungDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 787);
            Controls.Add(VatDungGridView);
            Controls.Add(close_btn);
            Controls.Add(confirm_delete_item);
            Name = "DeleteVatDungDialog";
            Text = "Xác nhận xóa vật dụng";
            ((System.ComponentModel.ISupportInitialize)VatDungGridView).EndInit();
            ResumeLayout(false);
        }


        #endregion
        private Button close_btn;
        private Button confirm_delete_item;
        private DataGridView VatDungGridView;
    }
}