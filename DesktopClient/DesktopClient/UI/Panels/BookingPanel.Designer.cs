namespace DesktopClient.UI.Panels
{
    partial class BookingPanel
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
            phieuDatTable = new DataGridView();
            textBox1 = new TextBox();
            button1 = new Button();
            typeDropDown = new ComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            viewToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)phieuDatTable).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // phieuDatTable
            // 
            phieuDatTable.AllowUserToResizeColumns = false;
            phieuDatTable.AllowUserToResizeRows = false;
            phieuDatTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            phieuDatTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            phieuDatTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            phieuDatTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            phieuDatTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            phieuDatTable.DefaultCellStyle = dataGridViewCellStyle2;
            phieuDatTable.Dock = DockStyle.Bottom;
            phieuDatTable.Location = new Point(0, 129);
            phieuDatTable.MultiSelect = false;
            phieuDatTable.Name = "phieuDatTable";
            phieuDatTable.ReadOnly = true;
            phieuDatTable.RowHeadersVisible = false;
            phieuDatTable.RowHeadersWidth = 51;
            phieuDatTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            phieuDatTable.Size = new Size(1273, 779);
            phieuDatTable.TabIndex = 0;
            phieuDatTable.CellMouseClick += phieuDatTable_CellMouseClick;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(17, 44);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên người dùng...";
            textBox1.Size = new Size(293, 38);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(316, 44);
            button1.Name = "button1";
            button1.Size = new Size(102, 38);
            button1.TabIndex = 2;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            // 
            // typeDropDown
            // 
            typeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeDropDown.FormattingEnabled = true;
            typeDropDown.Items.AddRange(new object[] { "Tất cả", "Chưa xử lý", "Đã xử lý", "Đã huỷ" });
            typeDropDown.Location = new Point(424, 46);
            typeDropDown.Name = "typeDropDown";
            typeDropDown.Size = new Size(190, 36);
            typeDropDown.TabIndex = 3;
            typeDropDown.SelectedIndexChanged += typeDropDown_SelectedIndexChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem, editToolStripMenuItem, cancelToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(153, 76);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(152, 24);
            viewToolStripMenuItem.Text = "Xem";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(152, 24);
            editToolStripMenuItem.Text = "Xử lý phiếu";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.Size = new Size(152, 24);
            cancelToolStripMenuItem.Text = "Huỷ phiếu";
            cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click;
            // 
            // BookingPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(typeDropDown);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(phieuDatTable);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BookingPanel";
            Size = new Size(1273, 908);
            ((System.ComponentModel.ISupportInitialize)phieuDatTable).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView phieuDatTable;
        private TextBox textBox1;
        private Button button1;
        private ComboBox typeDropDown;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
    }
}
