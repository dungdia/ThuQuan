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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            phieuDatTable = new DataGridView();
            textBox1 = new TextBox();
            button1 = new Button();
            typeDropDown = new ComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            viewToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
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
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            phieuDatTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            phieuDatTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            phieuDatTable.DefaultCellStyle = dataGridViewCellStyle6;
            phieuDatTable.Location = new Point(58, 140);
            phieuDatTable.Margin = new Padding(3, 2, 3, 2);
            phieuDatTable.MultiSelect = false;
            phieuDatTable.Name = "phieuDatTable";
            phieuDatTable.ReadOnly = true;
            phieuDatTable.RowHeadersVisible = false;
            phieuDatTable.RowHeadersWidth = 51;
            phieuDatTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            phieuDatTable.Size = new Size(994, 538);
            phieuDatTable.TabIndex = 0;
            phieuDatTable.CellMouseClick += phieuDatTable_CellMouseClick;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(58, 90);
            textBox1.Margin = new Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(212, 31);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.search;
            button1.Location = new Point(443, 90);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(32, 32);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = false;
            // 
            // typeDropDown
            // 
            typeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeDropDown.FormattingEnabled = true;
            typeDropDown.Items.AddRange(new object[] { "Tất cả", "Chưa xử lý", "Đã xử lý", "Đã huỷ" });
            typeDropDown.Location = new Point(273, 90);
            typeDropDown.Margin = new Padding(3, 2, 3, 2);
            typeDropDown.Name = "typeDropDown";
            typeDropDown.Size = new Size(167, 29);
            typeDropDown.TabIndex = 3;
            typeDropDown.SelectedIndexChanged += typeDropDown_SelectedIndexChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem, editToolStripMenuItem, cancelToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(134, 70);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(133, 22);
            viewToolStripMenuItem.Text = "Xem";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(133, 22);
            editToolStripMenuItem.Text = "Xử lý phiếu";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.Size = new Size(133, 22);
            cancelToolStripMenuItem.Text = "Huỷ phiếu";
            cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 67);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 8;
            label1.Text = "Tìm kiếm";
            // 
            // BookingPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label1);
            Controls.Add(typeDropDown);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(phieuDatTable);
            Name = "BookingPanel";
            Size = new Size(1114, 681);
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
        private Label label1;
    }
}
