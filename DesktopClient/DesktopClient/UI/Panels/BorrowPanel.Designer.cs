namespace DesktopClient.UI.Panels
{
    partial class BorrowPanel
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            phieuMuonTable = new DataGridView();
            textBox1 = new TextBox();
            typeDropDown = new ComboBox();
            button1 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            viewToolStripMenuItem = new ToolStripMenuItem();
            createToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)phieuMuonTable).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // phieuMuonTable
            // 
            phieuMuonTable.AllowUserToResizeColumns = false;
            phieuMuonTable.AllowUserToResizeRows = false;
            phieuMuonTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            phieuMuonTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            phieuMuonTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            phieuMuonTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            phieuMuonTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            phieuMuonTable.DefaultCellStyle = dataGridViewCellStyle4;
            phieuMuonTable.Dock = DockStyle.Bottom;
            phieuMuonTable.Location = new Point(0, 129);
            phieuMuonTable.MultiSelect = false;
            phieuMuonTable.Name = "phieuMuonTable";
            phieuMuonTable.ReadOnly = true;
            phieuMuonTable.RowHeadersVisible = false;
            phieuMuonTable.RowHeadersWidth = 51;
            phieuMuonTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            phieuMuonTable.Size = new Size(1273, 779);
            phieuMuonTable.TabIndex = 1;
            phieuMuonTable.MouseClick += phieuMuonTable_MouseClick;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(17, 40);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên người dùng...";
            textBox1.Size = new Size(293, 38);
            textBox1.TabIndex = 2;
            // 
            // typeDropDown
            // 
            typeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeDropDown.FormattingEnabled = true;
            typeDropDown.Items.AddRange(new object[] { "Tất cả", "Chưa trả", "Đã trả" });
            typeDropDown.Location = new Point(423, 42);
            typeDropDown.Name = "typeDropDown";
            typeDropDown.Size = new Size(190, 36);
            typeDropDown.TabIndex = 5;
            typeDropDown.SelectedIndexChanged += typeDropDown_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(315, 40);
            button1.Name = "button1";
            button1.Size = new Size(102, 38);
            button1.TabIndex = 4;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem, createToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(150, 52);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(210, 24);
            viewToolStripMenuItem.Text = "Xem phiếu";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            createToolStripMenuItem.Size = new Size(210, 24);
            createToolStripMenuItem.Text = "Tạo Phiếu";
            createToolStripMenuItem.Click += createToolStripMenuItem_Click;
            // 
            // BorrowPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(typeDropDown);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(phieuMuonTable);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BorrowPanel";
            Size = new Size(1273, 908);
            ((System.ComponentModel.ISupportInitialize)phieuMuonTable).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView phieuMuonTable;
        private TextBox textBox1;
        private ComboBox typeDropDown;
        private Button button1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem createToolStripMenuItem;
    }
}
