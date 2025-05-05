namespace DesktopClient.UI.Panels
{
    partial class PenaltyPanel
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
            phieuPhatTable = new DataGridView();
            typeDropDown = new ComboBox();
            button1 = new Button();
            textBox1 = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            fineToolStripMenuItem = new ToolStripMenuItem();
            editPhiếuToolStripMenuItem = new ToolStripMenuItem();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)phieuPhatTable).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // phieuPhatTable
            // 
            phieuPhatTable.AllowUserToResizeColumns = false;
            phieuPhatTable.AllowUserToResizeRows = false;
            phieuPhatTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            phieuPhatTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            phieuPhatTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            phieuPhatTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            phieuPhatTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            phieuPhatTable.DefaultCellStyle = dataGridViewCellStyle4;
            phieuPhatTable.Dock = DockStyle.Bottom;
            phieuPhatTable.Location = new Point(0, 129);
            phieuPhatTable.MultiSelect = false;
            phieuPhatTable.Name = "phieuPhatTable";
            phieuPhatTable.ReadOnly = true;
            phieuPhatTable.RowHeadersVisible = false;
            phieuPhatTable.RowHeadersWidth = 51;
            phieuPhatTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            phieuPhatTable.Size = new Size(1273, 779);
            phieuPhatTable.TabIndex = 2;
            phieuPhatTable.MouseClick += phieuPhatTable_MouseClick;
            // 
            // typeDropDown
            // 
            typeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeDropDown.FormattingEnabled = true;
            typeDropDown.Items.AddRange(new object[] { "Tất cả", "Chưa xử lý", "Đã xử lý", "Đã huỷ" });
            typeDropDown.Location = new Point(424, 42);
            typeDropDown.Name = "typeDropDown";
            typeDropDown.Size = new Size(190, 36);
            typeDropDown.TabIndex = 8;
            typeDropDown.SelectedIndexChanged += typeDropDown_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(316, 40);
            button1.Name = "button1";
            button1.Size = new Size(102, 38);
            button1.TabIndex = 7;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(18, 40);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên người dùng...";
            textBox1.Size = new Size(293, 38);
            textBox1.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { fineToolStripMenuItem, editPhiếuToolStripMenuItem, cancelToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(172, 100);
            // 
            // fineToolStripMenuItem
            // 
            fineToolStripMenuItem.Name = "fineToolStripMenuItem";
            fineToolStripMenuItem.Size = new Size(171, 24);
            fineToolStripMenuItem.Text = "Xử Lý Vi Phạm";
            fineToolStripMenuItem.Click += fineToolStripMenuItem_Click;
            // 
            // editPhiếuToolStripMenuItem
            // 
            editPhiếuToolStripMenuItem.Name = "editPhiếuToolStripMenuItem";
            editPhiếuToolStripMenuItem.Size = new Size(171, 24);
            editPhiếuToolStripMenuItem.Text = "Sửa phiếu";
            editPhiếuToolStripMenuItem.Click += editPhiếuToolStripMenuItem_Click;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.Size = new Size(171, 24);
            cancelToolStripMenuItem.Text = "Huỷ phiếu";
            cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(171, 24);
            deleteToolStripMenuItem.Text = "Xoá phiếu";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(16, 185, 129);
            addButton.Cursor = Cursors.Hand;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addButton.Location = new Point(1068, 36);
            addButton.Name = "addButton";
            addButton.Size = new Size(169, 48);
            addButton.TabIndex = 10;
            addButton.Text = "Tạo Phiếu Phạt";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // PenaltyPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(addButton);
            Controls.Add(typeDropDown);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(phieuPhatTable);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PenaltyPanel";
            Size = new Size(1273, 908);
            ((System.ComponentModel.ISupportInitialize)phieuPhatTable).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView phieuPhatTable;
        private ComboBox typeDropDown;
        private Button button1;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem fineToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
        private Button addButton;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem editPhiếuToolStripMenuItem;
    }
}
