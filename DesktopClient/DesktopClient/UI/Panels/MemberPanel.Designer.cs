namespace DesktopClient.UI
{
    partial class MemberPanel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            ThanhVienTable = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            xemToolStripMenuItem = new ToolStripMenuItem();
            sửaToolStripMenuItem = new ToolStripMenuItem();
            xóaToolStripMenuItem = new ToolStripMenuItem();
            addBtn = new Button();
            timkiem_Input = new TextBox();
            timkiem_Btn = new Button();
            ((System.ComponentModel.ISupportInitialize)ThanhVienTable).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ThanhVienTable
            // 
            ThanhVienTable.AllowUserToResizeColumns = false;
            ThanhVienTable.AllowUserToResizeRows = false;
            ThanhVienTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ThanhVienTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ThanhVienTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ThanhVienTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ThanhVienTable.Location = new Point(0, 140);
            ThanhVienTable.MultiSelect = false;
            ThanhVienTable.Name = "ThanhVienTable";
            ThanhVienTable.ReadOnly = true;
            ThanhVienTable.RowHeadersVisible = false;
            ThanhVienTable.RowHeadersWidth = 55;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F);
            ThanhVienTable.RowsDefaultCellStyle = dataGridViewCellStyle2;
            ThanhVienTable.RowTemplate.Height = 30;
            ThanhVienTable.RowTemplate.Resizable = DataGridViewTriState.False;
            ThanhVienTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ThanhVienTable.Size = new Size(1114, 538);
            ThanhVienTable.TabIndex = 0;
            ThanhVienTable.CellMouseClick += OptionEvent;
            ThanhVienTable.DataBindingComplete += ThanhVienTable_DataBindingComplete;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { xemToolStripMenuItem, sửaToolStripMenuItem, xóaToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(123, 70);
            // 
            // xemToolStripMenuItem
            // 
            xemToolStripMenuItem.Name = "xemToolStripMenuItem";
            xemToolStripMenuItem.Size = new Size(122, 22);
            xemToolStripMenuItem.Text = "Xem";
            xemToolStripMenuItem.Click += XemEvent;
            // 
            // sửaToolStripMenuItem
            // 
            sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            sửaToolStripMenuItem.Size = new Size(122, 22);
            sửaToolStripMenuItem.Text = "Cập nhật";
            sửaToolStripMenuItem.Click += EditEvent;
            // 
            // xóaToolStripMenuItem
            // 
            xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            xóaToolStripMenuItem.Size = new Size(122, 22);
            xóaToolStripMenuItem.Text = "Khóa";
            xóaToolStripMenuItem.Click += LockEvent;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(16, 185, 129);
            addBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            addBtn.Location = new Point(946, 81);
            addBtn.Margin = new Padding(20);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(148, 36);
            addBtn.TabIndex = 2;
            addBtn.Text = "Thêm Thành Viên";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += RegisterEvent;
            // 
            // timkiem_Input
            // 
            timkiem_Input.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timkiem_Input.Location = new Point(20, 85);
            timkiem_Input.Margin = new Padding(20);
            timkiem_Input.Name = "timkiem_Input";
            timkiem_Input.PlaceholderText = "Nhập tên người dùng...";
            timkiem_Input.Size = new Size(257, 32);
            timkiem_Input.TabIndex = 3;
            // 
            // timkiem_Btn
            // 
            timkiem_Btn.Cursor = Cursors.Hand;
            timkiem_Btn.Location = new Point(300, 87);
            timkiem_Btn.Margin = new Padding(20, 20, 5, 20);
            timkiem_Btn.Name = "timkiem_Btn";
            timkiem_Btn.Size = new Size(89, 28);
            timkiem_Btn.TabIndex = 4;
            timkiem_Btn.Text = "Tìm kiếm";
            timkiem_Btn.UseVisualStyleBackColor = true;
            timkiem_Btn.Click += SearchEvent;
            // 
            // MemberPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(timkiem_Btn);
            Controls.Add(timkiem_Input);
            Controls.Add(addBtn);
            Controls.Add(ThanhVienTable);
            Name = "MemberPanel";
            Size = new Size(1114, 681);
            ((System.ComponentModel.ISupportInitialize)ThanhVienTable).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ThanhVienTable;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem xemToolStripMenuItem;
        private ToolStripMenuItem sửaToolStripMenuItem;
        private ToolStripMenuItem xóaToolStripMenuItem;
        private Button addBtn;
        private TextBox timkiem_Input;
        private Button timkiem_Btn;
    }
}
