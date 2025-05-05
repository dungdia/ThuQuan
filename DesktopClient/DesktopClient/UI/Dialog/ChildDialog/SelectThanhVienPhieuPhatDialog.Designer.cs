namespace DesktopClient.UI.Dialog.ChildDialog
{
    partial class SelectThanhVienPhieuPhatDialog
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
            label1 = new Label();
            thanhVienDataTable = new DataGridView();
            SelectBtn = new Button();
            CancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)thanhVienDataTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(710, 52);
            label1.TabIndex = 1;
            label1.Text = "Chọn Thành Viên";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // thanhVienDataTable
            // 
            thanhVienDataTable.AllowUserToResizeColumns = false;
            thanhVienDataTable.AllowUserToResizeRows = false;
            thanhVienDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            thanhVienDataTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            thanhVienDataTable.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            thanhVienDataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            thanhVienDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            thanhVienDataTable.DefaultCellStyle = dataGridViewCellStyle2;
            thanhVienDataTable.Dock = DockStyle.Bottom;
            thanhVienDataTable.Location = new Point(0, 131);
            thanhVienDataTable.MultiSelect = false;
            thanhVienDataTable.Name = "thanhVienDataTable";
            thanhVienDataTable.ReadOnly = true;
            thanhVienDataTable.RowHeadersVisible = false;
            thanhVienDataTable.RowHeadersWidth = 51;
            thanhVienDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            thanhVienDataTable.Size = new Size(710, 432);
            thanhVienDataTable.TabIndex = 20;
            // 
            // SelectBtn
            // 
            SelectBtn.BackColor = SystemColors.MenuHighlight;
            SelectBtn.Location = new Point(374, 67);
            SelectBtn.Name = "SelectBtn";
            SelectBtn.Size = new Size(159, 47);
            SelectBtn.TabIndex = 22;
            SelectBtn.Text = "Chọn";
            SelectBtn.UseVisualStyleBackColor = false;
            SelectBtn.Click += SelectBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Red;
            CancelBtn.Location = new Point(539, 67);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(159, 47);
            CancelBtn.TabIndex = 23;
            CancelBtn.Text = "Huỷ";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // SelectThanhVienPhieuPhatDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 563);
            Controls.Add(CancelBtn);
            Controls.Add(SelectBtn);
            Controls.Add(thanhVienDataTable);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectThanhVienPhieuPhatDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SelectThanhVienPhieuPhatDialog";
            ((System.ComponentModel.ISupportInitialize)thanhVienDataTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView thanhVienDataTable;
        private Button SelectBtn;
        private Button CancelBtn;
    }
}