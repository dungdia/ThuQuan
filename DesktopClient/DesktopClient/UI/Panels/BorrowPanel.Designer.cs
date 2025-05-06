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
            addButton = new Button();
            label1 = new Label();
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
            phieuMuonTable.Location = new Point(58, 140);
            phieuMuonTable.Margin = new Padding(3, 2, 3, 2);
            phieuMuonTable.MultiSelect = false;
            phieuMuonTable.Name = "phieuMuonTable";
            phieuMuonTable.ReadOnly = true;
            phieuMuonTable.RowHeadersVisible = false;
            phieuMuonTable.RowHeadersWidth = 51;
            phieuMuonTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            phieuMuonTable.Size = new Size(994, 538);
            phieuMuonTable.TabIndex = 1;
            phieuMuonTable.MouseClick += phieuMuonTable_MouseClick;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(58, 86);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(197, 23);
            textBox1.TabIndex = 2;
            // 
            // typeDropDown
            // 
            typeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeDropDown.FormattingEnabled = true;
            typeDropDown.Items.AddRange(new object[] { "Tất cả", "Chưa trả", "Đã trả" });
            typeDropDown.Location = new Point(261, 84);
            typeDropDown.Margin = new Padding(3, 2, 3, 2);
            typeDropDown.Name = "typeDropDown";
            typeDropDown.Size = new Size(154, 29);
            typeDropDown.TabIndex = 5;
            typeDropDown.SelectedIndexChanged += typeDropDown_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Image = Properties.Resources.search;
            button1.Location = new Point(421, 83);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(32, 32);
            button1.TabIndex = 4;
            button1.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(132, 26);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(131, 22);
            viewToolStripMenuItem.Text = "Xem phiếu";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(16, 185, 129);
            addButton.Cursor = Cursors.Hand;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addButton.ForeColor = Color.White;
            addButton.Image = Properties.Resources.add;
            addButton.ImageAlign = ContentAlignment.TopCenter;
            addButton.Location = new Point(980, 50);
            addButton.Margin = new Padding(3, 2, 3, 2);
            addButton.Name = "addButton";
            addButton.Size = new Size(72, 65);
            addButton.TabIndex = 11;
            addButton.Text = "Tạo";
            addButton.TextAlign = ContentAlignment.BottomCenter;
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += createToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 63);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 12;
            label1.Text = "Tìm kiếm";
            // 
            // BorrowPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label1);
            Controls.Add(addButton);
            Controls.Add(typeDropDown);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(phieuMuonTable);
            Name = "BorrowPanel";
            Size = new Size(1114, 681);
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
        private Button addButton;
        private Label label1;
    }
}
